using System;
using UnityEngine;

public abstract class Enemy : Entity, IPooleableObject<Enemy>
{
    [SerializeField] protected float _lifeModifyer;
    [SerializeField] protected float _fireRateModifyer;
    [HideInInspector] public bool outOfScreen;
    ObjectPool<Enemy> _enemyPool;

    public Action OnDesactivar;
    public Player _player;

    public void Initialize(ObjectPool<Enemy> op) => _enemyPool = op;

    protected void Start()
    {
        _player = OP_EnemyManager.Instance.player;
    }


    public override void Disparar(int _bulletIndex)
    {
        var x = OP_BulletManager.Instance.bulletPools[_bulletIndex].pool.Get();
        x.Initialize(OP_BulletManager.Instance.bulletPools[_bulletIndex].pool);
        x.transform.position = transform.position;
        x.transform.forward = transform.forward;
    }

    public override void Die(int deathPoints)
    {
        ScoreManager.Instance.IncrementKillScore(deathPoints);
        _player.RechargeWaveAttack();
        SpawnItem();
        RefillStock(this);
    }

    public void SpawnItem()
    {
        float randomNumber = UnityEngine.Random.Range(0,100);
        print(randomNumber.ToString());
        int itemIndex = -1;
        if (randomNumber < 10) itemIndex = 0;
        if (randomNumber > 85) itemIndex = 1;
        if (itemIndex < 0) return;

        var item = OP_Pickables.Instance.pickablePools[itemIndex].pool.Get();
        item.Initialize(OP_Pickables.Instance.pickablePools[itemIndex].pool);
        item.transform.position = transform.position;
        //item.transform.forward = transform.forward;
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
            other.GetComponent<Player>()?.TakeDamage(Fw_Pointer.AllEnemiesID.impactDamage * OP_EnemyManager.Instance._enemyStatsMultiplyer);
            RefillStock(this);
        }
    }
}