using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player/PlayerData")]
public sealed class PlayerData : ScriptableObject
{
    [SerializeField] private float _speed = 1.5f;
    [HideInInspector] public PlayerMove PlayerMove;

    public void Initialization()
    {
        PlayerMove = FindObjectOfType<PlayerMove>();
    }

    public float GetSpeed()
    {
        return _speed;
    }
}