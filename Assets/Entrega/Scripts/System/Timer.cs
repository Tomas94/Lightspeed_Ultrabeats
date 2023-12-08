using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float timeToRefill = 5;
    public float remainingTime;
    public GameObject _timerCanvas;

    void awake()
    {
        remainingTime = timeToRefill;
        //_timerCanvas.SetActive(true);
        //    public GameObject _timerCanvas;
    }

    void Update()
    {
        //_timerCanvas.SetActive(true);

        //if (_gameManager.stamina == 5)
        //{
        //    _timerCanvas.SetActive(false);
        //}

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = timeToRefill;
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}