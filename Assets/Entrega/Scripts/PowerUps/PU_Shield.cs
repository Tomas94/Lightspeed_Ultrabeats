using System.Collections;
using UnityEngine;

public class PU_Shield
{
    public bool _isActive;
    float _activeTime;

    public PU_Shield(float activeTime) => _activeTime = activeTime;

    public IEnumerator Activate()
    {
        _isActive = true;
        yield return new WaitForSeconds(_activeTime);
        _isActive = false;
    }

}