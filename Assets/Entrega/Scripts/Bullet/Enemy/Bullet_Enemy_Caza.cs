using UnityEngine;

public class Bullet_Enemy_Caza : Bullet
{
    protected void Update()
    {
        BulletMovement(Fw_Pointer.BulletCaza.speed);
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        OnEntityHit(other.gameObject, Fw_Pointer.BulletCaza.damage + (Fw_Pointer.BulletCaza.damage * OP_EnemyManager.Instance._enemyStatsMultiplyer * 0.5f));
    }
}
