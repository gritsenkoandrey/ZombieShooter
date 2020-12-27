using System.Collections.Generic;
using UnityEngine;


public class PoolObject : MonoBehaviour
{
    public static PoolObject Instance;

    private List<GameObject> _bulletPrefabs = new List<GameObject>();
    private List<GameObject> _bulletRocketPrefabs = new List<GameObject>();
    private List<GameObject> _bulletFallFX = new List<GameObject>();

    private void Awake()
    {
        MakeInstance();
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

    public void CreateBulletAndBulletFallFX(GameObject bullet, GameObject bulletFX, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject tempBullet = Instantiate(bullet);
            GameObject tempBulletFX = Instantiate(bulletFX);

            _bulletPrefabs.Add(tempBullet);
            _bulletFallFX.Add(tempBulletFX);

            _bulletPrefabs[i].SetActive(false);
            _bulletFallFX[i].SetActive(false);
        }
    }

    public void CreateBulletRocket(GameObject bulletRocket, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject tempBulletRocket = Instantiate(bulletRocket);
            _bulletRocketPrefabs.Add(tempBulletRocket);
            _bulletRocketPrefabs[i].SetActive(false);
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

    public void SpawnBullet(Vector3 pos, Vector3 dir, Quaternion rot, TypeWeaponName weaponName)
    {
        if (weaponName != TypeWeaponName.Rocket)
        {
            for (int i = 0; i < _bulletPrefabs.Count; i++)
            {
                if (!_bulletPrefabs[i].activeInHierarchy)
                {
                    _bulletPrefabs[i].SetActive(true);
                    _bulletPrefabs[i].transform.position = pos;
                    _bulletPrefabs[i].transform.rotation = rot;
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < _bulletRocketPrefabs.Count; i++)
            {
                if (!_bulletRocketPrefabs[i].activeInHierarchy)
                {
                    _bulletRocketPrefabs[i].SetActive(true);
                    _bulletRocketPrefabs[i].transform.position = pos;
                    _bulletRocketPrefabs[i].transform.rotation = rot;
                    break;
                }
            }
        }
    }
}