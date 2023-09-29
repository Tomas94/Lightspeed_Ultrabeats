using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour, IPooleableObject<Enemy>
{
    
    [SerializeField] float _speed;
    [SerializeField] float _maxLife=10;
    [SerializeField] float _currentLife;
    public bool outOfScreen;

    ObjectPool<Enemy> _enemyPool;
    [SerializeField] OP_Bullets _bulletsOPool;
    [SerializeField] float _bulletSpeed;

    public void Initialize(ObjectPool<Enemy> op, float speed)
    {
        _enemyPool = op;
        _speed = speed;
    }

    private void Start()
    {
        _bulletsOPool = GameObject.Find("EnemyBulletPool").GetComponent<OP_Bullets>();
        _currentLife = _maxLife; 
    }

    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.F))
        {
            Disparar();
        }

        if (_currentLife <= 0 || outOfScreen)
        {
            _enemyPool.RefillStock(this);
        }
    }

    public void TurnOff(Enemy x)
    {
        x.gameObject.SetActive(false);
        x._currentLife = _maxLife;
    }

    public void TurnOn(Enemy x)
    {
        x.gameObject.SetActive(true);
    }

    public void Disparar()
    {
        Debug.Log("se crea un enemigo");
        var x = _bulletsOPool._bulletPool.Get();
        x.Initialize(_bulletsOPool._bulletPool, _bulletSpeed);
        x.transform.position = transform.position;
        x.transform.forward = transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ResetTrigger")) outOfScreen = true;
    }
}
