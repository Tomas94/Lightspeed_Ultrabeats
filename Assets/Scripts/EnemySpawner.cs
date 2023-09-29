using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] OP_Enemy _enemyOP;
    [SerializeField] float _enemySpeed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnEnemy();            
        }
    }

    public void SpawnEnemy()
    {
        var x = _enemyOP._EnemyPool?.Get();
        x.Initialize(_enemyOP._EnemyPool, _enemySpeed);
        x.outOfScreen = false;
        x.transform.position = transform.position;
        x.transform.forward = Vector3.down;
    }

}
