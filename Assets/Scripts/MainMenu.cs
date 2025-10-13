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
    [SerializeField]
    private PlayerBehavior player;
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
        transform.position = player.transform.position + new Vector3(0, 0, 3);
    }

    void Update()
    {
        spawner.SetDifficulty(difficultySelector.currentDifficulty);
        transform.position = player.transform.position + new Vector3(0, 0, 3);
    }

    public void PlayButton()
    {
        Menu.SetActive(false);
        player.started = true;
        Time.timeScale = 1f;
    }
}
