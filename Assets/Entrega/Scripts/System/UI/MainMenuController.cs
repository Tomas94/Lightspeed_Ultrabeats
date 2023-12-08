using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    StaminaManager _staminaManager;
    CurrencyManager _currencyManager;
    UpgradePointsManager _upgradePointsManager;
    SceneManagerr _sceneManager;

    public TextMeshProUGUI crediBeatsAmount, staminaAmount;
    public Image staminaBar;

    public bool itemPurchased = false;

    private void Awake()
    {
        _staminaManager = StaminaManager.instance;
        _currencyManager = CurrencyManager.instance;
        _upgradePointsManager = UpgradePointsManager.instance;
        _sceneManager = SceneManagerr.instance;
    }

    private void Start()
    {
        StaminaBarUpdate();
        staminaAmount.text += ": " + StaminaManager.instance.Stamina.ToString();
        crediBeatsAmount.text = CurrencyManager.instance.Currency.ToString();
    }

    /*private void Update()
    {
        crediBeatsAmount.text = GameManager.Instance.currency.ToString();
        if (_currentStm != GameManager.Instance.stamina)
        {
            _currentStm = GameManager.Instance.stamina;
            staminaAmount.text.Replace(GameManager.Instance.stamina.ToString(), _currentStm.ToString());
        }
    }*/


    public void TryPlayLevel(string levelName)
    {
        if (_staminaManager.Stamina <= 0) return;
        _staminaManager.ConsumeStamina();
        Debug.Log("Consumio estamina");
        _sceneManager.PlayLevel(levelName);
        Debug.Log("Entró al nivel");
        StaminaBarUpdate();
    }

    public void BuyItem(int cost)
    {
        if (CurrencyManager.instance.Currency < cost) return;
        itemPurchased = true;
        _currencyManager.SpentCurrency(cost);
        crediBeatsAmount.text = CurrencyManager.instance.Currency.ToString();
    }

    public void DisableItemPurchased(Button boton)
    {
        if (!itemPurchased) return;
        boton.interactable = false;
    }

    public void BuyUpgrade(int cost)
    {
        _upgradePointsManager.SpentUP(cost);
    }

    public void StaminaBarUpdate()
    {
        var updatedStaminaAmount = (float)_staminaManager.Stamina / (float)_staminaManager.MaxStamina;
        staminaBar.fillAmount = updatedStaminaAmount;
    }

    public void QuitGame()
    {
        GameManager.Instance.SavePlayerPrefs();
        Application.Quit();
    }

    public void ResetData()
    {
        GameManager.Instance.ResetProgress();
    }
}
