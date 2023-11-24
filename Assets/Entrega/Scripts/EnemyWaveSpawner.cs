using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    public Action OnWaveCompleted;
    //[SerializeField] List<Transform> _spawnPoints;
    [SerializeField] List<string> _enemyTypes;
    [SerializeField] int _activeEnemies = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            CreateWave();
        }

        if (_activeEnemies <= 0)
        {
            OnWaveCompleted?.Invoke();
            CreateWave();
        }
    }

    public void CreateWave()
    {
        int _enemiesAmount = UnityEngine.Random.Range(1, 5);
        _activeEnemies = _enemiesAmount;

        List<Enemy> _enemiesSpawned = new List<Enemy>();
        List<Transform> _spawnPoints = GetSpawnPoints(this.transform);
        Debug.Log("Puntos de Spawn: " + _spawnPoints.Count);

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

            Debug.Log("Se creo enemigo N° " + (i+1) + " que es un " + enemigoNuevo.name);

            //Debug.Log("Se creó el enemigo " + (i + 1) + " en el punto de spawn " + (spawnIndex + 1) + " y la ubicacion " + _spawnPoints[spawnIndex].position);
        }

        foreach (Enemy item in _enemiesSpawned)
        {
            if (item.OnDesactivar != null) return;
            item.OnDesactivar += AllDesactivados;
            Debug.Log("Suscrito");
        }
    }

    void AllDesactivados()
    {
        _activeEnemies -= 1;
    }

    public Enemy SpawnEnemy(string enemy, Vector3 pos)
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
                return null;
        }

        var x = pool.Get();
        x.Initialize(pool);
        x.outOfScreen = false;
        x.transform.position = pos;
        x.transform.forward = Vector3.down;
        x.transform.rotation = Quaternion.Euler(90, 180, 0);
        return x;
    }

    List<Transform> GetSpawnPoints(Transform parent)
    {
        var allPoints = new List<Transform>();

        foreach (Transform child in parent)
        {
            allPoints.Add(child);

            //allPoints.AddRange(GetSpawnPoints(child));
        }

        return allPoints;
    }


}
