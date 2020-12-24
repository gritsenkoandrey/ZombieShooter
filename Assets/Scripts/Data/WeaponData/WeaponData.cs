using UnityEngine;


[CreateAssetMenu(fileName = "WeaponsData", menuName = "Data/Weapons/WeaponsData")]
public sealed class WeaponData : ScriptableObject
{
    [SerializeField] private SerializeWeaponData[] _weapons;

    public WeaponInfo GetWeaponInfo(WeaponDataType weaponDataType)
    {
        WeaponInfo result = default;

        foreach (SerializeWeaponData weaponData in _weapons)
        {
            if (weaponData.weaponDataType == weaponDataType)
            {
                result = weaponData.weaponInfo;
            }
        }

        return result;
    }
}