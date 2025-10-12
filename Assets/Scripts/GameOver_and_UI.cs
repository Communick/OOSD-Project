using UnityEngine;
using UnityEngine.UI;

public class GameOver_and_UI : MonoBehaviour
{
    [SerializeField]
    private Text scoretext;
    [SerializeField]
    private GameObject gameOverScreen, error, error1, error2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoretext.text = "000000";
        error.SetActive(false);
        error1.SetActive(false);
        error2.SetActive(false);
        gameOverScreen.SetActive(false);
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
            gameOverScreen.SetActive(true);
        }
    }
}
