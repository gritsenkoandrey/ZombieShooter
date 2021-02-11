using UnityEngine;


public class PlayerHealth : PlayerBase
{
    [SerializeField] private GameObject[] _bloodFX = null;
    private TimeRemaining _timeRemainingGameLost;
    private float _timeToGameLost = 2.0f;

    private int _health;
    public int Health { get { return _health; } private set { _health = value; } }

    protected override void Awake()
    {
        base.Awake();

        playerAnimations = GetComponentInParent<PlayerAnimations>();
        _timeRemainingGameLost = new TimeRemaining(GameLost, _timeToGameLost);
        InitializationPlayerHealthData();
    }

    private void InitializationPlayerHealthData()
    {
        _health = (int)Data.Instance.PlayerData.GetHealth();
    }

    public void DealDamage(int damage)
    {
        Health -= damage;
        EventBus.RaiseEvent<ICalculateHealth>(h => h.CalculateHealth(Health));
        playerAnimations.PlayerHurtAnimation();

        if (Health <= 0)
        {
            IsPlayerAlive = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            playerAnimations.PlayerDeadAnimation();
            _bloodFX[Random.Range(0, _bloodFX.Length)].SetActive(true);
            Data.Instance.LevelData.typeGameGoal = TypeGameGoal.GAME_OVER;
            _timeRemainingGameLost.AddTimeRemaining();
        }
    }

    private void GameLost()
    {
        EventBus.RaiseEvent<IPlayerDie>(h => h.PlayerDie());
        _timeRemainingGameLost.RemoveTimeRemaining();
    }
}