using System;
using UnityEngine;


[Serializable]
public struct DefaultConfig
{
    public TypeControlAttack typeControlAttack;
    public TypeWeapon typeWeapon;

    [Range(0, 100)] public int damage;
    [Range(0, 100)] public int criticalDamage;

    [Range(0.01f, 1.0f)] public float fireRate;
    [Range(0, 100)] public int criticalRate;
}