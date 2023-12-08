using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerr : MonoBehaviour
{
    public static SceneManagerr instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void PlayLevel(string level)
    {
        StartCoroutine(StartLevel(.25f, level));
    }

    public static void Pause() => Time.timeScale = 0f;

    public static void Resume() => Time.timeScale = 1f;

    public static void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public static void ToMainMenu() => SceneManager.LoadScene(1);

    public static void ResetGame() => SceneManager.LoadScene(0);

    public static void QuitGame() => Application.Quit();
    
    IEnumerator StartLevel(float time, string EscenaACargar)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(EscenaACargar);
    }
}
