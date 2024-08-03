using UnityEngine;

public abstract class Bullet : MonoBehaviour, IPooleableObject<Bullet>
{
    [SerializeField] protected LayerMask _targetLayer;
    protected ObjectPool<Bullet> _objectPool;

    public void Initialize(ObjectPool<Bullet> op) => _objectPool = op;

    public virtual void OnEntityHit(GameObject entity, float damage)
    {
        var _entity = entity.GetComponent<Entity>();

        if (_entity == null) return;

        if (_targetLayer == (_targetLayer | (1 << entity.gameObject.layer)))
        {
            _entity.TakeDamage(damage);
            _objectPool.RefillStock(this);
        }
    }
    
    public void BulletMovement(float speed) => transform.position += transform.forward * speed * Time.deltaTime;
    
    public void TurnOn(Bullet x) => x.gameObject.SetActive(true);

    public void TurnOff(Bullet x) => x.gameObject.SetActive(false);

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ResetTrigger")) _objectPool.RefillStock(this);
    }
}
