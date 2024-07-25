using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


public class MainMenuController : MonoBehaviour
{
    GameManager _gameManager;
    [SerializeField] StaminaManager _staminaManager;
    [SerializeField] CurrencyManager _currencyManager;
    [SerializeField] UpgradePointsManager _upgradePointsManager;
    [SerializeField] SceneManagerr _sceneManager;
    public TextMeshProUGUI contadorTiempo;

    public List<Toggle> levels;
    public TextMeshProUGUI crediBeatsAmount, staminaAmount, upgradePointsAmount;
    public Image staminaBar;

    public bool tutorialPlayed = false;

    private void Awake()
    {
        _staminaManager = StaminaManager.instance;
        _currencyManager = CurrencyManager.instance;
        _upgradePointsManager = UpgradePointsManager.instance;
        _sceneManager = SceneManagerr.instance;
        _gameManager = GameManager.instance;

    }

    private void Start()
    {
        StaminaBarUpdate();
        staminaAmount.text += ": " + _staminaManager.Stamina.ToString();
        crediBeatsAmount.text = _currencyManager.Currency.ToString();
        UpdateAvailableLevels();
        SceneManagerr.Resume();

        if (_gameManager.levelsUnlock == 0) PlayTutorial();
    }

    private void Update()
    {
        UpdateAvailableLevels();
        crediBeatsAmount.text = _currencyManager.Currency.ToString();
        upgradePointsAmount.text = _upgradePointsManager.UpgradePoints.ToString();
        StaminaBarUpdate();

        if (_staminaManager.Stamina == _staminaManager.MaxStamina)
        {
            contadorTiempo.text = "";
            return;
        }
        contadorTiempo.text = Timer.instance.contador;
    }

    public void PlayTutorial()
    {
        _sceneManager.PlayLevel("Level_Tutorial", 0);
    }

    public void UpdateAvailableLevels()
    {
        for (int i = 0; i < GameManager.instance.levelsUnlock; i++)
        {
            //Debug.Log("dentro del for con i = " + i);
            levels[i].interactable = true;
        }
    }

    public void PlayLevelSelected()
    {
        if (_staminaManager.Stamina <= 0) return;
        _staminaManager.ConsumeStamina();
        string levelName = "Level_";

        for (int i = 0; i < levels.Count; i++)
        {
            if (levels[i].isOn)
            {
                levelName += (i + 1).ToString();
                continue;
            }
        }

        Debug.Log("Consumio estamina");
        _sceneManager.PlayLevel(levelName);
        Debug.Log("Entró al nivel");
        StaminaBarUpdate();
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

    public void BuyUpgrade(int cost)
    {
        _upgradePointsManager.SpentUP(cost);
    }

    #endregion


    public void TryRefillStaminaPaid(int cost)
    {
        if (_currencyManager.Currency < cost) return;
        _staminaManager.PayForRecharge();

    }

    public void BuyPoints(int amount)
    {
        if (_currencyManager.Currency < 450) return;
        _upgradePointsManager.GainUPByAds(20);
    }

    public void GainUPAd()
    {
        _upgradePointsManager.GainUPByAds(5);
    }

    public void StaminaBarUpdate()
    {
        var updatedStaminaAmount = (float)_staminaManager.Stamina / (float)_staminaManager.MaxStamina;
        staminaBar.fillAmount = updatedStaminaAmount;
        staminaAmount.text = _staminaManager.Stamina.ToString();
    }

    public void QuitGame()
    {
        GameManager.instance.SavePlayerPrefs();
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    public void ResetData()
    {
        GameManager.instance.ResetProgress();
    }
}
