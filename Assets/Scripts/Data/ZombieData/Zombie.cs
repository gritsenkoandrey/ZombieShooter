using UnityEngine;

[CreateAssetMenu(fileName = "Zombie", menuName = "Data/Zombie/Zombie")]
public sealed class Zombie : ScriptableObject
{
    [Header("Name Zombie")]

    [SerializeField] private TypeZombie _typeZombie;
    [Range(5, 100)]public int health;
    [Range(1, 20)]public int damage;
    [Range(0.5f, 2.5f)]public float moveSpeed;
    [Range(0.5f, 2.5f)]public float attackSpeed;
}