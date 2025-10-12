using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySelector : MonoBehaviour
{
    public Slider difficultySlider;
    public TextMeshProUGUI difficultyLabel;  // Référence au texte sous le slider

    void Start()
    {
        int savedDifficulty = PlayerPrefs.GetInt("DifficultyLevel", 1);
        difficultySlider.value = savedDifficulty;
        UpdateDifficultyLabel(savedDifficulty);
    }

    public void OnDifficultyChanged()
    {
        int currentDifficulty = (int)difficultySlider.value;
        PlayerPrefs.SetInt("DifficultyLevel", currentDifficulty);
        PlayerPrefs.Save();
        UpdateDifficultyLabel(currentDifficulty);
        ApplyDifficulty(currentDifficulty);
    }

    void UpdateDifficultyLabel(int level)
    {
        switch (level)
        {
            case 0:
                difficultyLabel.text = "Baby Mode";
                break;
            case 1:
                difficultyLabel.text = "Easy";
                break;
            case 2:
                difficultyLabel.text = "Normal";
                break;
            case 3:
                difficultyLabel.text = "Hard";
                break;
            case 4:
                difficultyLabel.text = "Death Wish";
                break;
            default:
                difficultyLabel.text = "Unknown";
                break;
        }
    }

    void ApplyDifficulty(int level)
    {
        // Implémenter la logique de difficulté du jeu ici
    }
}
