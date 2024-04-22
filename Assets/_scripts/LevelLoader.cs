using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine(load());
        StartCoroutine(LoadAsyncrously(sceneIndex));
    }
    IEnumerator LoadAsyncrously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress);
            slider.value = progress;
            yield return null;
        }
    }
    IEnumerator load()
    {
        yield return new WaitForSeconds(1.4f);
    }
}
