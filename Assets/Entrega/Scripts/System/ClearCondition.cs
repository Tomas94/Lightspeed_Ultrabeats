using UnityEngine;
using TMPro;

public class ClearCondition : MonoBehaviour
{
    [SerializeField] EnemyWaveSpawner enemWS;
    [SerializeField] GameObject _victoryScreen;
    [SerializeField] Player _player;
    [SerializeField] TextMeshProUGUI totalScore;

    [SerializeField] AudioClip _playerWinSound;
    [SerializeField] AudioSource audioSource;

    public int completedWaves;
    public int wavesGoal;
    public int currentLevel;

    private void Awake()
    {
        completedWaves = 0;
        if (wavesGoal == 0) wavesGoal = Random.Range(5, 10);
    }

    private void Start()
    {
        Time.timeScale = 1f;
        enemWS.OnWaveCompleted += WavesCompleted;
        if (currentLevel == 0) SceneManagerr.Pause();
    }

    private void Update()
    {
        if (completedWaves >= wavesGoal)
        {
            VictoryScreen();
        }
    }

    void VictoryScreen()
    {
        if (GameManager.instance.levelsUnlock == currentLevel) GameManager.instance.levelsUnlock += 1;
        PlayerPrefs.Save();
        _victoryScreen.SetActive(true);
        SceneManagerr.Pause();
        totalScore.text = ScoreManager.Instance.SubmitScore().ToString();
        _player.gameObject.SetActive(false);
    }

    public void PlayWinSound()
    {
        audioSource.PlayOneShot(_playerWinSound);
    }

    public void WavesCompleted()
    {
        completedWaves++;
        Debug.Log("Empieza la Wave " + completedWaves);
    }

}
