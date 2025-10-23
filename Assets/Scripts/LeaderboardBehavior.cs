using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject nextButton, previousButton, leaderboardPanel;
    [SerializeField]
    private Text leaderboard, pageNumberText;
    [SerializeField]
    private SaveScoreBehavior saveScoreBehavior;
    private int pageNumber;
    private string leaderboardData;
    private List<Score> leaderboardlist;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pageNumber = 1;
        pageNumberText.text = pageNumber.ToString();
        leaderboardData = System.IO.File.ReadAllText(saveScoreBehavior.filepath);
        List<Score> leaderboardlist = JsonUtility.FromJson<List<Score>>(leaderboardData);
        if (leaderboardlist.Count / pageNumber > 10)
        {
            nextButton.SetActive(true);
        }
        else
        {
            nextButton.SetActive(false);
        }
        previousButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        pageNumberText.text = pageNumber.ToString();
        if (leaderboardlist.Count/pageNumber > 10)
        {
            nextButton.SetActive(true);
        }
        else
        {
            nextButton.SetActive(false);
        }
        if (leaderboardlist.Count > 10 && leaderboardlist.Count / pageNumber < 10)
        {
            previousButton.SetActive(true);
        }
        else
        {
            previousButton.SetActive(false);
        }
    }

    public void CloseLeaderboard()
    {
        leaderboard.text = "";
        leaderboardPanel.SetActive(false);
    }

    public void ClearLeaderboard()
    {
        leaderboardlist.Clear();
        System.IO.File.WriteAllText(saveScoreBehavior.filepath, JsonUtility.ToJson(leaderboardlist));
    }

    public void NewPage()
    {
        leaderboard.text = "";
        for (int i = 0 + 10 * (pageNumber - 1); i < 10 + 10 * (pageNumber - 1); i++)
        {
            if (leaderboardlist.Count >= 10 + 10 * (pageNumber - 1))
            {
                leaderboard.text += $"<align=left>{i+1}{leaderboardlist[i].playerName} <align=right>{leaderboardlist[i].score} \n";
            }
            else
            {
                for (int j = 0 + 10 * (pageNumber - 1); j <= leaderboardlist.Count; i++)
                {
                    leaderboard.text += $"<align=left>{j+1}{leaderboardlist[j].playerName} <align=right>{leaderboardlist[j].score} \n";
                }
                for (int k = 0; k <= 10 - leaderboardlist.Count%10; k++)
                {
                    leaderboard.text += "Empty\n";
                }
                break;
            }
        }
    }

    public void NextPage()
    {
        pageNumber++;
    }

    public void PreviousPage()
    {
        pageNumber--;
    }
}
