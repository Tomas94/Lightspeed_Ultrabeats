using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickable : MonoBehaviour, IPooleableObject<Pickable>
{
    ObjectPool<Pickable> _pickablePool;
    protected float speed = 1.5f;
    
    public void Initialize(ObjectPool<Pickable> op) => _pickablePool = op;

    public abstract void PickUp(Player _player);

    public void Move()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    private void Update()
    {
        Move();
    }

    public void RefillStock(Pickable item)
    {
        _pickablePool?.RefillStock(item);
    }

    public void TurnOn(Pickable x) => x.gameObject.SetActive(true);

    public void TurnOff(Pickable x) => x.gameObject.SetActive(false);

    public void OnTriggerEnter(Collider other)
    {
        print("en Trigger");

        if (other.TryGetComponent<Player>(out Player player))
        {
           PickUp(player);
        }
    }
}
