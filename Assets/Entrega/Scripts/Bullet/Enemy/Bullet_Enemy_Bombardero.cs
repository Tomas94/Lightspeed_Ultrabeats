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
        OnEntityHit(other.gameObject, Fw_Pointer.BulletBombardero.damage + (Fw_Pointer.BulletBombardero.damage * OP_EnemyManager.Instance._enemyStatsMultiplyer * 0.5f));
    }
}
