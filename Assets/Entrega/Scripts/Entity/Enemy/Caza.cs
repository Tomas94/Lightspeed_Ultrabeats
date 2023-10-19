using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caza : Enemy
{
    private void Awake()
    {
        SetLife(Fw_Pointer.EnemyCaza.maxLife);
    }

    public override void Update()
    {
        base.Update();
        Move();

        if (Input.GetKeyDown(KeyCode.F))
        {
            Disparar();
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
