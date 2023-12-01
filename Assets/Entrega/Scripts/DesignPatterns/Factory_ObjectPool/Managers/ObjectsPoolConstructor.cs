using UnityEngine;

[System.Serializable]
public struct ObjectsPoolConstructor<T> where T : MonoBehaviour
{
    public T prefab;
    public int initAmount;
    public Factory<T> factory;
    public ObjectPool<T> pool;
}
