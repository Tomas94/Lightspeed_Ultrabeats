using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void PlayLevel(string level)
    {
        if (GameManager.Instance.stamina <= 0) return;
        StartCoroutine(StartLevel(.25f, level));
    }

    public static void ResetGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public static void ToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    public static void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Restart()
    { UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name); }

    public static void Resume()
    {
        Time.timeScale = 1f;
    }

    IEnumerator StartLevel(float time, string EscenaACargar) 
    {
        yield return new WaitForSeconds(time);
        UnityEngine.SceneManagement.SceneManager.LoadScene(EscenaACargar);
    }
}
