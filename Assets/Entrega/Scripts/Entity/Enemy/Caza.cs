using System.Collections;
using UnityEngine;

public class Caza : Enemy
{
    private void Awake()
    {
        SetLife(Fw_Pointer.EnemyCaza.maxLife);
    }

    private void Start()
    {
        StartCoroutine(ChargeShot(Fw_Pointer.EnemyCazaRate.rate));
    }

    public void Update()
    {
        Move();
    }

    public void Move() => transform.position += Fw_Pointer.EnemyCaza.speed * Time.deltaTime * transform.forward;

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (currentLife <= 0) Die(Random.Range(50, 60));
    }

    public override void TurnOff(Enemy x)
    {
        base.TurnOff(x);
        ResetMaxLife(x, Fw_Pointer.EnemyCaza.maxLife);
    }
}
