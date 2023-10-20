using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score;
    void Start()
    {
       GameManager.instance._gameCurrency.GainResource(score);
    }

    void Update()
    {
        
    }
}
