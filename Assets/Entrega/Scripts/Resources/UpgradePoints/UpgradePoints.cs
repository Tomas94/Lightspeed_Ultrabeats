public class UpgradePoints
{
    public int upgradePoints;

    public UpgradePoints(int _actualUP) => upgradePoints = _actualUP;

    public int SpentResource(int quantity)
    {
        if (upgradePoints > quantity) upgradePoints -= quantity;
        return upgradePoints;
    }

    public int GainResource(int quantity)
    {
        var pointsGained = quantity * 0.8f * 0.3f;
        upgradePoints += (int)pointsGained;
        return upgradePoints;
    }
}