using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu_Controller : MonoBehaviour
{
    public TextMeshProUGUI crediBeatsAmount;
    public TextMeshProUGUI staminaAmount;
    public Image staminaBar;

    private void Update()
    {
        crediBeatsAmount.text = GameManager.Instance.currency.ToString();
        staminaAmount.text = "SALTOS DISPONIBLES: " + GameManager.Instance.stamina.ToString();
        StaminaBarUpdate();
    }

    public void StaminaBarUpdate()
    {
        switch (GameManager.Instance.stamina)
        {
            case 5:
                staminaBar.fillAmount = 1;
                break;
            case 4:
                staminaBar.fillAmount = 0.82f;
                break;
            case 3:
                staminaBar.fillAmount = 0.61f;
                break;
            case 2:
                staminaBar.fillAmount = 0.39f;
                break;
            case 1:
                staminaBar.fillAmount = 0.18f;
                break;
            case 0:
                staminaBar.fillAmount = 0;
                break;
        }
    }
}
