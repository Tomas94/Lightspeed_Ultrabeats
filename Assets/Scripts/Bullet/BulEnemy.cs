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
        
        Debug.Log("la bala no hizo nada");

        if (_targetLayer == (_targetLayer | (1 << other.gameObject.layer)))
        {
            other.GetComponent<Entity>().TakeDamage(Fw_Pointer.BulletPlayer.damage);
            Debug.Log("la bala impacto");
            _objectPool.RefillStock(this);
        }
    }
}
