using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerModule : Pickable
{
    public override void PickUp(Player _player)
    {
        print("en PickUP");
        if (_player.shootLevel >= 3) return;

        switch (_player.shootLevel) 
        {
            case 0:
                _player.shootLevel = 1;
                _player.gameUI.carga1.enabled = true;
                break;
            case 1:
                _player.shootLevel = 2;
                _player.gameUI.carga2.enabled = true;
                break;
            case 2:
                _player.shootLevel = 3;
                _player.gameUI.carga3.enabled = true;
                break;
            default:
                break;
        }
        print(_player.shootLevel);
        RefillStock(this);
    }
}
