using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private FruitSpawnerBehavior spawner;
    [SerializeField]
    private DifficultySelector difficultySelector;
    [SerializeField]
    private GameObject Menu;
    [SerializeField]
    private GameOver_and_UI UI;
    void Start()
    {
        if (UI.restarted)
        {
            Menu.SetActive(false);
        }
        else
        {
            Menu.SetActive(true);
            Time.timeScale = 0f;
        }
        spawner.SetDifficulty(difficultySelector.savedDifficulty);
    }

    void Update()
    {
        spawner.SetDifficulty(difficultySelector.savedDifficulty);
    }

    public void PlayButton()
    {
        Menu.SetActive(false);
        Time.timeScale = 1f;
    }
}
