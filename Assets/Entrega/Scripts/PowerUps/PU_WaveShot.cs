using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PU_WaveShot
{
    public bool _isActive = false;
    float _activeTime;
    float _fireRate = 1;

    public float ActiveTime { get { return _activeTime; } set { _activeTime = value; } }

    public PU_WaveShot(float activeTime)
    {
        _activeTime = activeTime;
    }

    public IEnumerator Activate(Player _player)
    {
        _isActive = true;
        var timer = 0f;
        Debug.Log("Active Time = " + _activeTime);
        while (timer < _activeTime)
        {
            Debug.Log("Timer = " + timer);
            yield return new WaitForSeconds(1);
            timer += 1;
            _player.Disparar(1);
            yield return null;
        }
        _isActive = false;
    }
}
