using UnityEngine;

public class ClearCondition : MonoBehaviour
{
    public int completedWaves = 0;
    public int wavesGoal;

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
}
