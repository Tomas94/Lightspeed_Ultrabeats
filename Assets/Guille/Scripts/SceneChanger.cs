using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string EscenaACargar;

    public void PasarEscena()
    {
        SceneManager.LoadScene(EscenaACargar);
    }

    public static void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public static void QuitGame()
    {
        Application.Quit();
    }
}
