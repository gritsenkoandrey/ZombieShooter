using System.Collections;
using UnityEngine;


public sealed class WeaponGun : WeaponBase
{
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private ParticleSystem _fxShot = null;

    private Collider2D _fireCollider;

    private WaitForSeconds _waitTime = new WaitForSeconds(0.02f);
    private WaitForSeconds _fireColliderWait = new WaitForSeconds(0.02f);

    private float _currentBullet;

    protected override void Awake()
    {
        base.Awake();
        _currentBullet = weapon.maxBullet;
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
                    = PoolObject.Instance.SpawnBulletFallFX(_spawnPoint.transform.position, Quaternion.identity);
                bulletFallFX.transform.localScale
                    = (transform.root.eulerAngles.y > 1.0f) ? new Vector3(-1.0f, 1.0f, 1.0f) : new Vector3(1.0f, 1.0f, 1.0f);
                StartCoroutine(WaitForShootEffect());
            }
            PoolObject.Instance.SpawnBullet(_spawnPoint.transform.position,
                new Vector3(-transform.root.localScale.x, 0.0f, 0.0f), _spawnPoint.rotation, weapon.typeWeaponName, weapon);
        }
        else if (weapon.typeWeaponName == TypeWeaponName.Fire)
        {
            _fireCollider = _spawnPoint.GetComponent<BoxCollider2D>();
            StartCoroutine(ActiveFireCollider());
        }
    }

    private IEnumerator WaitForShootEffect()
    {
        yield return _waitTime;
        _fxShot.Play();
    }

    private IEnumerator ActiveFireCollider()
    {
        _fireCollider.enabled = true;
        _fxShot.Play();
        yield return _fireColliderWait;
        _fireCollider.enabled = false;
    }
}