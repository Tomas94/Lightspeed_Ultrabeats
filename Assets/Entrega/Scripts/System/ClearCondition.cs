using UnityEngine;
using TMPro;

public class ClearCondition : MonoBehaviour
{
    [SerializeField] EnemyWaveSpawner enemWS;
    public int completedWaves;
    public int wavesGoal;
    [SerializeField] GameObject _victoryScreen;
    [SerializeField] Player _player;
    [SerializeField] TextMeshProUGUI totalScore;
    private void Awake()
    {
        completedWaves = 0;
        if (wavesGoal == 0) wavesGoal = Random.Range(5, 10);
    }

    private void Start()
    {
        enemWS.OnWaveCompleted += WavesCompleted;
    }

    private void Update()
    {
        if (completedWaves >= wavesGoal) VictoryScreen();

    }

    void VictoryScreen()
    {
        _victoryScreen.SetActive(true);
        SceneManagerr.Pause();
        totalScore.text = ScoreManager.Instance.SubmitScore().ToString();
        _player.gameObject.SetActive(false);
    }

    public void WavesCompleted()
    {
        completedWaves++;
        Debug.Log("Empieza la Wave " + completedWaves);
    }

}
