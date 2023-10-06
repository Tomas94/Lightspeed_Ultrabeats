using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour, IPooleableObject<Bullet>
{
    [SerializeField] protected LayerMask _targetLayer;
    protected ObjectPool<Bullet> _objectPool;

    public void Initialize(ObjectPool<Bullet> op)
    {
        _objectPool = op;
    }

    public void TurnOff(Bullet x)
    {
        x.gameObject.SetActive(false);
    }

    public void TurnOn(Bullet x)
    {
        x.gameObject.SetActive(true);
    }

    public void BulletMovement(float speed)
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ResetTrigger")) _objectPool.RefillStock(this);
    }

}
