using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Replace "GameScene" par le nom exact de ta sc�ne de jeu
        SceneManager.LoadScene("test");
    }
}
