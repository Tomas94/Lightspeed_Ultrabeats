using UnityEngine;

public class Player_Stats_Manager : MonoBehaviour
{
    public static Player_Stats_Manager instance;

    float _fireRate = 0.3f;
    
    [SerializeField] float _maxLife;
    [SerializeField] float _damage;
    [SerializeField] float _shieldDuration;
    [SerializeField] float _waveDuration;

    public float FireRate { get { return _fireRate; } }
    public float MaxLife { get { return _maxLife; } set { _maxLife = value; } }
    public float Damage { get { return _damage; } set { _damage = value; } }
    public float ShieldDuration { get { return _shieldDuration; } set { _shieldDuration = value; } }
    public float WaveDuration { get { return _waveDuration; } set { _waveDuration = value; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this);
        DontDestroyOnLoad(this);
    }

    public void LevelUpStat(string name)
    {
        switch (name)
        {
            case "vitality":
                MaxLife += 1.5f;
                break;
            case "damage":
                 Damage += 0.5f;
                break;
            case "shield":
                ShieldDuration += 0.5f;
                break;
            case "wave":
                WaveDuration += 0.2f;
                break;
            default:
                return;
        }
        GameManager.instance.SavePlayerPrefs();
    }

    public void LevelDownStat(string name)
    {
        switch (name)
        {
            case "vitality":
                MaxLife -= 1.5f;
                break;
            case "damage":
                Damage -= 0.5f;
                break;
            case "shield":
                ShieldDuration -= 0.5f;
                break;
            case "wave":
                WaveDuration -= 0.2f;
                break;
            default:
                return;
        }
        GameManager.instance.SavePlayerPrefs();
    }
}
