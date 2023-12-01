using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameUI_Controller : MonoBehaviour
{
    public Image shieldFillCircle, ondasFillCircle, lifeFillBar;
    public TextMeshProUGUI score;

    void Start() { score.text = "0"; }

    void Update() { score.text = ScoreManager.Instance._levelScore.totalScore.ToString(); }

    public void ShieldChargeUP() { if (shieldFillCircle.fillAmount < 1) shieldFillCircle.fillAmount += 0.1f; }
}
