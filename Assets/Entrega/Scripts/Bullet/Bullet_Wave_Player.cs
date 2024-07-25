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

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        OnEntityHit(other.gameObject, Fw_Pointer.BulletWavePlayer.damage + Player_Stats_Manager.instance.Damage);
    }
}
