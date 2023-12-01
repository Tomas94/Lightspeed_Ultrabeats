using UnityEngine;

[System.Serializable]
public struct ObjectsPoolElements<T> where T : MonoBehaviour
{
    public T prefab;
    public int initAmount;
    public Factory<T> factory;
    public ObjectPool<T> pool;
}
