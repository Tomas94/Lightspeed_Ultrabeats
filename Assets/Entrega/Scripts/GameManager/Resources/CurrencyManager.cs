using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    Currency _gameCurrency = new Currency(0);

    void Start()
    {
        Debug.Log("Currency total: " + SaveSystem._saveData.currency);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            _gameCurrency.GainResource(200);
            Debug.Log("Currency total: " + SaveSystem._saveData.currency);
        }
    }
}
