using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OP_Pickables : MonoBehaviour
{
    public static OP_Pickables Instance;
    public List<ObjectsPoolElements<Pickable>> pickablePools;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        pickablePools = CreateEnemyFactoryAndPool(pickablePools);
    }

    public List<ObjectsPoolElements<Pickable>> CreateEnemyFactoryAndPool(List<ObjectsPoolElements<Pickable>> pools)
    {
        List<ObjectsPoolElements<Pickable>> updatedPools = new List<ObjectsPoolElements<Pickable>>();

        for (int i = 0; i < pools.Count; i++)
        {
            ObjectsPoolElements<Pickable> currentPool = pools[i];

            currentPool.factory = new Factory<Pickable>(currentPool.prefab);
            currentPool.pool = new ObjectPool<Pickable>(currentPool.factory.GetObject, currentPool.prefab.TurnOff, currentPool.prefab.TurnOn, currentPool.initAmount);

            updatedPools.Add(currentPool);
        }
        return updatedPools;
    }
}
