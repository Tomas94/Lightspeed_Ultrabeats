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

        if (_targetLayer == (_targetLayer | (1 << other.gameObject.layer)))
        {
            other.GetComponent<Entity>().TakeDamage(Fw_Pointer.BulletCaza.damage);
            _objectPool.RefillStock(this);
        }
    }
}
