using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStart : MonoBehaviour
{
    public void BackToMainMenu()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.PlayClick();
        }
            Invoke("LoadMainMenu", 0.15f);
        SceneManager.LoadScene("Start Scene"); 
    }
}