using UnityEngine;

public class Bullet_Wave_Player : Bullet
{
    protected void Update()
    {
        WaveMovement(Fw_Pointer.BulletWavePlayer.speed);
    }

    void WaveMovement(float speed)
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    public override void OnEntityHit(GameObject entity, float damage)
    {
        var _entity = entity.GetComponent<Entity>();

        if (_entity == null) return;

        if (_targetLayer == (_targetLayer | (1 << entity.gameObject.layer))) _entity.TakeDamage(damage);

    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        OnEntityHit(other.gameObject, Fw_Pointer.BulletWavePlayer.damage + Player_Stats_Manager.instance.Damage);
    }
}
