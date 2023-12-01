using UnityEngine;

public class Score
{
    public int timeScore, killScore, totalScore;

    public Score(int _initialScore)
    {
        totalScore = _initialScore;
    }

    public void IncrementScore(float time) => timeScore = (int)time;

    public void IncrementScore(int value) => killScore += value;

    public void TotalScore() => totalScore = timeScore + killScore;

    public void SubmitScore() => GameManager.Instance.levelScore = totalScore;

    public void ResetScore()
    {
        timeScore = 0;
        killScore = 0;
        totalScore = 0;
    }
}
