using UnityEngine;

public class ClearCondition : MonoBehaviour
{
    [SerializeField] EnemyWaveSpawner enemWS;
    public int completedWaves;
    public int wavesGoal;

    private void Awake()
    {
        completedWaves = -1;
        if (wavesGoal == 0) wavesGoal = Random.Range(5, 10);
    }

    private void Start()
    {
        enemWS.OnWaveCompleted += WavesCompleted;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) completedWaves++;

       // killCount = GameManager.Instance.killcount;

        if (completedWaves >= wavesGoal)
        {
            ScoreManager.Instance._levelScore.SubmitScore();
            SceneManager.ToMainMenu();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ScoreManager.Instance._levelScore.SubmitScore();
            SceneManager.ToMainMenu();
        }
    }
    
    public void WavesCompleted()
    {
        completedWaves++;
        Debug.Log("Empieza la Wave " + completedWaves);
    }

}
