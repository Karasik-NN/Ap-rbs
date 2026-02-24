using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
   public void StartGame()
{
    AudioManager.instance.PlayClick();
    Invoke("LoadNextScene", 0.15f);
}

void LoadNextScene() => UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");

    public void QuitGame()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayClick();
        }
        Application.Quit();
    }
}