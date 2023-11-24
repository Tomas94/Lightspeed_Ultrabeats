using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{

    //[SerializeField] List<Transform> _spawnPoints;
    [SerializeField] List<string> _enemyTypes;
    [SerializeField] List<Enemy> _enemiesSpawned;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            CreateWave();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {

        }
    }

    public void CreateWave()
    {
        var _spawnPoints = GetSpawnPoints(this.transform);
        
        int _enemiesAmount = Random.Range(1, 14);
        Debug.Log("Cantidad de enemigos: " + _enemiesAmount);

        for (int i = 0; i < _enemiesAmount; i++)
        {
            // índice de spawn aleatorio
            int spawnIndex = Random.Range(0, _spawnPoints.Count);

            // tipo de enemigo aleatorio de la lista _enemyTypes
            string randomEnemyType = _enemyTypes[Random.Range(0, _enemyTypes.Count)];

            // Crea el enemigo en el punto de spawn aleatorio
            SpawnEnemy(randomEnemyType, _spawnPoints[spawnIndex].position);
            _spawnPoints.RemoveAt(spawnIndex);

            //Debug.Log("Se creó el enemigo " + (i + 1) + " en el punto de spawn " + (spawnIndex + 1) + " y la ubicacion " + _spawnPoints[spawnIndex].position);
        }
        _enemiesSpawned.AddRange(FindObjectsOfType<Enemy>());
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
        x.transform.position = pos;
        x.transform.forward = Vector3.down;
        x.transform.rotation = Quaternion.Euler(90,180,0);
        _enemiesSpawned.Add(x);
    }
    
    /*IEnumerator WaveSpawnCD()
    {

    }*/


    List<Transform> GetSpawnPoints(Transform parent)
    {
        var allPoints = new List<Transform>();

        foreach (Transform child in parent)
        {
            allPoints.Add(child);

            allPoints.AddRange(GetSpawnPoints(child));
        }

        return allPoints;
    }
}
