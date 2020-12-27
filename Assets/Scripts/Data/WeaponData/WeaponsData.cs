using UnityEngine;


[CreateAssetMenu(fileName = "WeaponsData", menuName = "Data/Weapons/WeaponsData")]
public sealed class WeaponsData : ScriptableObject
{
    public Weapon[] weapons;
}