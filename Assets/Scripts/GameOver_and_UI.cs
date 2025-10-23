using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver_and_UI : MonoBehaviour
{
    [SerializeField]
    private Text scoretext, gameOverScore, comboText;
    [SerializeField]
    private GameObject gameOverScreen, error, error1, error2, lifeSystem, playerCamera, inputNameScore;
    [SerializeField]
    private MainMenu MainMenu;
    private int totalscore;
    public bool restarted = false;
    public int comboMult;
    public string copyScore;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoretext.text = "000000";
        gameOverScore.text = "";
        comboText.text = "x" + comboMult.ToString();
        error.SetActive(false);
        error1.SetActive(false);
        error2.SetActive(false);
        gameOverScreen.SetActive(false);
        inputNameScore.SetActive(false);
        lifeSystem.SetActive(true);
        totalscore = 0;
        comboMult = 1;
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
        switch (life)
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
        if (life == 0)
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
    }

    public void MainMenuButton()
    {
        restarted = false;
        MainMenu.gameObject.SetActive(true);
        gameOverScreen.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void SaveScore()
    {
        inputNameScore.SetActive(true);
    }
}
