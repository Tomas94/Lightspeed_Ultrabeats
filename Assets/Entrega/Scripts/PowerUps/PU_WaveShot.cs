using System.Collections;
using System.Collections.Generic;
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
        _player.StopCoroutine(_player._chargeShot);
        var timer = 0f;
        Debug.Log("Active Time = " + _activeTime);
        while (timer < _activeTime)
        {
            yield return new WaitForSeconds(_fireRate);
            timer += 1;
            _player.Disparar(1);
            yield return null;
        }
        _isActive = false;
        _player._chargeShot = _player.StartCoroutine(_player.ChargeShot(_player.FireRate, 0));
    }
}
