using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private FruitSpawnerBehavior spawner;
    [SerializeField]
    private DifficultySelector difficultySelector;
    [SerializeField]
    private GameObject Menu, leaderboardPanel;
    [SerializeField]
    private GameOver_and_UI UI;
    [SerializeField]
    private PlayerBehavior player;
    [SerializeField]
    private GameObject playercamera;
    [SerializeField]
    private SaveScoreBehavior saveScoreBehavior;
    [SerializeField]
    private Text leaderboard;
    void Start()
    {
        if (UI.restarted)
        {
            Menu.SetActive(false);
        }
        else if (!player.started)
        {
            Menu.SetActive(true);
            Time.timeScale = 0f;
        }
        if (difficultySelector.currentDifficulty == difficultySelector.savedDifficulty)
        {
            spawner.SetDifficulty(difficultySelector.savedDifficulty);
        }
        else spawner.SetDifficulty(difficultySelector.currentDifficulty);
        transform.position = playercamera.transform.position + new Vector3(0, 0, 3);
        leaderboardPanel.SetActive(false);
    }

    void Update()
    {
        spawner.SetDifficulty(difficultySelector.currentDifficulty);
        transform.position = playercamera.transform.position + new Vector3(0, 0, 3);
    }

    public void PlayButton()
    {
        Menu.SetActive(false);
        player.started = true;
        Time.timeScale = 1f;
    }

    public void ShowLeaderboard()
    {
        leaderboardPanel.SetActive(true);
        string leaderboardData = System.IO.File.ReadAllText(saveScoreBehavior.filepath);
        List<Score> leaderboardlist = JsonUtility.FromJson<List<Score>>(leaderboardData);
        for (int i = 0; i < 10; i++)
        {
            if (leaderboardlist.Count >= 10)
            {
                leaderboard.text += $"<align=left>{leaderboardlist[i].playerName} <align=right>{leaderboardlist[i].score} \n";
            }
            else
            {
                for (int j = 0; j <= leaderboardlist.Count; i++)
                {
                    leaderboard.text += $"<align=left>{leaderboardlist[i].playerName} <align=right>{leaderboardlist[i].score} \n";
                }
                for (int k = 0; k <= 10 - leaderboardlist.Count; k++)
                {
                    leaderboard.text += "Empty\n";
                }
                break;
            }
        }
    }
}
