using TMPro;
using UnityEngine;

public class AdviceText : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;

    string currentText;
    float fadeDuration = 5f;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        textMeshProUGUI.enabled = false;

        currentText = textMeshProUGUI.text;
    }

    private void Update()
    {
        if (textMeshProUGUI.text != currentText)
        {
            currentText = textMeshProUGUI.text;

            if (!textMeshProUGUI.enabled) textMeshProUGUI.enabled = true;
            if (textMeshProUGUI.alpha == 0f) textMeshProUGUI.alpha = 1f;

            textMeshProUGUI.CrossFadeAlpha(0, fadeDuration, false);
        }
    }

}
