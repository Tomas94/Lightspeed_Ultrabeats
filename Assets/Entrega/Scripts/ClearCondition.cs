using UnityEngine;

public class ClearCondition : MonoBehaviour
{
    [SerializeField] EnemyWaveSpawner enemWS;
    public int completedWaves;
    public int wavesGoal;
    [SerializeField] GameObject _victoryScreen;
    [SerializeField] Player _player;
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
        if (Input.GetKeyDown(KeyCode.T)) completedWaves++;

        // killCount = GameManager.Instance.killcount;

        if (completedWaves >= wavesGoal)
        {
            VictoryScreen();
            wavesGoal += 10;
            //SceneManager.ToMainMenu();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ScoreManager.Instance._levelScore.SubmitScore();
            SceneManagerr.ToMainMenu();
        }
    }

    void VictoryScreen()
    {
        ScoreManager.Instance._levelScore.SubmitScore();
        _victoryScreen.SetActive(true);
        SceneManagerr.Pause();
        _player.gameObject.SetActive(false);
    }

    public void WavesCompleted()
    {
        completedWaves++;
        Debug.Log("Empieza la Wave " + completedWaves);
    }

}
