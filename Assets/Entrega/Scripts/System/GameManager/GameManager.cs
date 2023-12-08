using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Resources")]
    public int stamina;
    public int currency;
    public int upgradePoints;

    [Header("Score Variables")]
    public int levelScore;
    public int killCount;

    [Header("Configuration Values")]
    public bool vibration;
    [RangeAttribute(0f, 0.5f)] public float brigthnessValue;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            stamina = 5;
            DontDestroyOnLoad(this);
        }
        else Destroy(gameObject);
    }
    private void Start() { LoadPlayerPreferencies(); }

    void LoadPlayerPreferencies()
    {
        vibration = PlayerPrefs.GetInt("Vibration", 0) == 1;
        brigthnessValue = PlayerPrefs.GetFloat("BrightnessValue", 0.25f);
    }
}
