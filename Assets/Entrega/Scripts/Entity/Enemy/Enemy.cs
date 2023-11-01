using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Entity, IPooleableObject<Enemy>
{
    ObjectPool<Enemy> _enemyPool;

    [HideInInspector] public bool outOfScreen;

    public void Initialize(ObjectPool<Enemy> op)
    {
        _enemyPool = op;
    }

    public override void Disparar()
    {
        var x = OP_BulletManager._enemyBulletPool.Get();
        x.Initialize(OP_BulletManager._enemyBulletPool);
        x.transform.position = transform.position;
        x.transform.forward = transform.forward;
    }

    public override void Die(int deathPoints)
    {
        ScoreController.Instance._levelScore.IncrementScore(deathPoints);
        //GameManager.Instance.killcount += 1;
        RefillStock(this);
    }

    public void RefillStock(Enemy enemy)
    {
        _enemyPool?.RefillStock(enemy);
    }
    

    public virtual void TurnOn(Enemy x)
    {
        x.gameObject.SetActive(true);
    }

    public virtual void TurnOff(Enemy x)
    {
        x.gameObject.SetActive(false);
    }

    protected void SetLife(float maxLife)
    {
        currentLife = maxLife;
    }

    protected void ResetMaxLife(Enemy enemy, float maxLife)
    {
        enemy.currentLife = maxLife;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ResetTrigger")) RefillStock(this);

        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if(!player._isShielded) player.TakeDamage(Fw_Pointer.AllEnemiesID.impactDamage);
            RefillStock(this);
        }
    }
}
