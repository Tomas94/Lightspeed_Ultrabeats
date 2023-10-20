using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Fw_Pointer
{
    #region Flyweight Enemigos

    public static readonly FW_ImpactDamage AllEnemiesID = new FW_ImpactDamage()
    {
        impactDamage = 1
    };

    public static readonly Fw_Enemy EnemyCaza = new Fw_Enemy
    {
        speed = 2f,
        maxLife = 3,
    };

    public static readonly FW_FireRate EnemyCazaRate = new FW_FireRate()
    {
        rate = 1
    };

    public static readonly Fw_Enemy EnemyKamikaze = new Fw_Enemy
    {
        speed = 3,
        maxLife = 1,
    };

    public static readonly FW_StopChasing EnemyKamikazeSC = new FW_StopChasing()
    {
        stopChasingDistance = 2
    };

    public static readonly Fw_Enemy EnemyBombardero = new Fw_Enemy
    {
        speed = 1,
        maxLife = 5,
    };
    #endregion

    #region Flyweight Balas

    public static readonly Fw_Bullets BulletPlayer = new Fw_Bullets
    {
        damage = 1,
        speed = 7
    };

    public static readonly Fw_Bullets BulletCaza = new Fw_Bullets
    {
        damage = 1,
        speed = 4
    };

    #endregion
}
