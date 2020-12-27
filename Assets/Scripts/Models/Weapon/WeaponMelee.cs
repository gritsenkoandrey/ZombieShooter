using UnityEngine;


public sealed class WeaponMelee : WeaponBase
{
    public override void CallAttack()
    {
        if (Time.time > lastShot + weapon.fireRate)
        {
            ProcessAttack();
            playerAnimations.PlayerAttackAnimation();
            lastShot = Time.time;
        }
    }

    protected override void ProcessAttack()
    {
        //base.ProcessAttack();
    }
}