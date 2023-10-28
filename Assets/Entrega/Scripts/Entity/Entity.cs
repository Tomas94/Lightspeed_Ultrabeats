using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public float currentLife;

    public abstract void Disparar();
    public abstract void Die(int deathpoints);

    public void TakeDamage(float damage)
    {
        currentLife -= damage;
    }
}
