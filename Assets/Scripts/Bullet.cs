using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooleableObject<Bullet>
{
    float _count;
    float _speed;
    [SerializeField] LayerMask _targetLayer;
    ObjectPool<Bullet> _objectPool;

    public void Initialize(ObjectPool<Bullet> op, float speed)
    {
        _objectPool = op;
        _speed = speed;
    }

    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
        _count += Time.deltaTime;

        if (_count > 2)
        {
            _objectPool.RefillStock(this);
        }
    }

    public void TurnOff(Bullet x)
    {
        x.gameObject.SetActive(false);
        x._count = 0;
    }

    public void TurnOn(Bullet x)
    {
        x.gameObject.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer != _targetLayer)
        {
            return;
        }
        else
        {
            other.GetComponent<Entity>().TakeDamage();
        }
    }

}
