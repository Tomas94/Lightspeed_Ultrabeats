using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public Action OnWaveCompleted;
    [SerializeField] List<string> _enemyTypes;
    [SerializeField] int _activeEnemies = 0;

    private void Start()
    {
        StartCoroutine(FirstWave());
    }

    public void CreateWave()
    {
        int _enemiesAmount = UnityEngine.Random.Range(1, 7);
        _activeEnemies = _enemiesAmount;

        List<Enemy> _enemiesSpawned = new List<Enemy>();
        List<Transform> _spawnPoints = GetSpawnPoints(this.transform);

        Debug.Log("Cantidad de enemigos: " + _enemiesAmount);

        for (int i = 0; i < _enemiesAmount; i++)
        {
            // índice de spawn aleatorio
            int spawnIndex = UnityEngine.Random.Range(0, _spawnPoints.Count);

            // tipo de enemigo aleatorio de la lista _enemyTypes
            string randomEnemyType = _enemyTypes[UnityEngine.Random.Range(0, _enemyTypes.Count)];

            // Crea el enemigo en el punto de spawn aleatorio
            Enemy enemigoNuevo = SpawnEnemy(randomEnemyType, _spawnPoints[spawnIndex].position);
            _enemiesSpawned.Add(enemigoNuevo);
            _spawnPoints.RemoveAt(spawnIndex);
        }

        //Debug.Log("Cantidad de enemigos activados: " + _enemiesSpawned.Count);

        foreach (var item in _enemiesSpawned)
        {
            if (item.OnDesactivar != null) continue;
            item.OnDesactivar += WaveController;
        }
    }

    void WaveController()
    {
        _activeEnemies -= 1;

        if (_activeEnemies <= 0)
        {
            OnWaveCompleted?.Invoke();
            CreateWave();
        }
    }

    public Enemy SpawnEnemy(string enemy, Vector3 pos)
    {
        ObjectPool<Enemy> pool;

        pool = EnemyToSpawn(enemy);

        var x = pool.Get();
        x.Initialize(pool);
        x.outOfScreen = false;
        x.transform.position = pos;
        x.transform.forward = Vector3.down;
        return x;
    }

    List<Transform> GetSpawnPoints(Transform parent)
    {
        var allPoints = new List<Transform>();

        foreach (Transform child in parent)
        {
            allPoints.Add(child);
        }

        return allPoints;
    }

    public ObjectPool<Enemy> EnemyToSpawn(string enemy)
    {
        ObjectPool<Enemy> pool;

        switch (enemy)
        {
            case "caza":
                return pool = OP_EnemyManager.Instance.enemyPools[0].pool;
            case "kamikaze":
                return pool = OP_EnemyManager.Instance.enemyPools[1].pool;
            default:
                Debug.Log("no pick enemigo");
                return null;
        }
    }

    IEnumerator FirstWave()
    {
        yield return new WaitForSeconds(1f);
        CreateWave();
    }
}
