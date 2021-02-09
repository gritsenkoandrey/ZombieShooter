using UnityEngine;


public sealed class FenceHealth : FenceBase
{
    [SerializeField] private int _health = 100;
    [SerializeField] private ParticleSystem _woodBreakFX = null;
    [SerializeField] private ParticleSystem _woodExplodeFX = null;

    private TimeRemaining _timeRemainingDeactivateFence;
    private readonly float _timeToDeactivate = 0.2f;

    public int Health { get { return _health; } private set { _health = value; } }

    protected override void Awake()
    {
        base.Awake();

        _timeRemainingDeactivateFence = new TimeRemaining(DeactivateFence, _timeToDeactivate);
    }

    public void DealDamage(int damage)
    {
        Health -= damage;
        _woodBreakFX.Play();

        if (Health <= 0)
        {
            isFenceAlive = false;
            _woodExplodeFX.Play();
            EventBus.RaiseEvent<IFenceDie>(h => h.FenceDestroy());
            _timeRemainingDeactivateFence.AddTimeRemaining();
        }
    }

    private void DeactivateFence()
    {
        gameObject.SetActive(false);
        _timeRemainingDeactivateFence.RemoveTimeRemaining();
    }
}