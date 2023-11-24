using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] List<Transform> _spawnPoints;
    [SerializeField] List<string> _enemyTypes;

    private void Awake()
    {
       
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



    /*public void CreateWave()
    {
        int _enemiesAmount = Random.Range(0, 15);
        Debug.Log("cantidad de enemigos " + _enemiesAmount);
        var _enemyWave = new List<Enemy>[_enemiesAmount];

        foreach (var enemy in _enemyWave)
        {
            var indice = 0;
            SpawnEnemy(_enemyTypes[Random.Range(0, _enemyTypes.Count + 1)], _spawnPoints[indice].position);
            Debug.Log("se creo el enemigo " + indice + 1);
            indice++;
        }

    }*/
    public void CreateWave()
    {
        _spawnPoints = GetSpawnPoints(this.transform);
        
        int _enemiesAmount = Random.Range(1, 14);
        Debug.Log("Cantidad de enemigos: " + _enemiesAmount);

        for (int i = 0; i < _enemiesAmount; i++)
        {
            // Obtener un índice de spawn aleatorio
            int spawnIndex = Random.Range(0, _spawnPoints.Count);

            // Obtener un tipo de enemigo aleatorio de la lista _enemyTypes
            string randomEnemyType = _enemyTypes[Random.Range(0, _enemyTypes.Count)];

            // Crear el enemigo en el punto de spawn aleatorio
            SpawnEnemy(randomEnemyType, _spawnPoints[spawnIndex].position);
            _spawnPoints.RemoveAt(spawnIndex);

            //Debug.Log("Se creó el enemigo " + (i + 1) + " en el punto de spawn " + (spawnIndex + 1) + " y la ubicacion " + _spawnPoints[spawnIndex].position);
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
        x.transform.position = pos;
        x.transform.forward = Vector3.down;
        x.transform.rotation = Quaternion.Euler(90,180,0);
    }
}
