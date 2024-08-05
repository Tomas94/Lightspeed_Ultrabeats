using UnityEngine;

public class Caza : Enemy
{

    public void Update()
    {
        Move();
    }

    public void Move() => transform.position += Fw_Pointer.EnemyCaza.speed * Time.deltaTime * transform.forward;

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (currentLife <= 0) Die(Random.Range(50, 60));
    }

    public override void TurnOn(Enemy x)
    {
        base.TurnOn(x);
    }

    public override void TurnOff(Enemy x)
    {
        base.TurnOff(x);
        StopAllCoroutines();
        //ResetMaxLife(x, Fw_Pointer.EnemyCaza.maxLife + (Fw_Pointer.EnemyCaza.maxLife * OP_EnemyManager.Instance._enemyStatsMultiplyer * _lifeModifyer));
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnEnable()
    {
        _lifeModifyer = 0.7f;
        SetLife(Fw_Pointer.EnemyCaza.maxLife + (Fw_Pointer.EnemyCaza.maxLife * OP_EnemyManager.Instance._enemyStatsMultiplyer * _lifeModifyer));
        StartCoroutine(ChargeShot(Fw_Pointer.EnemyCazaRate.rate, 2));
    }
}
