using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePoints : IResources
{
    float _actualUPs;

    public UpgradePoints(float actualUP)
    {
        _actualUPs = actualUP;
    }

    public void SpentResource(int quantity)
    {
        _actualUPs -= quantity;
    }

    public void GainResource(int quantity)
    {
        var pointsGained = quantity * 0.8f * 0.3f;
        _actualUPs += pointsGained;
    }

    /*
    public void SpentUP(float points)
    {
        _actualUpgradePoints -= points;
    }

    public void GainUP(float score)
    {
        var pointsGained = score * 0.8f * 0.3f;

        _actualUpgradePoints += pointsGained;
    }
    */
}
