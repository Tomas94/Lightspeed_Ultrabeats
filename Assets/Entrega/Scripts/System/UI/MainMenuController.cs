using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    StaminaManager _staminaManager;
    _currencyManager _currencyManager;
    UpgradePointsManager _upgradePointsManager;
    SceneManagerr _sceneManager;

    public TextMeshProUGUI crediBeatsAmount, staminaAmount;
    public Image staminaBar;

    public bool itemPurchased = false;

    private void Awake()
    {
        _staminaManager = StaminaManager.instance;
        _currencyManager = _currencyManager.instance;
        _upgradePointsManager = UpgradePointsManager.instance;
        _sceneManager = SceneManagerr.instance;
    }

    private void Start()
    {
        StaminaBarUpdate();
        staminaAmount.text += ": " + _staminaManager.Stamina.ToString();
        crediBeatsAmount.text = _currencyManager.Currency.ToString();
    }

    public void TryPlayLevel(string levelName)
    {
        if (_staminaManager.Stamina <= 0) return;
        _staminaManager.ConsumeStamina();
        Debug.Log("Consumio estamina");
        _sceneManager.PlayLevel(levelName);
        Debug.Log("Entró al nivel");
        StaminaBarUpdate();
    }

    #region Funciones Relacionadas a Compra de Objetos
    public void BuyItem(int cost)
    {
        if (_currencyManager.Currency < cost) return;
        itemPurchased = true;
        _currencyManager.SpentCurrency(cost);
        crediBeatsAmount.text = _currencyManager.Currency.ToString();
    }

    public void BuyUpgrade(int cost)
    {
        _upgradePointsManager.SpentUP(cost);
    }

    public void DisableItemPurchased(Button boton)
    {
        if (!itemPurchased) return;
        boton.interactable = false;
    }
    #endregion

    public void TryRefillStaminaPaid(int cost)
    {
        if (_currencyManager.Currency < cost && _staminaManager.Stamina >= _staminaManager.MaxStamina) return;
        _currencyManager.SpentCurrency(cost);
        _staminaManager.RefillStamina();
    }

    public void TryBuyUpgradePieces(int cost)
    {
        if(_currencyManager.Currency < cost) return;
        _currencyManager.SpentCurrency(cost);
        _upgradePointsManager.GainUP(20);
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
