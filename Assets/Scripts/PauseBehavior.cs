using UnityEngine;
using UnityEngine.XR;

public class PauseBehavior : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameOver_and_UI GOUI;
    [SerializeField]
    private GameObject playerCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.Start) || OVRInput.GetDown(OVRInput.RawButton.Start) || OVRInput.GetDown(OVRInput.Button.Three) == true)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
        transform.position = playerCamera.transform.position + new Vector3(0, 0, 1.5f);
    }

    public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void QuitButton()
    {
        GOUI.LifeCounter(0);
        pauseMenu.SetActive(false);
    }
}
