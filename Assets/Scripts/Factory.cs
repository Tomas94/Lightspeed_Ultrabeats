using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory<T> where T : MonoBehaviour
{
    T _prefab;

    public Factory(T prefab) {  _prefab = prefab; }

    public T GetObject() { return GameObject.Instantiate(_prefab); }

}
