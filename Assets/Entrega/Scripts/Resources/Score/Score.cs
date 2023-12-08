using UnityEngine;

public class Score
{
    public int timeScore, killScore, totalScore;

    public Score(int _initialScore)
    {
        totalScore = _initialScore;
    }

    public int IncrementScore(float time) => timeScore = (int)time;

    public int IncrementScore(int value) => killScore += value;

    public int TotalScore() => totalScore = timeScore + killScore;

    public int SubmitScore() => totalScore;

    public void ResetScore() => (timeScore, killScore, totalScore) = (0, 0, 0);
}
