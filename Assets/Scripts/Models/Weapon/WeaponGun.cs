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

    private float _currentBullet;

    protected override void Awake()
    {
        base.Awake();
        _currentBullet = weapon.maxBullet;
    }

    private void Start()
    {
        if (!GameplayController.Instance.isBulletAndFXCreated)
        {
            if (weapon.typeWeaponName != TypeWeaponName.Fire && weapon.typeWeaponName != TypeWeaponName.Rocket)
            {
                PoolObject.Instance.CreateBulletAndBulletFallFX(bulletPrefab, fxBulletFall, 100);
                GameplayController.Instance.isBulletAndFXCreated = true;
            }
        }

        if (!GameplayController.Instance.isRocketBulletCreated)
        {
            if (weapon.typeWeaponName == TypeWeaponName.Rocket)
            {
                PoolObject.Instance.CreateBulletRocket(bulletPrefab, 100);
                GameplayController.Instance.isRocketBulletCreated = true;
            }
        }
    }

    public override void CallAttack()
    {
        if (Time.time > lastShot + weapon.fireRate)
        {
            if (weapon.typeWeapon != TypeWeapon.Melee)
            {
                if (_currentBullet > 0)
                {
                    ProcessAttack();
                    playerAnimations.PlayerAttackAnimation();
                    lastShot = Time.time;
                    _currentBullet--;
                }
                else
                {
                    //play no ammo sound
                }
            }
        }
    }

    protected override void ProcessAttack()
    {
        //base.ProcessAttack();
        switch (weapon.typeWeaponName)
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

        if (transform != null && weapon.typeWeaponName != TypeWeaponName.Fire)
        {
            if (weapon.typeWeaponName != TypeWeaponName.Rocket)
            {
                GameObject bulletFallFX
                    = PoolObject.Instance.SpawnBulletFallFX(spawnPoint.transform.position, Quaternion.identity);
                bulletFallFX.transform.localScale
                    = (transform.root.eulerAngles.y > 1.0f) ? new Vector3(-1.0f, 1.0f, 1.0f) : new Vector3(1.0f, 1.0f, 1.0f);
                StartCoroutine(WaitForShootEffect());
            }
            PoolObject.Instance.SpawnBullet(spawnPoint.transform.position,
                new Vector3(-transform.root.localScale.x, 0.0f, 0.0f), spawnPoint.rotation, weapon.typeWeaponName);
        }
        else
        {
            StartCoroutine(ActiveFireCollider());
        }
    }

    private IEnumerator WaitForShootEffect()
    {
        yield return waitTime;
        fxShot.Play();
    }

    private IEnumerator ActiveFireCollider()
    {
        //fireCollider.enabled = true;
        fxShot.Play();
        yield return fireColliderWait;
        //fireCollider.enabled = false;
    }
}