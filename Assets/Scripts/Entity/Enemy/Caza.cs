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
        transform.position += transform.forward * Fw_Pointer.EnemyCaza.speed * Time.deltaTime;
    }

    private void OnDisable()
    {
        currentLife = Fw_Pointer.EnemyCaza.maxLife;
    }
}
