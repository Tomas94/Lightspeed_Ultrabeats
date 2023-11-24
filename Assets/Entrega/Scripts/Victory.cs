using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public int killCount;
    public int neededKills = 2;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) killCount++;

       // killCount = GameManager.Instance.killcount;

        if (killCount >= neededKills)
        {
            //GameManager.Instance._gameCurrency.GainResource(GameManager.Instance._levelScore.totalScore);
         //   GameManager.Instance.killcount = 0;
            SceneManager.ToMainMenu();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ScoreController.Instance._levelScore.SubmitScore();
            SceneManager.ToMainMenu();
        }
    }
}
