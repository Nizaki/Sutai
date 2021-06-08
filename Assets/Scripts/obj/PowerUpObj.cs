using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowUp", menuName = "Game/PowerUp")]
public class PowerUpObj : ScriptableObject
{
    public Sprite image;

    [Multiline] public string description;

    public List<PowerAttribute> power;
}

//test
[Serializable]
public class PowerAttribute
{
    public PowerType type;
    public float value;
}

public enum PowerType
{
    Health,
    Speed,
    Heal,
    ShootSpeed,
    ShootFlySpeed,
    ShootDamage,
    ShootLevel,
    Barrier
}