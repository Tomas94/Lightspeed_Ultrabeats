using UnityEngine;

public class PU_Shield
{
    public bool _isActive;
    float _activeTime;

    public PU_Shield(float activeTime)
    {
        _activeTime = activeTime;
    }

    public void Activate(float fillamount)
    {
        _isActive = true;
        if (_activeTime > 0) _activeTime -= Time.deltaTime;
        else { Deactivate(); }
        fillamount = 0;
    }

    public void Deactivate()
    {
        _isActive = false;
    }
}
