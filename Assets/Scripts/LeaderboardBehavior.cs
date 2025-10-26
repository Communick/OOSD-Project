using OVRSimpleJSON;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

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
        leaderboardlist = JsonConvert.DeserializeObject<List<Score>>(leaderboardData);
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
        leaderboardData = System.IO.File.ReadAllText(saveScoreBehavior.filepath);
        leaderboardlist = JsonConvert.DeserializeObject<List<Score>>(leaderboardData);
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
        System.IO.File.WriteAllText(saveScoreBehavior.filepath, JsonConvert.SerializeObject(leaderboardlist, Formatting.Indented));
    }

    public void NewPage()
    {
        leaderboard.text = "";
        for (int i = 0 + 10 * (pageNumber - 1); i < 10 + 10 * (pageNumber - 1); i++)
        {
            if (leaderboardlist.Count >= 10 + 10 * (pageNumber - 1))
            {
                leaderboard.text += $"{i+1}{leaderboardlist[i].playerName, -15} {leaderboardlist[i].score, 6} \n";
            }
            else
            {
                for (int j = 0 + 10 * (pageNumber - 1); j <= leaderboardlist.Count - 1; j++)
                {
                    leaderboard.text += $"{j+1}{leaderboardlist[j].playerName, -15} {leaderboardlist[j].score, 6} \n";
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
