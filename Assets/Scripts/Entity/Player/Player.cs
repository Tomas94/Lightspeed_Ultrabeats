using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("crea bala");
            Disparar();
        }


    }

    public override void Disparar()
    {
        var x = OP_BulletManager._playerBulletPool.Get();
        x.Initialize(OP_BulletManager._playerBulletPool, _bulletSpeed);
        x.transform.position = transform.position;
        x.transform.forward = transform.forward;
    }

    public override void Die()
    {
        Debug.Log("moriste");
       // throw new System.NotImplementedException();
    }
}