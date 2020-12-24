using System;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;


[CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
public class Data : ScriptableObject
{
    [SerializeField] private string _playerDataPath = null;
    [SerializeField] private string _weaponDataPath = null;

    private static PlayerData _playerData;
    private static WeaponData _weaponData;

    private static readonly Lazy<Data> _instance = new Lazy<Data>(() => Load<Data>("Data/" + typeof(Data).Name));
    public static Data Instance { get { return _instance.Value; } }

    public PlayerData PlayerData
    {
        get
        {
            if (_playerData == null)
            {
                _playerData = Load<PlayerData>("Data/" + Instance._playerDataPath);
            }
            return _playerData;
        }
    }

    public WeaponData WeaponData
    {
        get
        {
            if (_weaponData == null)
            {
                _weaponData = Load<WeaponData>("Data/" + Instance._weaponDataPath);
            }
            return _weaponData;
        }
    }

    private static T Load<T>(string resourcesPath) where T : Object =>
        CustomResources.Load<T>(Path.ChangeExtension(resourcesPath, null));
}