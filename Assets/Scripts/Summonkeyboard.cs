using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using Microsoft.MixedReality.Toolkit.Experimental.UI;

public class VRKeyboardManager : MonoBehaviour
{
    private TMP_InputField input;
    [SerializeField]
    private GameObject keyboard, saveScorePanel;
    void Start()
    {
        input = GetComponent<TMP_InputField>();
        input.onSelect.AddListener(x => OpenKeyboard());
        keyboard.SetActive(false);
    }

    void Update()
    {
        keyboard.transform.position = saveScorePanel.transform.position + new Vector3(0, -0.8f, -1f);
    }

    private void OpenKeyboard()
    {
        NonNativeKeyboard.Instance.InputField = input;
        NonNativeKeyboard.Instance.PresentKeyboard(input.text);
    }
}
