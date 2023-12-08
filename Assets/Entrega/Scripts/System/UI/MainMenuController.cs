using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MonoBehaviour
{

   [SerializeField] StaminaManager _staminaManager;
   [SerializeField] CurrencyManager _currencyManager;
   [SerializeField] UpgradePointsManager _upgradePointsManager;
   [SerializeField] SceneManagerr _sceneManager;

    public TextMeshProUGUI crediBeatsAmount, staminaAmount;
    public Image staminaBar;

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
        //staminaAmount.text += ": " + GameManager.Instance.stamina.ToString();
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
        _currencyManager.SpentCurrency(cost);
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
        Application.Quit();
    }
}
