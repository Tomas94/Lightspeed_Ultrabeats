using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class InGameUI_Controller : MonoBehaviour
{
    public Image shieldFillCircle;
    public Image ondasFillCircle;
    public Image lifeFillBar;
    public TextMeshProUGUI score;
   
    void Start()
    {
        score.text = "0";  
    }

    void Update()
    {
        score.text = GameManager.instance._levelScore.totalScore.ToString();  
    }

    public void ShieldChargeUP()
    {
        if(shieldFillCircle.fillAmount < 1) shieldFillCircle.fillAmount += 0.1f;
    }
}
