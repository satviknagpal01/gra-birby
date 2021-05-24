using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Settings;
    public GameObject Something;
    public SpriteRenderer[] sr = new SpriteRenderer[4];
    public void PlayGame()
    {
        SceneManager.LoadScene("runner");
    }
    public void Setting()
    {
        MainMenu.SetActive(false);
        Something.SetActive(false);
        Settings.SetActive(true);
    }
    public void quit()
    {
        Application.Quit();
    }
    public void One()
    {
        //
    }
}
