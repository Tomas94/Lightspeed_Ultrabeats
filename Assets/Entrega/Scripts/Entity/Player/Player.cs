using UnityEngine;
using System.Collections;

public class Player : Entity
{
    [SerializeField] GameObject _gameOverScreen;
    public Animator shield;
    [SerializeField] Renderer _mesh;

    public InGameUI_Controller gameUI;
    PU_Shield _shieldPU;
    PU_WaveShot _waveShotPU;

    [SerializeField] float _fireRate = 0.3f;
    [SerializeField] float _maxLife;
    public bool _isShielded;
    public bool _charging;

    [SerializeField] AudioClip _playerDisparoAC;
    [SerializeField] AudioClip _playerShieldAC;
    [SerializeField] AudioClip _playerShieldDEAC;
    [SerializeField] AudioClip _playerShieldReady;
    [SerializeField] AudioClip _playerDedSound;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource _audioSourceShield;

    Coroutine _chargeShot;

    public float MaxLife { get { return _maxLife; } set { _maxLife = value; } }

    private void Awake()
    {
        GetComponentInChildren<MeshRenderer>().material = GameManager.instance.playerskin;
        GetPlayerStatistics();
        currentLife = _maxLife;
        _mesh.material = GameManager.instance.playerskin;
    }

    private void Start()
    {
        _chargeShot = StartCoroutine(ChargeShot(_fireRate,0));
        StartCoroutine(RechargeShield());
        StartCoroutine(RechargeWave());
    }

    void Update()
    {
        _isShielded = _shieldPU._isActive;
        if (_isShielded == false && gameUI.shieldFillCircle.fillAmount < 1f)
        {
            if (!_charging)
            {
                StartCoroutine(RechargeShield());
                shield.SetBool("IsActive", false);
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
        _audioSourceShield.PlayOneShot(_playerDedSound);
        _gameOverScreen.SetActive(true);
        SceneManagerr.Pause();
        this.gameObject.SetActive(false);
    }

    public override void Disparar(int _bulletIndex)
    {
        DisparoSonido();
        var bala = OP_BulletManager.Instance.bulletPools[_bulletIndex].pool.Get();
        bala.Initialize(OP_BulletManager.Instance.bulletPools[_bulletIndex].pool);
        bala.transform.position = transform.position;
        bala.transform.forward = transform.forward;
    }

    public void ActivateShield()
    {
        if (gameUI.shieldFillCircle.fillAmount == 1f)
        {
            gameUI.shieldFillCircle.fillAmount = 0;
            StartCoroutine(_shieldPU.Activate());
            _audioSourceShield.PlayOneShot(_playerShieldAC);
            shield.SetBool("IsActive", true);
        }
    }

    public void ActivateWaveAttack()
    {
        if(gameUI.waveFillCircle.fillAmount == 1f)
        {
            gameUI.waveFillCircle.fillAmount= 0;
            StartCoroutine(_waveShotPU.Activate(this));
        }
    }

    public void DisparoSonido()
    {
        float randomPitch = Random.Range(0.7f, 1.2f);
        float randomVolume = Random.Range(0.1f, 0.3f);

        audioSource.pitch = randomPitch;
        audioSource.volume = randomVolume;

        audioSource.PlayOneShot(_playerDisparoAC);
    }

    void GetPlayerStatistics()
    {
        Player_Stats_Manager stats = Player_Stats_Manager.instance;

        _shieldPU = new PU_Shield(stats.ShieldDuration);
        _waveShotPU = new PU_WaveShot(stats.WaveDuration);
        _fireRate = stats.FireRate;
        MaxLife = stats.MaxLife;
    }


    public IEnumerator RechargeShield()
    {
        _audioSourceShield.PlayOneShot(_playerShieldDEAC);
        _charging = true;
        var timer = 0f;
        while (gameUI.shieldFillCircle.fillAmount < 1f)
        {
            timer += Time.deltaTime;
            gameUI.shieldFillCircle.fillAmount = timer / 15f;
            yield return null;
        }
        _charging = false;
        _audioSourceShield.PlayOneShot(_playerShieldReady);
    }

    public IEnumerator RechargeWave()
    {
        _audioSourceShield.PlayOneShot(_playerShieldDEAC);
        _charging = true;
        var timer = 0f;
        while (gameUI.waveFillCircle.fillAmount < 1f)
        {
            timer += Time.deltaTime;
            gameUI.waveFillCircle.fillAmount = timer / 5f;
            yield return null;
        }
        _charging = false;
        _audioSourceShield.PlayOneShot(_playerShieldReady);
    }
}