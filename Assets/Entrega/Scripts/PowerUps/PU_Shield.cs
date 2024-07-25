using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PU_Shield
{
    public bool _isActive = false;
    float _activeTime;

    public float ActiveTime { get { return _activeTime; } set { _activeTime = value; } }

    public PU_Shield(float activeTime) => _activeTime = activeTime;

    public IEnumerator Activate()
    {
        _isActive = true;
        yield return new WaitForSeconds(_activeTime);
        _isActive = false;
    }
}