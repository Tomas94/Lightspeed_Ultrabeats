using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : Entity, IPooleableObject<Enemy>
{
    ObjectPool<Enemy> _enemyPool;

    public float _speed;
    [HideInInspector] public bool outOfScreen;

    public void Initialize(ObjectPool<Enemy> op, float speed)
    {
        _enemyPool = op;
        _speed = speed;
    }

    private void Start()
    {
        currentLife = maxLife;
    }

    public void Die()
    {
        if (currentLife <= 0 || outOfScreen)
        {
            _enemyPool?.RefillStock(this);
        }
    }

    public void TurnOff(Enemy x)
    {
        x.gameObject.SetActive(false);
        x.currentLife = maxLife;
    }

    public void TurnOn(Enemy x)
    {
        x.gameObject.SetActive(true);
    }

    public override void Disparar()
    {
        Debug.Log("se crea una bala");
        var x = OP_BulletManager._enemyBulletPool.Get();
        x.Initialize(OP_BulletManager._enemyBulletPool, _bulletSpeed);
        x.transform.position = transform.position;
        x.transform.forward = transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ResetTrigger")) outOfScreen = true;
    }
}
