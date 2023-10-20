using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //public List<OP_>
    //[SerializeField] OP_Enemy _enemyOP;
    //[SerializeField] OP_EnemyManager _enemy;
    [SerializeField] float _enemySpeed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnEnemy("caza");  
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SpawnEnemy("kamikaze");
        }
    }

    public void SpawnEnemy(string enemy)
    {
        ObjectPool<Enemy> pool;

        switch (enemy)
        {
            case "caza":
                pool = OP_EnemyManager.Instance._cazadorPool;
                break;
            case "kamikaze":
                pool = OP_EnemyManager.Instance._kamikazePool;
                break;
            default: 
                return;
        }

        var x = pool.Get();
        x.Initialize(pool);
        x.outOfScreen = false;
        x.transform.position = transform.position;
        //x.transform.forward = Vector2.down;
        x.transform.rotation = Quaternion.Euler(90,180,0);
    }
}
