using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : Enemy
{
    [SerializeField] Player player;
    Vector3 dir;
    public float distanceToStopChasing;
    bool _enemyPassed;


    private void Start()
    {
        player = FindObjectOfType<Player>();
        dir = player.transform.position - transform.position;
        distanceToStopChasing = 1;
    }

    public override void Update()
    {
        base.Update();
        KamikazeAttack();
    }

    void KamikazeAttack()
    {
        if (player == null) return;

        if (Vector3.Distance(player.transform.position, transform.position) > distanceToStopChasing && !_enemyPassed)
        {
            dir = player.transform.position - transform.position;

        }
        else { _enemyPassed = true; }
        transform.position += dir.normalized * _speed * Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, dir);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceToStopChasing);
    }

    private void OnDisable()
    {
        _enemyPassed = false;
    }
}
