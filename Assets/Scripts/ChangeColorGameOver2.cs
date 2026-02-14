using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeColorGameOver2 : MonoBehaviour
{
    public TextMeshProUGUI subtext;
    public AudioSource audioButton;

    public void MouseInColor()
    {
        subtext.color = Color.red;
        audioButton.Play();
    }
    public void MouseOutColor()
    {
        subtext.color = Color.white;
    }
}