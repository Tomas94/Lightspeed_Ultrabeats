using System;
using UnityEngine;

public abstract class Enemy : Entity, IPooleableObject<Enemy>
{
    public Action OnDesactivar;
    ObjectPool<Enemy> _enemyPool;

    [HideInInspector] public bool outOfScreen;

    public void Initialize(ObjectPool<Enemy> op) => _enemyPool = op;

    public override void Disparar()
    {
        var x = OP_BulletManager.Instance.bulletPools[1].pool.Get();
        x.Initialize(OP_BulletManager.Instance.bulletPools[1].pool);
        x.transform.position = transform.position;
        x.transform.forward = transform.forward;
    }

    public override void Die(int deathPoints)
    {
        ScoreManager.Instance.IncrementKillScore(deathPoints);
        RefillStock(this);
    }

    public void RefillStock(Enemy enemy)
    {
        _enemyPool?.RefillStock(enemy);
        OnDesactivar?.Invoke();
    }

    public virtual void TurnOn(Enemy x) => x.gameObject.SetActive(true);

    public virtual void TurnOff(Enemy x) => x.gameObject.SetActive(false);

    protected void SetLife(float maxLife) => currentLife = maxLife;

    protected void ResetMaxLife(Enemy enemy, float maxLife) => enemy.currentLife = maxLife;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.CompareTag("ResetTrigger"))
        {
            other.GetComponent<Player>()?.TakeDamage(Fw_Pointer.AllEnemiesID.impactDamage);
            RefillStock(this);
        }
    }
}