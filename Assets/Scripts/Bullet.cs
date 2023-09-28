using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float count;
    public float speed;
    ObjectPool<Bullet> _objectPool;

    public void Initialize(ObjectPool<Bullet> op, float speed)
    {
        _objectPool = op;
        this.speed = speed;
    }


    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        count += Time.deltaTime;

        if (count > 2)
        {
            _objectPool.RefillStock(this);
        }
    }

    public static void TurnOff(Bullet x)
    {
        x.gameObject.SetActive(false);
        x.count = 0;
    }

    public static void TurnOn(Bullet x)
    {
        x.gameObject.SetActive(true);
    }
}
