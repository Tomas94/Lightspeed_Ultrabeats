using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string EscenaACargar;

    public void PasarEscena()
    {
        if (GameManager.instance._gamestamina._currentStamina <= 0) return;
        StartCoroutine(WaitXSeconds(5f));
        SceneManager.LoadScene(EscenaACargar);
        GameManager.instance.timer = 0;
        GameManager.instance._levelScore.ResetScore();
    }

    public static void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public static void ToMainMenu()
    {
        SceneManager.LoadScene(1);
        GameManager.instance.timer = 0;
        GameManager.instance._levelScore.ResetScore();
    }

    public static void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitXSeconds(float time) 
    {
        yield return new WaitForSeconds(time);
    }
}
