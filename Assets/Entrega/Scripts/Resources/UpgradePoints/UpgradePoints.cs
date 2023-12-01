public class UpgradePoints
{
    public int _actualUPs;

    public UpgradePoints(int actualUP) => _actualUPs = actualUP;

    public void SpentResource(int quantity)
    {
        _actualUPs -= quantity;
    }

    public void GainResource(int quantity)
    {
        var pointsGained = quantity * 0.8f * 0.3f;
        _actualUPs += (int)pointsGained;
    }

}