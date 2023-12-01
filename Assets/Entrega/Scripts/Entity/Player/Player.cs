using System.Collections;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] GameObject _gameOverScreen;
    
    public InGameUI_Controller gameUI;
    PU_Shield _shieldPU = new PU_Shield(7);

    [SerializeField] float _fireRate = 0.3f;
    [SerializeField] float _maxLife;
    public bool _isShielded;

    private void Start()
    {
        currentLife = _maxLife;
        StartCoroutine(ChargeShot(_fireRate));
    }

    void Update()
    {
        _isShielded = _shieldPU._isActive; 
    }

    public override void TakeDamage(float damage)
    {
        if (_isShielded) return;
        base.TakeDamage(damage);
        if (currentLife <= 0) Die(0);
    }

    public override void Die(int deathpoints)
    {
        _gameOverScreen.SetActive(true);
        SceneManagerr.Pause();
        this.gameObject.SetActive(false);
    }

    public override void Disparar()
    {
        var bala = OP_BulletManager.instance.bulletPools[0].pool.Get();
        bala.Initialize(OP_BulletManager.instance.bulletPools[0].pool);
        bala.transform.position = transform.position;
        bala.transform.forward = transform.forward;
    }

    public void ActivateShield()
    {
        if (gameUI.shieldFillCircle.fillAmount == 1) _shieldPU.Activate(gameUI.shieldFillCircle.fillAmount);
    }
}