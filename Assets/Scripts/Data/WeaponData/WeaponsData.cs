﻿using UnityEngine;

//not use
[CreateAssetMenu(fileName = "WeaponsData", menuName = "Data/Weapons/WeaponsData")]
public sealed class WeaponsData : ScriptableObject
{
    public Weapon[] weapons;

    internal WeaponManager weaponManager;

    public void Initialization()
    {
        weaponManager = FindObjectOfType<WeaponManager>();
    }
}