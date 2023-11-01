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

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            stamina = -1;
            DontDestroyOnLoad(this);
        }
        else Destroy(gameObject);
    }
}
