using System;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;


[CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
public class Data : ScriptableObject
{
    [SerializeField] private string _playerDataPath = null;
    [SerializeField] private string _weaponsDataPath = null;
    [SerializeField] private string _levelDataPath = null;
    [SerializeField] private string _zombieDataPath = null;

    private static PlayerData _playerData;
    private static WeaponsData _weaponsData;
    private static LevelData _levelData;
    private static ZombieData _zombieData;

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

    public WeaponsData WeaponsData
    {
        get
        {
            if (_weaponsData == null)
            {
                _weaponsData = Load<WeaponsData>("Data/" + Instance._weaponsDataPath);
            }
            return _weaponsData;
        }
    }

    public LevelData LevelData
    {
        get
        {
            if (_levelData == null)
            {
                _levelData = Load<LevelData>("Data/" + Instance._levelDataPath);
            }
            return _levelData;
        }
    }

    public ZombieData ZombieData
    {
        get
        {
            if (_zombieData == null)
            {
                _zombieData = Load<ZombieData>("Data/" + Instance._zombieDataPath);
            }
            return _zombieData;
        }
    }

    private static T Load<T>(string resourcesPath) where T : Object =>
        CustomResources.Load<T>(Path.ChangeExtension(resourcesPath, null));
}