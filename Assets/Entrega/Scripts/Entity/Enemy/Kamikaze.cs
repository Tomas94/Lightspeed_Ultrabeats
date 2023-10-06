using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : Enemy
{
    [SerializeField] Player player;
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
        KamikazeAttack();
    }

    void KamikazeAttack()
    {
        if (player == null) return;

        if (Vector3.Distance(player.transform.position, transform.position) > Fw_Pointer.EnemyKamikaze.stopChasingDistance && !_enemyPassed)
        {
            dir = player.transform.position - transform.position;

        }
        else { _enemyPassed = true; }
        transform.position += dir.normalized * Fw_Pointer.EnemyKamikaze.speed * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, dir);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Fw_Pointer.EnemyKamikaze.stopChasingDistance);
    }

    private void OnDisable()
    {
        _enemyPassed = false;
        currentLife = Fw_Pointer.EnemyKamikaze.maxLife;
    }
}
