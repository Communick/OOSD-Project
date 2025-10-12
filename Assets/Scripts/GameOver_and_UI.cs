using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver_and_UI : MonoBehaviour
{
    [SerializeField]
    private Text scoretext, gameOverScore;
    [SerializeField]
    private GameObject gameOverScreen, error, error1, error2, LifeSystem;
    [SerializeField]
    private MainMenu MainMenu;
    public bool restarted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoretext.text = "000000";
        gameOverScore.text = "";
        error.SetActive(false);
        error1.SetActive(false);
        error2.SetActive(false);
        gameOverScreen.SetActive(false);
        LifeSystem.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {   
        for (int i = 0; i< 6 - score.ToString().Length; i++)
        {
            scoretext.text += "0";
        }
        scoretext.text += score.ToString();
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
            scoretext.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            LifeSystem.SetActive(false);
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
}
