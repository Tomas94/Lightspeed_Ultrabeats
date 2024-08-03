using System.Collections;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public float currentLife;

    public abstract void Disparar(int _bulletIndex);
    public abstract void Die(int deathpoints);

    public virtual IEnumerator ChargeShot(float fireCD, int bulletIndex)
    {
        while (true)
        {
            yield return new WaitForSeconds(fireCD);
            Disparar(bulletIndex);
        }
    }

    public virtual void TakeDamage(float damage)
    {
        currentLife -= damage;
        //print("daño causado: " + damage);
    }
}
