using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public MainMenuController _mainMenuController;
    [SerializeField] SkinController skinCtrl;
    [SerializeField] ScreenController _confirmWindow;

    [SerializeField] List<Button> _items = new List<Button>();
    Dictionary<string, (int index, int price)> _storeItems = new Dictionary<string, (int, int)>();

    string _selectedItem;

    private void Start()
    {
        LoadStoreItems();
    }

    private void LoadStoreItems()
    {
        _storeItems.Add("Floppa", (1, 10000));
        _storeItems.Add("Princess", (2, 912));
        _storeItems.Add("Semitono", (3, 0));
    }

    public void CheckSkinPurchased()
    {
        Debug.Log("Entrando tienda");
        for (int i = 1; i < GameManager.Instance.skinavailable.Count; i++)
        {
            if (GameManager.Instance.skinavailable[i] == true)
            {
                _items[i - 1].interactable = false;
            }
        }
    }

    public void CompleteBuyOperation()
    {
        BuyItem(_storeItems[_selectedItem].price);
        skinCtrl.UnlockSkin(_storeItems[_selectedItem].index);
        CheckSkinPurchased();
        _confirmWindow.Desactivate();
    }

    public void BuyItem(int cost)
    {
        CurrencyManager.instance.SpentCurrency(cost);
        _mainMenuController.crediBeatsAmount.text = CurrencyManager.instance.Currency.ToString();
    }

    public void CheckIfCanBuy(string itemName)
    {
        if (CurrencyManager.instance.Currency < _storeItems[itemName].price) return;

        _confirmWindow.Activate();
        _selectedItem = itemName;
    }

    public IEnumerator UpdatePurchased()
    {
        yield return new WaitForEndOfFrame();
        CheckSkinPurchased();
    }

    private void OnEnable()
    {
        StartCoroutine(UpdatePurchased());
    }
}
