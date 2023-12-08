using UnityEngine;

public class UpgradePointsManager : MonoBehaviour
{
    public static UpgradePointsManager instance;
    UpgradePoints _gameUpgradePoints;

    [SerializeField] int upgradePoints;

    public int UpgradePoints { get { return upgradePoints; } set { upgradePoints = value; } }

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
        _gameUpgradePoints = new UpgradePoints(PlayerPrefs.GetInt("upgradePoints"));
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
