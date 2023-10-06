using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OP_EnemyManager : MonoBehaviour
{
    public static OP_EnemyManager Instance;
    public List<ObjectPool<Enemy>> enemyOPs = new List<ObjectPool<Enemy>>();

    [Header("Caza")]

    [SerializeField] int _cazadorInitAmount;
    [SerializeField] Enemy _cazadorPrefab;
    Factory<Enemy> _cazadorFactory;
    public ObjectPool<Enemy> _cazadorPool;

    [Header("Kamikaze")]
    [SerializeField] int _kamikazeInitAmount;
    [SerializeField] Enemy _kamikazePrefab;
    Factory<Enemy> _kamikazeFactory;
    public ObjectPool<Enemy> _kamikazePool;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        if (_cazadorPrefab != null)
        {
            _cazadorFactory = new Factory<Enemy>(_cazadorPrefab);
            _cazadorPool = new ObjectPool<Enemy>(_cazadorFactory.GetObject, _cazadorPrefab.TurnOff, _cazadorPrefab.TurnOn, _cazadorInitAmount);
        }

        if (_kamikazePrefab != null)
        {
            _kamikazeFactory = new Factory<Enemy>(_kamikazePrefab);
            _kamikazePool = new ObjectPool<Enemy>(_kamikazeFactory.GetObject, _kamikazePrefab.TurnOff, _kamikazePrefab.TurnOn, _kamikazeInitAmount);
        }
    }
}
