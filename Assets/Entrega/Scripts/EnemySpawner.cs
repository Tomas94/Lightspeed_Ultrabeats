using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<Transform> _spawnPoints;
    [SerializeField] List<string> _enemyTypes;

    private void Awake()
    {
        _spawnPoints = GetSpawnPoints();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            CreateWave();
            //SpawnEnemy("caza");  
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //SpawnEnemy("kamikaze");
        }
    }

    List<Transform> GetSpawnPoints()
    {
        var allPoints = new List<Transform>();
        allPoints.Add(this.GetComponentInChildren<Transform>());
        return allPoints;
    }




    public void CreateWave()
    {
        int _enemiesAmount = Random.Range(0, 15);
        Debug.Log("cantidad de enemigos " + _enemiesAmount);
        var _enemyWave = new Enemy[_enemiesAmount];

        foreach (var enemy in _enemyWave)
        {
            var indice = 0;
            SpawnEnemy(_enemyTypes[Random.Range(0, _enemyTypes.Count + 1)], _spawnPoints[indice].position);
            Debug.Log("se creo el enemigo " + indice + 1);
            indice++;
        }

    }

    public void SpawnEnemy(string enemy, Vector3 pos)
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
        x.transform.forward = Vector3.down;
        x.transform.rotation = Quaternion.Euler(90,180,0);
    }
}
