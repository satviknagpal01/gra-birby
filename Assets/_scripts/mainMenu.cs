using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject Settings;
    public GameObject loadScreen;
    public GameObject Something;
    public GameObject Crosshair;
    public SpriteRenderer sr ;
    public Sprite[] spr;
    int i;
    public void PlayGame()
    {
        MainMenu.SetActive(false);
        loadScreen.SetActive(true);
        sr = GetComponent<SpriteRenderer>();
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
        i = 0;
    }
    public void Two()
    {
        i = 1;
    }
    public void Three()
    {
        i = 2;
    }
    public void Four()
    {
        i = 3;
    }
    public void Apply()
    {
        sr.sprite = spr[i]; 
        MainMenu.SetActive(true);
        Something.SetActive(true);
        Settings.SetActive(false);
    }
}
