using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Newtonsoft.Json;

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
        else
        {
            Menu.SetActive(true);
            Time.timeScale = 0.0f;
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
        Time.timeScale = 1f;
    }

    public void ShowLeaderboard()
    {
        leaderboardPanel.SetActive(true);
        string leaderboardData = System.IO.File.ReadAllText(saveScoreBehavior.filepath);
        List<Score> leaderboardlist = JsonConvert.DeserializeObject<List<Score>>(leaderboardData);
        for (int i = 0; i < 10; i++)
        {
            if (leaderboardlist.Count >= 10)
            {
                leaderboard.text += $"{i+1}. {leaderboardlist[i].playerName, -15} {leaderboardlist[i].score, 6} \n";
            }
            else
            {
                for (int j = 0; j <= leaderboardlist.Count - 1; j++)
                {
                    leaderboard.text += $"{j+1}. {leaderboardlist[j].playerName, -15} {leaderboardlist[j].score, 6} \n";
                }
                break;
            }
        }
    }
}
