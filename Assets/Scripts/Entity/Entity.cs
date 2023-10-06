using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public float _bulletSpeed;
    [SerializeField] protected float maxLife;
    public float currentLife;

    public abstract void Disparar();
    public abstract void Die();

    private void Start()
    {
        currentLife = maxLife;
    }

    public void TakeDamage()
    {
        currentLife--;
    }

}
