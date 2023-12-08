using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public string contador;
    [SerializeField] float timeToRefill = 15;
    public float remainingTime;
    public bool recharging = false;


    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        DontDestroyOnLoad(this);

        remainingTime = timeToRefill;
    }

    void Update()
    {
        if (StaminaManager.instance.Stamina < StaminaManager.instance.MaxStamina && recharging == false)
        {
            StartCoroutine(RechargeStamina());
        }


        
    }

    IEnumerator RechargeStamina()
    {
        recharging = true;
        while (StaminaManager.instance.Stamina < StaminaManager.instance.MaxStamina)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime <= 0)
            {
                StaminaManager.instance.RechargeStamina();
                yield return new WaitForEndOfFrame();
                remainingTime = timeToRefill;
            }
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            contador = string.Format("{0:00}:{1:00}", minutes, seconds);
            yield return null;
        }
        recharging = false;
    }
}