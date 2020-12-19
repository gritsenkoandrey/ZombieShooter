﻿using UnityEngine;


public class WeaponBase : MonoBehaviour
{
    public DefaultConfig defaultConfig;
    public TypeWeaponName weaponName;

    protected PlayerAnimations playerAnimations;
    protected float lastShot;
    public int gunIndex;
    public int currentBullet;
    public int bulletMax;

    private void Awake()
    {
        playerAnimations = GetComponentInParent<PlayerAnimations>();
        currentBullet = bulletMax;
    }

    public void CallAttack()
    {
        if (Time.time > lastShot + defaultConfig.fireRate)
        {

        }
    }

    public virtual void ProcessAttack() { }
}