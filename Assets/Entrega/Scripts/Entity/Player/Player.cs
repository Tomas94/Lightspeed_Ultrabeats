using UnityEngine;
using System.Collections;

public class Player : Entity
{
    [SerializeField] GameObject _gameOverScreen;
    public Animator shield;

    public InGameUI_Controller gameUI;
    PU_Shield _shieldPU = new PU_Shield(5);

    [SerializeField] float _fireRate = 0.3f;
    [SerializeField] float _maxLife;
    public bool _isShielded;
    public bool _charging;

    public float MaxLife { get { return _maxLife; } }

    private void Awake()
    {
        GetComponentInChildren<MeshRenderer>().material = GameManager.Instance.playerskin;
        currentLife = _maxLife;
    }

    private void Start()
    {
        StartCoroutine(ChargeShot(_fireRate));
        StartCoroutine(RechargeShield());
    }

    void Update()
    {
        _isShielded = _shieldPU._isActive;
        if (!_isShielded && gameUI.shieldFillCircle.fillAmount < 0.9f)
        {
            if (!_charging)
            {
                StartCoroutine(RechargeShield());
                shield.SetBool("IsActive", _isShielded);
            }          
        }
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
        var bala = OP_BulletManager.Instance.bulletPools[0].pool.Get();
        bala.Initialize(OP_BulletManager.Instance.bulletPools[0].pool);
        bala.transform.position = transform.position;
        bala.transform.forward = transform.forward;
    }

    public void ActivateShield()
    {
        if (gameUI.shieldFillCircle.fillAmount > 0.9f)
        {
            StartCoroutine(_shieldPU.Activate());
            shield.SetBool("IsActive", _isShielded);
        }
    }

    public IEnumerator RechargeShield()
    {
        _charging = true;
        var timer = 0f;
        while (gameUI.shieldFillCircle.fillAmount < 0.9f)
        {
            timer += Time.deltaTime;
            gameUI.shieldFillCircle.fillAmount = timer / 10f;
            yield return null;
        }
        _charging = false;
    }
}