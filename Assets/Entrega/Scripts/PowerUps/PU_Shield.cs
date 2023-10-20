using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_Shield : MonoBehaviour
{
    public bool _isActive;
    float _activeTime;

    public void Activate()
    {
        _isActive = true;
        if (_activeTime > 0) _activeTime -= Time.deltaTime;
        else Deactivate();
    }

    public void Deactivate()
    {
        _isActive = false;
    }
}
