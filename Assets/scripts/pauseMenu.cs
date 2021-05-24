using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject ExitMenuUI;
    public GameObject GoMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Menu()
    {
        pauseMenuUI.SetActive(false);
        GoMenuUI.SetActive(true);
    }
    public void Quit()
    {
        pauseMenuUI.SetActive(false);
        ExitMenuUI.SetActive(true);
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void no()
    {
        ExitMenuUI.SetActive(false);
        GoMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
    public void exityes()
    {
        SceneManager.LoadScene("Score");
    }
    public void menuyes()
    {
        SceneManager.LoadScene("startmenu");
    }
}
