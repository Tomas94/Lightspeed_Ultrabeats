using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public interface IPooleableObject<T>
{
    public void TurnOff(T x);
    public void TurnOn(T x);
}
