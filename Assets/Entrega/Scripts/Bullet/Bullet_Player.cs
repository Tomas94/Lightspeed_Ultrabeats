using UnityEngine;

public class Bullet_Player : Bullet
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
