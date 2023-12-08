using UnityEngine;

public class UpgradePointsManager : MonoBehaviour
{
    public static UpgradePointsManager instance;
    UpgradePoints _gameUpgradePoints;

    [SerializeField] int upgradePoints;

    public int UpgradePoints { get { return upgradePoints; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Initialize();
        }
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    void Initialize()
    {
        _gameUpgradePoints = new UpgradePoints(0);
        upgradePoints = _gameUpgradePoints.upgradePoints;
    }

    public void SpentUP(int value)
    {
        upgradePoints = _gameUpgradePoints.SpentResource(value);
    }

    public void GainUP(int value)
    {
        upgradePoints = _gameUpgradePoints.GainResource(value);
    }
}
