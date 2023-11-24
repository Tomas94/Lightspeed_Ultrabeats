using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuStatsUpdater : MonoBehaviour
{
    StaminaController _staCtrl;
    public TextMeshProUGUI crediBeatsAmount;
    public TextMeshProUGUI staminaAmount;
    public Image staminaBar;

    private void Start()
    {
        _staCtrl = GetComponent<StaminaController>();
        StaminaBarUpdate();
    }

    private void Update()
    {
        crediBeatsAmount.text = GameManager.Instance.currency.ToString();
        staminaAmount.text = "SALTOS DISPONIBLES: " + GameManager.Instance.stamina.ToString();
    }

    public void StaminaBarUpdate()
    {
        float updatedStaminaAmount = (float)GameManager.Instance.stamina / (float)_staCtrl.MaxStamina;
        staminaBar.fillAmount = updatedStaminaAmount;
        Debug.Log("current " + GameManager.Instance.stamina + "max  " + _staCtrl.MaxStamina + "= % " +  updatedStaminaAmount);
        /*switch (GameManager.Instance.stamina)
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
        }*/
    }
}
