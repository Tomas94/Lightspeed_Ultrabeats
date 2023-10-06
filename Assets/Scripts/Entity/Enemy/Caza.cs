using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caza : Enemy
{
    void Update()
    {
        Die();
        
        transform.position += transform.forward * _speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Disparar();
        }

    }

}
