using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI _crediBeatsAmount;
    public TextMeshProUGUI _staminaAmount;
    public Image staminabar;

    private void Update()
    {
        _crediBeatsAmount.text = GameManager.instance._gameCurrency._actualCurrency.ToString();
        _staminaAmount.text = "SALTOS DISPONIBLES: " + GameManager.instance._gamestamina._currentStamina.ToString();
        StaminaBarUpdate();
    }

    public void StaminaBarUpdate()
    {
        switch (GameManager.instance._gamestamina._currentStamina)
        {
            case 5:
                staminabar.fillAmount = 1;
                break;
            case 4:
                staminabar.fillAmount = 0.82f;
                break;
            case 3:
                staminabar.fillAmount = 0.61f;
                break;
            case 2:
                staminabar.fillAmount = 0.39f;
                break;
            case 1:
                staminabar.fillAmount = 0.18f;
                break;
            case 0:
                staminabar.fillAmount = 0;
                break;
        }
    }

}
