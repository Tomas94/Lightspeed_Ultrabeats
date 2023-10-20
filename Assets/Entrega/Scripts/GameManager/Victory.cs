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

        killCount = GameManager.instance.killcount;

        if (killCount >= neededKills)
        {
            GameManager.instance._gameCurrency.GainResource(GameManager.instance._levelScore.totalScore);
            GameManager.instance.killcount = 0;
            SceneChanger.ToMainMenu();
        }
    }
}
