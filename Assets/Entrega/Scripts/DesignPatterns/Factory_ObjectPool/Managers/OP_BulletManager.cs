using System.Collections.Generic;
using UnityEngine;

public class OP_BulletManager : MonoBehaviour
{
    public static OP_BulletManager Instance;
    public List<ObjectsPoolElements<Bullet>> bulletPools;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        bulletPools = CreateEnemyFactoryAndPool(bulletPools);
    }

    public List<ObjectsPoolElements<Bullet>> CreateEnemyFactoryAndPool(List<ObjectsPoolElements<Bullet>> pools)
    {
        List<ObjectsPoolElements<Bullet>> updatedPools = new List<ObjectsPoolElements<Bullet>>();

        for (int i = 0; i < pools.Count; i++)
        {
            ObjectsPoolElements<Bullet> currentPool = pools[i];

            currentPool.factory = new Factory<Bullet>(currentPool.prefab);
            currentPool.pool = new ObjectPool<Bullet>(currentPool.factory.GetObject, currentPool.prefab.TurnOff, currentPool.prefab.TurnOn, currentPool.initAmount);

            updatedPools.Add(currentPool);
        }
        return updatedPools;
    }
}
