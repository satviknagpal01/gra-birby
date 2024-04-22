using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class scoreMenu : MonoBehaviour
{
    public GameObject ScoreMenu;
    public void Start()
    {
        Cursor.visible = true;
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("startmenu");
    }
    public void quit()
    {
        Application.Quit();
    }
}
