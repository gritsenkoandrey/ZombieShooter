using System.Collections;
using UnityEngine;


public sealed class WeaponGun : WeaponBase
{
    public Transform spawnPoint;
    public GameObject bulletPrefab;
    public ParticleSystem fxShot;
    public GameObject fxBulletFall;

    private Collider2D fireCollider;

    private WaitForSeconds waitTime = new WaitForSeconds(0.02f);
    private WaitForSeconds fireColliderWait = new WaitForSeconds(0.02f);


    public override void ProcessAttack()
    {
        //base.ProcessAttack();
        switch (weaponName)
        {
            case TypeWeaponName.Pistol:
                break;
            case TypeWeaponName.MP5:
                break;
            case TypeWeaponName.M3:
                break;
            case TypeWeaponName.AK47:
                break;
            case TypeWeaponName.AWP:
                break;
            case TypeWeaponName.Fire:
                break;
            case TypeWeaponName.Rocket:
                break;
        }
    }

    private IEnumerator WaitForShootEffect()
    {
        yield return waitTime;
        fxShot.Play();
    }

    private IEnumerator ActiveFireCollider()
    {
        fireCollider.enabled = true;
        yield return fireColliderWait;
        fireCollider.enabled = false;
    }
}