using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float moveSpeedBase = 5f;
    public float speedModified = 0f;
    public float moveSpeed;

    public int hp = 5;
    public int maxHp;
    public int maxHpBase = 5;
    public int maxHpModified = 0;

    public float attackDelay;
    public float attackDelayBase = 2;
    public float attackDelayModified = 0f;

    public int attackLevel = 1;
    public GameObject attackObj;

    public float attackDamage;
    public float attackDamageBase = 1f;
    public float attackDamageModified = 0f;

    public bool barrier;

    public List<PowerUpObj> powerUps;

    public void AddPu(PowerUpObj pu)
    {
        pu.power.ForEach(pow =>
        {
            switch (pow.type)
            {
                case PowerType.Heal:
                    hp += Mathf.RoundToInt(pow.value);
                    if (hp > maxHp)
                        hp = maxHp;
                    break;
                case PowerType.Barrier:
                    barrier = true;
                    break;
                case PowerType.Health:
                case PowerType.Speed:
                case PowerType.ShootSpeed:
                case PowerType.ShootFlySpeed:
                case PowerType.ShootDamage:
                case PowerType.ShootLevel:
                    powerUps.Add(pu);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        });
        CalStats();
    }

    public void CalStats()
    {
        speedModified = 0f;
        maxHpModified = 0;
        attackDelayModified = 0f;
        attackDamageModified = 0f;
        foreach (var pow in powerUps)
            pow.power.ForEach((power) =>
            {
                switch (power.type)
                {
                    case PowerType.Health:
                        maxHpModified += Mathf.RoundToInt(power.value);
                        break;
                    case PowerType.Speed:
                        speedModified += power.value;
                        break;
                    case PowerType.ShootSpeed:
                        attackDelayModified += power.value;
                        break;
                    case PowerType.ShootFlySpeed:
                        Debug.LogError("Not implemented");
                        break;
                    case PowerType.ShootDamage:
                        attackDamageModified += power.value;
                        break;
                    case PowerType.ShootLevel:
                        attackLevel += Mathf.RoundToInt(power.value);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });

        maxHp = maxHpBase + maxHpModified;
        moveSpeed = moveSpeedBase + ((speedModified/100) * moveSpeedBase);
        attackDelay = attackDelayBase - ((attackDelayModified/100) * attackDelayBase);
        attackDamage = attackDamageBase + ((attackDamageModified/100) * attackDamageBase);
    }
}