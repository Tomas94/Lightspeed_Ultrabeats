using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    void Update()
    {
        Die();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
    }

    public override void Disparar()
    {
        var x = OP_BulletManager._playerBulletPool.Get();
        x.Initialize(OP_BulletManager._playerBulletPool, _bulletSpeed);
        x.transform.position = transform.position;
        x.transform.forward = transform.forward;
    }

    public override void Die()
    {
        if(currentLife<=0)
        {
            SceneChanger.ResetGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.RefillStock(enemy);
            TakeDamage();
        }
    }
}