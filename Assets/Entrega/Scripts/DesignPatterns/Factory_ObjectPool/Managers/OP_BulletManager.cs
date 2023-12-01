using System.Collections.Generic;
using UnityEngine;

public class OP_BulletManager : MonoBehaviour
{
    public static OP_BulletManager instance;

    public static OP_BulletManager Instance;
    public List<ObjectsPoolConstructor<Bullet>> bulletPools;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start() { bulletPools = CreateEnemyFactoryAndPool(bulletPools); }

    public List<ObjectsPoolConstructor<Bullet>> CreateEnemyFactoryAndPool(List<ObjectsPoolConstructor<Bullet>> pools)
    {
        List<ObjectsPoolConstructor<Bullet>> updatedPools = new List<ObjectsPoolConstructor<Bullet>>();

        for (int i = 0; i < pools.Count; i++)
        {
            ObjectsPoolConstructor<Bullet> currentPool = pools[i];

            currentPool.factory = new Factory<Bullet>(currentPool.prefab);
            currentPool.pool = new ObjectPool<Bullet>(currentPool.factory.GetObject, currentPool.prefab.TurnOff, currentPool.prefab.TurnOn, currentPool.initAmount);

            updatedPools.Add(currentPool);
        }
        return updatedPools;
    }
}
