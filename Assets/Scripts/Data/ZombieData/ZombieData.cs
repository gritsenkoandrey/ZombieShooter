using UnityEngine;


[CreateAssetMenu(fileName = "ZombieData", menuName = "Data/Zombie/ZombieData")]
public class ZombieData : ScriptableObject
{
    public GameObject[] _zombiesPrefabs;

    public float maxPosY = -0.4f;
    public float minPosY = -3.7f;

    public void SpawnZombie(float xPos, float yPos)
    {
        Instantiate(_zombiesPrefabs[Random.Range(0, _zombiesPrefabs.Length)],
            new Vector3(xPos, yPos, 0.0f), Quaternion.identity);
    }
}