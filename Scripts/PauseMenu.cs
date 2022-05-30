using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool IsPaused;
    [SerializeField] private GameObject PauseCanvas;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void RestartLevelI()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        PauseCanvas.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pause()
    {
        PauseCanvas.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
