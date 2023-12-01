using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    public delegate T FactoryMethod();
    FactoryMethod _factory;
    GameObject _caja = new GameObject("Instancias de ");

    Action<T> _turnOn, _turnOff;

    List<T> _stock = new List<T>();

    public ObjectPool(FactoryMethod method, Action<T> turnOff, Action<T> turnOn, int warmup = 5)
    {
        _factory = method;
        _turnOn = turnOn;
        _turnOff = turnOff;

        for (int i = 0; i < warmup; i++)
        {
            var x = _factory();
            _turnOff(x);
            _stock.Add(x);
            x.transform.parent = _caja.transform;
        }
        _caja.name += _stock[0].name;
    }

    public T Get()
    {
        T x = default;
        if (_stock.Count > 0)
        {
            x = _stock[0];
            _stock.RemoveAt(0);
        }
        else
        {
            x = _factory();
            x.transform.parent = _caja.transform;
        }
        _turnOn(x);

        return x;
    }

    public void RefillStock(T Sample)
    {
        _turnOff(Sample);
        _stock.Add(Sample);
    }
}