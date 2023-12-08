using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    public void BuyItem(int cost)
    {
        _currencyManager.instance.SpentCurrency(cost);
        //Debug.Log("Current Currency: " + GameManager.Instance.currency);
    }
}
