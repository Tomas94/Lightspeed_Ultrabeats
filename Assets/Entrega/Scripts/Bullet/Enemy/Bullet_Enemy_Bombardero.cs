using UnityEngine;

public class Bullet_Enemy_Bombardero : Bullet
{
    protected void Update()
    {
        BulletMovement(Fw_Pointer.BulletBombardero.speed);
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        OnEntityHit(other.gameObject, Fw_Pointer.BulletBombardero.damage);
    }
}
