using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulEnemy : Bullet
{
    protected void Update()
    {
        BulletMovement(Fw_Pointer.BulletCaza.speed);
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);

        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Player>()._isShielded)
            {
                _objectPool.RefillStock(this);
                return;
            }
        }

        OnEntityHit(other.gameObject, Fw_Pointer.BulletCaza.damage);
    }
}
