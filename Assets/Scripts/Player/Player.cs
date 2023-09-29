using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] OP_Bullets _bulletsOPool;
    [SerializeField] float _bulletSpeed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("crea bala");
            Disparar();
        }
    }

    public void Disparar()
    {
        var x = _bulletsOPool._bulletPool?.Get();
        x.Initialize(_bulletsOPool._bulletPool, _bulletSpeed);
        x.transform.position = transform.position;
        x.transform.forward = transform.forward;
    }
}