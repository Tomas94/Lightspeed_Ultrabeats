using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuStatsUpdater : MonoBehaviour
{
    StaminaManager _staCtrl;
    public TextMeshProUGUI crediBeatsAmount, staminaAmount;
    public Image staminaBar;
    int _currentStm;

    private void Start()
    {
        _currentStm = GameManager.Instance.stamina;
        _staCtrl = GetComponent<StaminaManager>();
        StaminaBarUpdate();
        staminaAmount.text += ": " + GameManager.Instance.stamina.ToString();
    }

    private void Update()
    {
        crediBeatsAmount.text = GameManager.Instance.currency.ToString();
        if(_currentStm != GameManager.Instance.stamina)
        {
            _currentStm = GameManager.Instance.stamina;
            staminaAmount.text.Replace(GameManager.Instance.stamina.ToString(), _currentStm.ToString());
        }
    }

    public void StaminaBarUpdate()
    {
        float updatedStaminaAmount = (float)GameManager.Instance.stamina / (float)_staCtrl.MaxStamina;
        staminaBar.fillAmount = updatedStaminaAmount;
    }
}
