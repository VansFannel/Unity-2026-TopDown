using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeColor : MonoBehaviour
{
    public TextMeshProUGUI subtext;
    public AudioSource audioButton;

    public void MouseInColor()
    {
        subtext.color = Color.blue;
        audioButton.Play();
    }
    public void MouseOutColor()
    {
        subtext.color = Color.black;
    }
}