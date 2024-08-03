using System.Collections.Generic;
using UnityEngine;

public class OP_EnemyManager : MonoBehaviour
{
    public static OP_EnemyManager Instance;
    public List<ObjectsPoolElements<Enemy>> enemyPools;
    public Player player;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        enemyPools = CreateEnemyFactoryAndPool(enemyPools);
    }

    public List<ObjectsPoolElements<Enemy>> CreateEnemyFactoryAndPool(List<ObjectsPoolElements<Enemy>> pools)
    {
        List<ObjectsPoolElements<Enemy>> updatedPools = new List<ObjectsPoolElements<Enemy>>();

        for (int i = 0; i < pools.Count; i++)
        {
            ObjectsPoolElements<Enemy> currentPool = pools[i];

            currentPool.factory = new Factory<Enemy>(currentPool.prefab);
            currentPool.pool = new ObjectPool<Enemy>(currentPool.factory.GetObject, currentPool.prefab.TurnOff, currentPool.prefab.TurnOn, currentPool.initAmount);

            updatedPools.Add(currentPool);
        }
        return updatedPools;
    }
}
