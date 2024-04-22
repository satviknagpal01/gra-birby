using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager s_instance;
    public GameManager Instance
    {
        get
        {
            if (s_instance == null)
            {
                s_instance = this;
            }
            return s_instance;
        }
    }

    private void Awake()
    {
        s_instance = this;
    }

    private void OnDestroy()
    {
        s_instance = null;
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public void RestartGame()
    {
        Debug.Log("Restart Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
    }

    public void PauseGame()
    {
        Debug.Log("Pause Game");
    }

    public void ResumeGame()
    {
        Debug.Log("Resume Game");
    }

    public void StartGame()
    {
        Debug.Log("Start Game");
    }

}