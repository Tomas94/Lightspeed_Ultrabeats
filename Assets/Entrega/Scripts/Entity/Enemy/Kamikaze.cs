using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : Enemy
{
    Player player;
    Vector3 dir;

    bool _enemyPassed;

    private void Awake()
    {
        SetLife(Fw_Pointer.EnemyKamikaze.maxLife);
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        dir = player.transform.position - transform.position;
    }

    public override void Update()
    {
        base.Update();
        KamikazeAttackMovement();
    }

    void KamikazeAttackMovement()
    {
        if (player == null) return;

        if (Vector3.Distance(player.transform.position, transform.position) > Fw_Pointer.EnemyKamikazeSC.stopChasingDistance && !_enemyPassed)
        {
            dir = player.transform.position - transform.position;
        }
        else { _enemyPassed = true; }

        transform.position += Fw_Pointer.EnemyKamikaze.speed * Time.deltaTime * dir.normalized;
    }

    public override void TurnOn(Enemy x)
    {
        base.TurnOn(x);
    }
    
    public override void TurnOff(Enemy x)
    {
        base.TurnOff(x);
        ResetMaxLife(x, Fw_Pointer.EnemyKamikaze.maxLife);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, dir);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Fw_Pointer.EnemyKamikazeSC.stopChasingDistance);
    }

    private void OnDisable()
    {
        _enemyPassed = false;
    }
}
