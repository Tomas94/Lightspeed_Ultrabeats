using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    [SerializeField] float maxLife;

    private void Start()
    {
        currentLife = maxLife;
    }

    void Update()
    {
        Die();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
    }

    public override void Die()
    {
        if(currentLife<=0)
        {
            SceneChanger.ResetGame();
        }
    }

    public override void Disparar()
    {
        var bala = OP_BulletManager._playerBulletPool.Get();
        bala.Initialize(OP_BulletManager._playerBulletPool);
        bala.transform.position = transform.position;
        bala.transform.forward = transform.forward;
    }
}