using System.Collections;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    Score _gameScore;

    [SerializeField] float timer;
    [SerializeField] float multiplyer;
    int score;
    bool _isPlaying;

    public int Score { get { return score; } }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        Initialize();
    }
    private void Start() => StartCoroutine(TimeScore());

    private void Update() => score = _gameScore.TotalScore();

    void Initialize()
    {
        _gameScore = new Score(0);
        score = _gameScore.totalScore;
    }

    public void IncrementKillScore(int killScore) => _gameScore.IncrementScore(killScore);

    IEnumerator TimeScore()
    {
        while (_isPlaying)
        {
            timer += (Time.deltaTime * multiplyer);
            _gameScore.IncrementScore(timer);
            yield return null;
        }
    }

    public int SubmitScore()
    {
        return _gameScore.SubmitScore();
    }

    public void GainResources()
    {
        CurrencyManager.instance.GainCurrency(score);
        UpgradePointsManager.instance.GainUP(score);
    }

}
