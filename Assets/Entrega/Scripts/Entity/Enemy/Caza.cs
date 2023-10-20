using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caza : Enemy
{
    float counter;

    private void Awake()
    {
        SetLife(Fw_Pointer.EnemyCaza.maxLife);
        counter = 0;
    }

    public void Update()
    {
        if (currentLife <= 0) Die(Random.Range(50, 60));
        Move();
        ChargingShot();
    }

    void ChargingShot()
    {
        if (counter < Fw_Pointer.EnemyCazaRate.rate)
        {
            counter += Time.deltaTime;
        }
        else
        {
            Disparar();
            counter = 0;
        }
    }

    public void Move()
    {
        transform.position += Fw_Pointer.EnemyCaza.speed * Time.deltaTime * transform.forward;
    }
   
    public override void TurnOff(Enemy x)
    {
        base.TurnOff(x);
        ResetMaxLife(x, Fw_Pointer.EnemyCaza.maxLife);
    }
}
