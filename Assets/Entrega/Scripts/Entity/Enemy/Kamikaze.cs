using UnityEngine;

public class Kamikaze : Enemy
{
    Player player;
    Vector3 dir;

    [SerializeField] bool _playerPassed;

    private void Awake()
    {
        SetLife(Fw_Pointer.EnemyKamikaze.maxLife);
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void Update()
    {
        KamikazeAttackMovement();
    }

    void KamikazeAttackMovement()
    {
        if (player == null) return;

        Vector3 playerPosition = player.transform.position;
        float distanceToPlayer = Vector3.Distance(playerPosition, transform.position);

        if (distanceToPlayer > Fw_Pointer.EnemyKamikazeSC.stopChasingDistance && !_playerPassed)
        { dir = playerPosition - transform.position; }
        else _playerPassed = true;

        transform.position += Fw_Pointer.EnemyKamikaze.speed * Time.deltaTime * dir.normalized;
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (currentLife <= 0) Die(Random.Range(20, 40));
    }

    public override void TurnOff(Enemy x)
    {
        base.TurnOff(x);
        ResetMaxLife(x, Fw_Pointer.EnemyKamikaze.maxLife);
    }

    private void OnDisable() => _playerPassed = false;
}