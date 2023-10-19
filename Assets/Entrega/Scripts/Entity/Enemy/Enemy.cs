using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : Entity, IPooleableObject<Enemy>
{
    ObjectPool<Enemy> _enemyPool;

    [HideInInspector] public bool outOfScreen;
    
    public void Initialize(ObjectPool<Enemy> op)
    {
        _enemyPool = op;
    }

    public virtual void Update()
    {
        Die();
    }

    public override void Disparar()
    {
        var x = OP_BulletManager._enemyBulletPool.Get();
        x.Initialize(OP_BulletManager._enemyBulletPool);
        x.transform.position = transform.position;
        x.transform.forward = transform.forward;
    }
    
    public override void Die()
    {
        if (currentLife <= 0 || outOfScreen)
        {
            _enemyPool?.RefillStock(this);
        }
    }

    public virtual void TurnOn(Enemy x)
    {
        x.gameObject.SetActive(true);
    }
    
    public virtual void TurnOff(Enemy x)
    {
        x.gameObject.SetActive(false);
    }
    
    public void RefillStock(Enemy enemy)
    {
        _enemyPool?.RefillStock(enemy);
    }

    protected void SetLife(float maxLife)
    {
        currentLife = maxLife;
    }

    protected void ResetMaxLife(Enemy enemy ,float maxLife)
    {
        enemy.currentLife = maxLife;
    } 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ResetTrigger")) outOfScreen = true;

        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.TakeDamage(Fw_Pointer.AllEnemiesID.impactDamage);
            RefillStock(this);
        }
    }
}
