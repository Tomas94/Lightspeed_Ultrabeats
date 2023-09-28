using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Bullet bulletPrefab;
    public Factory<Bullet> factory;
    ObjectPool<Bullet> myPool;

    void Start()
    {

        factory = new Factory<Bullet>(bulletPrefab);
        myPool = new ObjectPool<Bullet>(factory.GetObject, Bullet.TurnOff, Bullet.TurnOn, 100);

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var x = myPool.Get();
            x.Initialize(myPool, 10);
            x.transform.position = transform.position;
            x.transform.forward = transform.forward;
        }
    }
}