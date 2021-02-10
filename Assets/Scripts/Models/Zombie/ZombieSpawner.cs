using UnityEngine;


public class ZombieSpawner : ZombieBase
{
    [SerializeField] private GameObject _zombiePrefab = null;
    [SerializeField] private Transform _spawnPoint = null;
    [SerializeField] private ParticleSystem _fxShred = null;

    private GameObject _zombie;
    private Transform _player;

    private TimeRemaining _timeRemainingZombieSpawn;
    private float _timeToSpawnZombie;

    private void OnEnable()
    {
        SpawnZombie();
    }

    private void OnDisable()
    {
        DestroySpawnPoint();
    }

    private void SpawnZombie()
    {
        _timeToSpawnZombie = Random.Range(2.5f, 4.0f);
        _timeRemainingZombieSpawn = new TimeRemaining(DestroySpawnPoint, _timeToSpawnZombie);

        _player = GameObject.FindGameObjectWithTag(TagManager.GetTag(TypeTag.PLAYER)).transform;
        _fxShred.Play();
        AudioManager.Instance.PlaySound(ClipManager.ZOMBIE_RISE_CLIP);
        _zombie = Instantiate(_zombiePrefab, _spawnPoint.position, Quaternion.identity);
        ZombieList.AddZombieToList(_zombie.GetComponent<ZombieAttack>());

        if (_zombie.transform.position.x < _player.position.x)
        {
            _zombie.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (_zombie.transform.position.x > _player.position.x)
        {
            _zombie.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        _timeRemainingZombieSpawn.AddTimeRemaining();
    }

    private void DestroySpawnPoint()
    {
        gameObject.SetActive(false);
        _timeRemainingZombieSpawn.RemoveTimeRemaining();
    }
}