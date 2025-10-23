using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;

public class SaveScoreBehavior : MonoBehaviour
{
    [SerializeField]
    private GameOver_and_UI UIScreen;
    [SerializeField]
    private GameObject saveScoreScreen;
    [SerializeField]
    private List<Score> scores = new List<Score>();
    [SerializeField]
    private InputField nameInput;
    private bool done;
    public string filepath;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        filepath = Application.persistentDataPath + "/ScoreLeaderboard.json";
        saveScoreScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (done) saveScoreScreen.SetActive(false);
    }

    public void SaveScore()
    {
        Score score = new Score();
        score.playerName = nameInput.text;
        score.score = UIScreen.copyScore;
        scores.Add(score);
        string scoreLB = JsonUtility.ToJson(score);
        Debug.Log(filepath);
        System.IO.File.WriteAllText(filepath, scoreLB);
    }
}

public class Score
{
    public string playerName;
    public string score;
}
