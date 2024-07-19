using UnityEngine;

public class Player_Stats_Manager : MonoBehaviour
{
    public static Player_Stats_Manager instance;

    float _fireRate = 0.3f;
    
    float _maxLife;
    float _damage;
    float _shieldDuration;
    float _waveDuration;

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
}
