using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public static class Fw_Pointer
{

    #region Flyweight Enemigos

    public static readonly Fw_Enemy AllEnemies = new Fw_Enemy()
    {
        impactDamage = 1
    };

    public static readonly Fw_Enemy EnemyCaza = new Fw_Enemy
    {
        speed = 1,
        maxLife = 5,
    };
    public static readonly Fw_Enemy EnemyKamikaze = new Fw_Enemy
    {
        speed = 1,
        maxLife = 5,
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
        speed = 5
    };

    public static readonly Fw_Bullets BulletCaza = new Fw_Bullets
    {
        damage = 2,
        speed = 2
    };

    #endregion

}
