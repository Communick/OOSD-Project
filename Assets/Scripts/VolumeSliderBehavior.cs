using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSliderBehavior : MonoBehaviour
{
    [SerializeField]
    private AudioMixer mixer;
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private TextMeshProUGUI valueText;
    [SerializeField]
    private AudioMixMode MixMode;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mixer.SetFloat("Volume", Mathf.Log10(PlayerPrefs.GetFloat("Volume", 1) * 20));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChangeSlider(float value)
    {
        valueText.SetText($"{value.ToString("N1")}");

        switch (MixMode)
        {
            case AudioMixMode.LogarithmicMixerVolume:
                mixer.SetFloat("Volume", Mathf.Log10(value) * 20);
                break;
            case AudioMixMode.LinearMixerVolume:
                mixer.SetFloat("Volume", (-80 + value * 100));
                break;
            case AudioMixMode.LinearAudioSourceVolume:
                source.volume = value;
                break;
        }

        PlayerPrefs.SetFloat("Volume", value);
        PlayerPrefs.Save();
    }

    public enum AudioMixMode
    {
        LinearAudioSourceVolume,
        LinearMixerVolume,
        LogarithmicMixerVolume
    }
}
