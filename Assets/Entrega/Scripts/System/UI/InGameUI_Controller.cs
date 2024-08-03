using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class InGameUI_Controller : MonoBehaviour
{
    public Image shieldFillCircle, waveFillCircle, lifeFillBar, carga1, carga2, carga3;
    public TextMeshProUGUI score;
    public Player player;
    public List<Image> cargas = new List<Image>();

    void Start() 
    {
        score.text = "0";
        cargas.Add(carga1);
        cargas.Add(carga2);
        cargas.Add(carga3);

        //SceneManagerr.Resume();
    }

    void Update()
    {
        score.text = ScoreManager.Instance.Score.ToString();
        lifeFillBar.fillAmount = player.currentLife / player.MaxLife;
    }

    public void ShieldChargeUP() { if (shieldFillCircle.fillAmount < 1) shieldFillCircle.fillAmount += 0.1f; }

    #region Opciones
    public void PauseGame() => SceneManagerr.Pause();

    public void ResumeGame() => SceneManagerr.Resume();

    public void ToMainMenu() => SceneManagerr.ToMainMenu();

    public void RestartLevel() => SceneManagerr.Restart();
    #endregion
}
