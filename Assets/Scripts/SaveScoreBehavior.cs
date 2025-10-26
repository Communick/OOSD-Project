using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
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
    private TMP_InputField nameInput;
    public string filepath;
    public bool saved;
    void Awake()
    {
        filepath = Application.persistentDataPath + "/ScoreLeaderboard.json";
        if (!File.Exists(filepath))
        {
            Debug.Log("Creating new leaderboard file at: " + filepath);
            File.WriteAllText(filepath, "{}"); // or "[]" depending on your JSON
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nameInput.text = string.Empty;
        saveScoreScreen.SetActive(false);
        saved = false;
        string json = File.ReadAllText(filepath);
        scores = JsonConvert.DeserializeObject<List<Score>>(json);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveScore()
    {
        Score score = new Score();
        score.playerName = nameInput.text;
        score.score = UIScreen.copyScore;
        scores.Add(score);
        string scoreLB = JsonConvert.SerializeObject(scores, Formatting.Indented);
        Debug.Log(filepath);
        File.WriteAllText(filepath, scoreLB);
        saved = true;
        saveScoreScreen.SetActive(false);
    }

    public void Cancel()
    {
        saveScoreScreen.SetActive(false);
    }
}

public class Score
{
    public string playerName;
    public string score;
}

