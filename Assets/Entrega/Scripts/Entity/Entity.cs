using System.Collections;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public float currentLife;

    public abstract void Disparar();
    public abstract void Die(int deathpoints);
    
    public virtual IEnumerator ChargeShot(float fireCD)
    {
        while (true)
        {
            yield return new WaitForSeconds(fireCD);
            Disparar();
        }
    }

    public virtual void TakeDamage(float damage)
    {
        currentLife -= damage;
        print("daño causado: " + damage);
    }
}
