using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timeToRefill = 15;
    public float remainingTime;
    public GameObject _timerCanvas;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(this);
        DontDestroyOnLoad(this);

        remainingTime = timeToRefill;
        //_timerCanvas.SetActive(true);
        //    public GameObject _timerCanvas;
    }

    void Update()
    {
        while (StaminaManager.instance.Stamina < StaminaManager.instance.MaxStamina)
        {
            remainingTime -= Time.deltaTime;
            if(remainingTime <= 0)
            {
                StaminaManager.instance.RechargeStamina();
                remainingTime = timeToRefill;
            }
        }
        //_timerCanvas.SetActive(true);

        //if (_gameManager.stamina == 5)
        //{
        //    _timerCanvas.SetActive(false);
        //}

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}