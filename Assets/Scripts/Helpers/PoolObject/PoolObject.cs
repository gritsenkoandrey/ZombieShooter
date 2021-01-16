using System.Collections.Generic;
using UnityEngine;


public class PoolObject : MonoBehaviour
{
    public static PoolObject Instance = null;

    [SerializeField] private GameObject _bulletPrefab = null;
    [SerializeField] private GameObject _bulletRocketPrefab = null;
    [SerializeField] private GameObject _fxBulletFall = null;

    private List<GameObject> _bulletPrefabs = new List<GameObject>();
    private List<GameObject> _bulletRocketPrefabs = new List<GameObject>();
    private List<GameObject> _bulletFallFX = new List<GameObject>();

    private GameObject _objParent = null;

    private void Awake()
    {
        MakeInstance();

        _objParent = new GameObject();
        _objParent.name = "Pool";

        CreateBullet(_bulletPrefab, 20, _objParent.transform);
        CreateBulletRocket(_bulletRocketPrefab, 5, _objParent.transform);
        CreateFallFX(_fxBulletFall, 20, _objParent.transform);
    }

    private void OnDisable()
    {
        Instance = null;
    }

    private void MakeInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void CreateBullet(GameObject bullet, int count, Transform parent)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject tempBullet = Instantiate(bullet);
            tempBullet.transform.SetParent(parent);
            _bulletPrefabs.Add(tempBullet);
            _bulletPrefabs[i].SetActive(false);
        }
    }

    private void CreateBulletRocket(GameObject bulletRocket, int count, Transform parent)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject tempBulletRocket = Instantiate(bulletRocket);
            tempBulletRocket.transform.SetParent(parent);
            _bulletRocketPrefabs.Add(tempBulletRocket);
            _bulletRocketPrefabs[i].SetActive(false);
        }
    }

    private void CreateFallFX(GameObject bulletFX, int count, Transform parent)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject tempBulletFX = Instantiate(bulletFX);
            tempBulletFX.transform.SetParent(parent);
            _bulletFallFX.Add(tempBulletFX);
            _bulletFallFX[i].SetActive(false);
        }
    }

    public GameObject SpawnBulletFallFX(Vector3 pos, Quaternion rot)
    {
        for (int i = 0; i < _bulletFallFX.Count; i++)
        {
            if (!_bulletFallFX[i].activeInHierarchy)
            {
                _bulletFallFX[i].SetActive(true);
                _bulletFallFX[i].transform.position = pos;
                _bulletFallFX[i].transform.rotation = rot;

                return _bulletFallFX[i];
            }
        }
        return null;
    }

    public void SpawnBullet(Vector3 pos, Vector3 dir, Quaternion rot, TypeWeaponName weaponName, Weapon weapon)
    {
        if (weaponName != TypeWeaponName.Rocket && weaponName != TypeWeaponName.Fire)
        {
            for (int i = 0; i < _bulletPrefabs.Count; i++)
            {
                if (!_bulletPrefabs[i].activeInHierarchy)
                {
                    _bulletPrefabs[i].SetActive(true);
                    _bulletPrefabs[i].transform.position = pos;
                    _bulletPrefabs[i].transform.rotation = rot;

                    _bulletPrefabs[i].GetComponent<Bullet>().AddForce(dir);

                    SetBulletDamage(weaponName, _bulletPrefabs[i], weapon);
                    break;
                }
            }
        }
        else if (weaponName == TypeWeaponName.Rocket)
        {
            for (int i = 0; i < _bulletRocketPrefabs.Count; i++)
            {
                if (!_bulletRocketPrefabs[i].activeInHierarchy)
                {
                    _bulletRocketPrefabs[i].SetActive(true);
                    _bulletRocketPrefabs[i].transform.position = pos;
                    _bulletRocketPrefabs[i].transform.rotation = rot;

                    _bulletRocketPrefabs[i].GetComponent<Bullet>().AddForce(dir);

                    SetBulletDamage(weaponName, _bulletRocketPrefabs[i], weapon);
                    break;
                }
            }
        }
    }

    private void SetBulletDamage(TypeWeaponName weaponName, GameObject bullet, Weapon weapon)
    {
        switch (weaponName)
        {
            case TypeWeaponName.Pistol:
                bullet.GetComponent<Bullet>().Damage = weapon.damage;
                break;
            case TypeWeaponName.MP5:
                bullet.GetComponent<Bullet>().Damage = weapon.damage;
                break;
            case TypeWeaponName.M3:
                bullet.GetComponent<Bullet>().Damage = weapon.damage;
                break;
            case TypeWeaponName.AK47:
                bullet.GetComponent<Bullet>().Damage = weapon.damage;
                break;
            case TypeWeaponName.AWP:
                bullet.GetComponent<Bullet>().Damage = weapon.damage;
                break;
            case TypeWeaponName.Rocket:
                bullet.GetComponent<Bullet>().Damage = weapon.damage;
                break;
        }
    }
}