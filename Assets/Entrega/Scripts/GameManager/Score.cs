using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    public int timeScore;
    public int killScore;
    public int totalScore;
    public int multiplyer = 2;
    public float timer = Time.deltaTime;

    public void IncrementScore(float time)
    {
        timeScore = (int)time * multiplyer;
        //Debug.LogError("puntaje de tiempo: " + timeScore);
    }

    public void IncrementScore(int value)
    {
        killScore += value;
       // Debug.Log("puntaje de kill: " + killScore);
    }

    public void TotalScore()
    {
        totalScore = timeScore + killScore;
        Debug.Log("Puntaje Total: " + totalScore);
    }

    public void ResetScore()
    {
        timeScore = 0;
        killScore = 0;
        totalScore = 0;
    }
}
