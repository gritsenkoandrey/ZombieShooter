using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player/PlayerData")]
public sealed class PlayerData : ScriptableObject
{
    [SerializeField] private GameObject _tommy = null;
    [SerializeField] private GameObject _marry = null;

    [Header("PlayerHealth")]
    private float _health;
    [SerializeField] private float _healthTommy = 80.0f;
    [SerializeField] private float _healthMarry = 60.0f;

    [Header("PlayerMove")]
    private float _speed;
    [SerializeField] private float _speedTommy = 1.5f;
    [SerializeField] private float _speedMarry = 2.5f;

    public float maxPosY = 0.5f;
    public float minPosY = -3.4f;
    public float maxPosX = 153.0f;
    public float minPosX = -13.0f;

    internal PlayerBase playerBase;

    public void Initialization()
    {
        playerBase = GameObject.FindGameObjectWithTag(TagManager.GetTag(TypeTag.PLAYER))
            .GetComponent<PlayerMove>();
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public float GetHealth()
    {
        return _health;
    }

    public void SpawnTommy()
    {
        _speed = _speedTommy;
        _health = _healthTommy;
        Instantiate(_tommy);
    }

    public void SpawnMarry()
    {
        _speed = _speedMarry;
        _health = _healthMarry;
        Instantiate(_marry);
    }
}