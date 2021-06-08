using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float moveSpeedBase = 5f;
    public float speedModified;
    public float moveSpeed;

    public int hp = 5;
    public int maxHp;
    public int maxHpBase = 5;
    public int maxHpModified;

    public float attackDelay;
    public float attackDelayBase = 0.75f;
    public float attackDelayModified;

    public int attackLevel = 1;
    public GameObject attackObj;

    public float attackDamage;
    public float attackDamageBase = 1f;
    public float attackDamageModified;

    public bool barrier;

    public List<PowerUpObj> powerUps;


    private Player.Player _player;

    private void Start()
    {
        _player = GetComponent<Player.Player>();
    }

    public void AddPu(PowerUpObj pu)
    {
        pu.power.ForEach(pow =>
        {
            switch (pow.type)
            {
                case PowerType.Heal:
                    _player.Heal(Mathf.RoundToInt(pow.value));
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
            pow.power.ForEach(power =>
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
        moveSpeed = moveSpeedBase + speedModified / 100 * moveSpeedBase;
        attackDelay = attackDelayBase - attackDelayModified / 100 * attackDelayBase;
        attackDamage = attackDamageBase + attackDamageModified / 100 * attackDamageBase;
    }
}