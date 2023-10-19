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
        base.OnTriggerEnter(other);
        OnEntityHit(other.gameObject, Fw_Pointer.BulletPlayer.damage);
    }
}
