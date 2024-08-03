using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medikit : Pickable
{
    public override void PickUp(Player _player)
    {
        print("en PickUP");
        if (_player.currentLife >= _player.MaxLife) return;
        else _player.currentLife++;
        RefillStock(this);
    }
}
