using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OP_Bullet : MonoBehaviour
{
    [SerializeField] int _initialAmount;
    public Bullet _playerBulletPrefab;
    Factory<Bullet> _bulletFactory;
    public ObjectPool<Bullet> _bulletPool;

    private void Start()
    {
        _bulletFactory = new Factory<Bullet>(_playerBulletPrefab);
        _bulletPool = new ObjectPool<Bullet>(_bulletFactory.GetObject, _playerBulletPrefab.TurnOff, _playerBulletPrefab.TurnOn, _initialAmount);
    }
}
