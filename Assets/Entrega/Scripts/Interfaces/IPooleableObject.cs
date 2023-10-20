using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooleableObject<T>
{
    public void TurnOff(T x);
    public void TurnOn(T x);
}
