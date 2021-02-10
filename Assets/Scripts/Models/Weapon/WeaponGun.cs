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
                    AudioManager.Instance.PlaySound(ClipManager.OUT_OF_AMMUNITION_CLIP);
                }
            }
        }
    }

    protected override void ProcessAttack()
    {
        switch (weapon.typeWeaponName)
        {
            case TypeWeaponName.Pistol:
                AudioManager.Instance.PlaySound(ClipManager.PISTOL_CLIP);
                break;
            case TypeWeaponName.MP5:
                AudioManager.Instance.PlaySound(ClipManager.MP5_CLIP);
                break;
            case TypeWeaponName.M3:
                AudioManager.Instance.PlaySound(ClipManager.M3_CLIP);
                break;
            case TypeWeaponName.AK47:
                AudioManager.Instance.PlaySound(ClipManager.AK47_CLIP);
                break;
            case TypeWeaponName.AWP:
                AudioManager.Instance.PlaySound(ClipManager.AWP_CLIP);
                break;
            case TypeWeaponName.Fire:
                AudioManager.Instance.PlaySound(ClipManager.FIRE_CLIP);
                break;
            case TypeWeaponName.Rocket:
                AudioManager.Instance.PlaySound(ClipManager.ROCKET_CLIP);
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