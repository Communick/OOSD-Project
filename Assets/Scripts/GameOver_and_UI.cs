using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver_and_UI : MonoBehaviour
{
    [SerializeField]
    private Text scoretext, gameOverScore, comboText;
    [SerializeField]
    private GameObject gameOverScreen, error, error1, error2, lifeSystem, playerCamera, inputNameScore, keyboard, saveButton;
    [SerializeField]
    private MainMenu MainMenu;
    private int totalscore, totalife;
    public bool restarted = false;
    public int comboMult;
    public string copyScore;
    public List<GameObject> spawnedFruitList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoretext.text = "000000";
        gameOverScore.text = "";
        comboText.text = "x" + comboMult.ToString();
        saveButton.SetActive(true);
        error.SetActive(false);
        error1.SetActive(false);
        error2.SetActive(false);
        gameOverScreen.SetActive(false);
        inputNameScore.SetActive(false);
        lifeSystem.SetActive(true);
        totalscore = 0;
        comboMult = 1;
        totalife = 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerCamera.transform.position + new Vector3(0f, 0f, 2.5f);
        comboText.text = "x" + comboMult.ToString();
    }

    public void UpdateScore(int score)
    {
        totalscore += score * comboMult;
        scoretext.text = "";
        for (int i = 0; i< 6 - totalscore.ToString().Length; i++)
        {
            scoretext.text += "0";
        }
        scoretext.text += totalscore.ToString();
    }

    public void LifeCounter(int life)
    {
        totalife += life;
        switch (totalife)
        {
            case 2:
                error.SetActive(true); 
                break;
            case 1: 
                error1.SetActive(true);
                break;
            case 0:
                error2.SetActive(true);
                break;
        }
        if (totalife == 0)
        {
            gameOverScore.text = scoretext.text;
            copyScore = scoretext.text;
            scoretext.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            lifeSystem.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void RestartGameButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        restarted = true;
        SaveScoreBehavior saveScore = inputNameScore.GetComponent<SaveScoreBehavior>();
        saveScore.saved = false;
    }

    public void MainMenuButton()
    {
        restarted = false;
        SaveScoreBehavior saveScore = inputNameScore.GetComponent<SaveScoreBehavior>();
        saveScore.saved = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);      
    }

    public void QuitButton()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void SaveScore()
    {
        SaveScoreBehavior saveScore = inputNameScore.GetComponent<SaveScoreBehavior>();
        if (saveScore.saved == true) saveButton.gameObject.SetActive(false);
        inputNameScore.SetActive(true);
        keyboard.SetActive(true);

    }
}
