using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameUI_Controller : MonoBehaviour
{
    public Image shieldFillCircle, ondasFillCircle, lifeFillBar;
    public TextMeshProUGUI score;

    void Start() { score.text = "0"; }

    void Update() { score.text = ScoreManager.Instance.Score.ToString(); }

    public void ShieldChargeUP() { if (shieldFillCircle.fillAmount < 1) shieldFillCircle.fillAmount += 0.1f; }

    public void PauseGame() => SceneManagerr.Pause();

    public void ResumeGame() => SceneManagerr.Resume();

    public void ToMainMenu() => SceneManagerr.ToMainMenu();

    public void RestartLevel() => SceneManagerr.Restart();
}
