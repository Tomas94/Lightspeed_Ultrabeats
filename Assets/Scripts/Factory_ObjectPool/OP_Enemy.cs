using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OP_Enemy : MonoBehaviour
{
    [SerializeField] int _initialAmount;
    [SerializeField] Enemy _enemyPrefab;
    Factory<Enemy> _EnemyFactory;
    public ObjectPool<Enemy> _EnemyPool;

    private void Start()
    {
        _EnemyFactory = new Factory<Enemy>(_enemyPrefab);
        _EnemyPool = new ObjectPool<Enemy>(_EnemyFactory.GetObject, _enemyPrefab.TurnOff, _enemyPrefab.TurnOn, _initialAmount);
    }
}
