using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    public InGameUI gameUI;
    PU_Shield _shieldPU = new PU_Shield(7);
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
        _isShielded = _shieldPU._isActive;

        if (currentLife <= 0)Die(0);
        
        ChargingShot();
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
        SceneController.ResetGame();
    }

    public override void Disparar()
    {
        var bala = OP_BulletManager._playerBulletPool.Get();
        bala.Initialize(OP_BulletManager._playerBulletPool);
        bala.transform.position = transform.position;
        bala.transform.forward = transform.forward;
    }

    public void ActivateShield()
    {
        if(gameUI.shieldFillCircle.fillAmount == 1) _shieldPU.Activate(gameUI.shieldFillCircle.fillAmount);
    }
}