using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player/PlayerData")]
public sealed class PlayerData : ScriptableObject
{
    [Header("PlayerHealth")]

    [SerializeField] private float _maxHealth = 100.0f;

    [Header("PlayerMove")]

    [SerializeField] private float _speed = 1.5f;

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
        return _maxHealth;
    }
}