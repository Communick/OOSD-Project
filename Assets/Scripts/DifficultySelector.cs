using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelector : MonoBehaviour
{
    public Slider difficultySlider;
    public TextMeshProUGUI difficultyLabel;
    public int savedDifficulty;
    public int currentDifficulty;

    void Start()
    {
        savedDifficulty = PlayerPrefs.GetInt("DifficultyLevel", 1);
        difficultySlider.value = savedDifficulty;
        UpdateDifficultyLabel(savedDifficulty);
    }

    public void OnDifficultyChanged()
    {
        currentDifficulty = (int)difficultySlider.value;
        PlayerPrefs.SetInt("DifficultyLevel", currentDifficulty);
        PlayerPrefs.Save();
        UpdateDifficultyLabel(currentDifficulty);
    }

    void UpdateDifficultyLabel(int level)
    {
        switch (level)
        {
            case 0:
                difficultyLabel.text = "Training Mode";
                break;
            case 1:
                difficultyLabel.text = "Baby Mode";
                
                break;
            case 2:
                difficultyLabel.text = "Easy";
                
                break;
            case 3:
                difficultyLabel.text = "Normal";
                
                break;
            case 4:
                difficultyLabel.text = "Hard";
                
                break;
            case 5:
                difficultyLabel.text = "Death Wish";
                break;
        }
    }
}
