using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public Score _levelScore = new Score(0);
    public float timer;
    public float multiplyer;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        GameManager.Instance.levelScore = 0;
        timer = 0;
    }

    private void Update()
    {
        timer += (Time.deltaTime * multiplyer);
        _levelScore.IncrementScore(timer);
        _levelScore.TotalScore();
    }
}
