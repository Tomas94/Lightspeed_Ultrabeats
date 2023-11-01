using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }
}
