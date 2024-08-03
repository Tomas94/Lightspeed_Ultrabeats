using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerr : MonoBehaviour
{
    public static SceneManagerr instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        DontDestroyOnLoad(this);
    }

    public void PlayLevel(string level, float delay = 0.25f)
    {
        StartCoroutine(StartLevel(delay, level));
    }

    public static void Pause()
    {
        Time.timeScale = 0f;
        //Debug.Log("En Pausa");
    }
    public static void Resume() => Time.timeScale = 1f;

    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if(Time.timeScale != 1) Resume();
    }
    public static void ToMainMenu() => SceneManager.LoadScene(1);

    public static void ResetGame() => SceneManager.LoadScene(0);

    public static void QuitGame() => Application.Quit();

    IEnumerator StartLevel(float time, string EscenaACargar)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(EscenaACargar);
    }
}
