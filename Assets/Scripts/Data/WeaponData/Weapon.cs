using UnityEngine;


[CreateAssetMenu(fileName = "WeaponsData", menuName = "Data/Weapons/Weapon")]
public sealed class Weapon : ScriptableObject
{
    [Header("Weapon Name")]
    public TypeWeaponName typeWeaponName;

    [Header("Type Attack")]
    public TypeControlAttack typeControlAttack;

    [Header("Type Weapon")]
    public TypeWeapon typeWeapon;

    [Header("Damage")]
    [Range(0, 100)] public int damage;
    [Range(0, 100)] public int criticalDamage;

    [Header("Rate")]
    [Range(0.01f, 1.0f)] public float fireRate;
    [Range(0, 100)] public int criticalRate;

    [Header("Gun Index")]
    public int gunIndex;

    [Header("Bullet")]
    public int maxBullet;
}