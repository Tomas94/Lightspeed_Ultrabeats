using UnityEngine;

public class UpgradePointsController : MonoBehaviour
{
    UpgradePoints _gameUpgradePoints = new UpgradePoints(0);

    void Start()
    {
        _gameUpgradePoints._actualUPs = GameManager.Instance.upgradePoints;
    }

    public void SpentUP(int value)
    {
        _gameUpgradePoints.SpentResource(value);
        UpdateUpgradePoints();
    }

    public void GainUP(int value)
    {
        _gameUpgradePoints.GainResource(value);
        UpdateUpgradePoints();
    }

    void UpdateUpgradePoints() => GameManager.Instance.upgradePoints = _gameUpgradePoints._actualUPs;
}
