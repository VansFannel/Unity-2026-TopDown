using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("Play button pressed");
        SceneManager.LoadScene("Level01Map");
    }

    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
