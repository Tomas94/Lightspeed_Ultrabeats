using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OP_BulletManager : MonoBehaviour
{
    public static OP_BulletManager instance;

    [Header("PlayerOP")]
    [SerializeField] int _playerInitAmount;
    [SerializeField] Bullet _playerBulletPrefab;
    Factory<Bullet> _playerBulletFactory;
    public static ObjectPool<Bullet> _playerBulletPool;

    [Header("EnemyOP")]
    [SerializeField] int _enemyInitAmount;
    [SerializeField] Bullet _enemyBulletPrefab;
    Factory<Bullet> _enemyBulletFactory;
    public static ObjectPool<Bullet> _enemyBulletPool;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (_playerBulletPrefab != null)
        {
            _playerBulletFactory = new Factory<Bullet>(_playerBulletPrefab);
            _playerBulletPool = new ObjectPool<Bullet>(_playerBulletFactory.GetObject, _playerBulletPrefab.TurnOff, _playerBulletPrefab.TurnOn, _playerInitAmount);
        }
        if (_enemyBulletPrefab != null)
        {
            _enemyBulletFactory = new Factory<Bullet>(_enemyBulletPrefab);
            _enemyBulletPool = new ObjectPool<Bullet>(_enemyBulletFactory.GetObject, _enemyBulletPrefab.TurnOff, _enemyBulletPrefab.TurnOn, _enemyInitAmount);
        }
    }
}
