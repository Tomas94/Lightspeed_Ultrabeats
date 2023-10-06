using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulPlayer : Bullet
{
    protected void Update()
    {
        BulletMovement(Fw_Pointer.BulletPlayer.speed);
    }

   public override void OnTriggerEnter(Collider other)
    {
        Debug.Log("la bala no hizo nada");
        
        base.OnTriggerEnter(other);
        
        if (_targetLayer == (_targetLayer | (1 << other.gameObject.layer)))
        {
            other.GetComponent<Entity>().TakeDamage(Fw_Pointer.BulletPlayer.damage);
            Debug.Log("la bala impacto");
            _objectPool.RefillStock(this);
        }
    }
}
