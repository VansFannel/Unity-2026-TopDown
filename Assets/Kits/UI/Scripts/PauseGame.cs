using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PauseGame : MonoBehaviour
{
    public GameObject menu;
    private bool isPaused = false;

    public void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level01Map");
    }

    public void ResumeGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
