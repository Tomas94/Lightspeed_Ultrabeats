using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    public bool _isShielded;
    float _counter = 0;
    [SerializeField] float _fireRate = 0.3f;

    [SerializeField] float _maxLife;

    private void Start()
    {
        currentLife = _maxLife;
    }

    void Update()
    {
        //_isShielded = PU_Shield._isActive;

        if (currentLife <= 0)
        {
            Die(0);
        }

        ChargingShot();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
    }

    void ChargingShot()
    {
        if (_counter <= _fireRate)
        {
            _counter += Time.deltaTime;
        }
        else
        {
            Disparar();
            _counter = 0;
        }
    }

    public override void Die(int deathpoints)
    {
        SceneChanger.ResetGame();
    }

    public override void Disparar()
    {
        var bala = OP_BulletManager._playerBulletPool.Get();
        bala.Initialize(OP_BulletManager._playerBulletPool);
        bala.transform.position = transform.position;
        bala.transform.forward = transform.forward;
    }
}