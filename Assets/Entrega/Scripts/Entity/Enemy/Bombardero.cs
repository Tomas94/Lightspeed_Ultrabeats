using UnityEngine;

public class Bombardero: Enemy
{
    Player player;
    Vector3 dir;

    private void Awake()
    {
        SetLife(Fw_Pointer.EnemyBombardero.maxLife);
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        print("En start");
    }


    public void Update()
    {
       Move();
    }

    public void Move() => transform.position += Fw_Pointer.EnemyBombardero.speed * Time.deltaTime * transform.forward;

    public override void Disparar()
    {
        print("Disparando");
        var x = OP_BulletManager.Instance.bulletPools[2].pool.Get();
        x.Initialize(OP_BulletManager.Instance.bulletPools[2].pool);
        x.transform.position = transform.position;
        dir = (player.transform.position - transform.position).normalized;
        x.transform.forward = dir;
        print("terminand disparo");
    }


    public override void TakeDamage(float damage)
    {
        print("dañado");
        base.TakeDamage(damage);
        if (currentLife <= 0) Die(Random.Range(50, 60));
    }

    public override void TurnOn(Enemy x)
    {
        base.TurnOn(x);
    }

    public override void TurnOff(Enemy x)
    {
        base.TurnOff(x);
        StopAllCoroutines();
        ResetMaxLife(x, Fw_Pointer.EnemyBombardero.maxLife);
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnEnable()
    {
        transform.forward = -transform.forward;
        StartCoroutine(ChargeShot(Fw_Pointer.EnemyBombarderoRate.rate));
    }
}
