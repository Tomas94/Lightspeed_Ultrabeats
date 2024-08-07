using UnityEngine;

public class Kamikaze : Enemy
{
    Vector3 dir;
    
    public bool variant;
    [SerializeField] float _variantSpeedModifyer;

    [SerializeField] bool _playerPassed;

    public void Update()
    {
        KamikazeAttackMovement();
    }

    void KamikazeAttackMovement()
    {
        if (_player == null) return;

        Vector3 playerPosition = _player.transform.position;
        float distanceToPlayer = Vector3.Distance(playerPosition, transform.position);

        if (distanceToPlayer > Fw_Pointer.EnemyKamikazeSC.stopChasingDistance && !_playerPassed)
        { dir = playerPosition - transform.position; }
        else _playerPassed = true;

        if (variant)
        {
            transform.position += Fw_Pointer.EnemyKamikaze.speed * _variantSpeedModifyer * Time.deltaTime * dir.normalized;
        }
        else
        {
            transform.position += Fw_Pointer.EnemyKamikaze.speed * Time.deltaTime * dir.normalized;
        }
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (currentLife <= 0) Die(Random.Range(20, 40));
    }

    public override void TurnOff(Enemy x)
    {
        base.TurnOff(x);
        ResetMaxLife(x, Fw_Pointer.EnemyKamikaze.maxLife);
    }

    private void OnDisable() => _playerPassed = false;

    private void OnEnable()
    {
        SetLife(Fw_Pointer.EnemyKamikaze.maxLife + (Fw_Pointer.EnemyKamikaze.maxLife * OP_EnemyManager.Instance._enemyStatsMultiplyer * _lifeModifyer));
    }
}