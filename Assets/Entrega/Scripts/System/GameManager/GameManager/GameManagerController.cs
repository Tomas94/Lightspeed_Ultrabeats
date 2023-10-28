using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    public void ConsumeStamina()
    {
        gameManager._gamestamina.ConsumeStamina();
    }
    public void RechargeStamina()
    {
        gameManager._gamestamina.RechargeStamina();
    }
    public void RefillStamina()
    {
        gameManager._gamestamina.RefillStamina();
    }
}
