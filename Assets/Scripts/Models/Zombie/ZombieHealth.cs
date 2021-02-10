using System;
using UnityEngine;
using Random = UnityEngine.Random;


[RequireComponent(typeof(ZombieAnimation))]
public sealed class ZombieHealth : ZombieBase
{
    [SerializeField] private Zombie _zombie = null;

    private int _health;

    [SerializeField] private GameObject[] _fxDead = null;
    private ParticleSystem _particle;
    [SerializeField] private Colectable _coin = null;

    private TimeRemaining _timeRemainingDeactivateZombie;
    private readonly float _timeToDeactivateZombie = 2.0f;

    public override event Action<ZombieBase> OnDieChange;

    public int Health
    {
        get { return _health; }
        private set { _health = value; }
    }

    protected override void Awake()
    {
        base.Awake();
        _health = _zombie.health;
        _timeRemainingDeactivateZombie = new TimeRemaining(DeactivateZombie, _timeToDeactivateZombie);
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag(TagManager.GetTag(TypeTag.BULLET))
            || target.CompareTag(TagManager.GetTag(TypeTag.ROCKET_MISSILE)))
        {
            DealDamage(target.gameObject.GetComponent<Bullet>().Damage);

            if (target.CompareTag(TagManager.GetTag(TypeTag.ROCKET_MISSILE)))
            {
                target.gameObject.GetComponent<Bullet>().ExplosionFX();
            }

            target.gameObject.SetActive(false);
        }

        if (target.CompareTag(TagManager.GetTag(TypeTag.FIRE_BULLET)))
        {
            DealDamage(target.gameObject.GetComponentInParent<WeaponBase>().weapon.damage);
        }
    }

    public void DealDamage(int damage)
    {
        zombieAnimation.ZombieHurtAnimation();
        Health -= damage;

        if (Health <= 0)
        {
            DeathZombie();
        }
    }

    private void DeactivateZombie()
    {
        EventBus.RaiseEvent<IZombieDie>(h => h.ZombieDestroy());
        if (Random.Range(0, 10) > 6)
        {
            Instantiate(_coin, transform.position, Quaternion.identity);
            AudioManager.Instance.PlaySound(ClipManager.COIN_DROP_CLIP);
        }
        _timeRemainingDeactivateZombie.RemoveTimeRemaining();
        gameObject.SetActive(false);
    } 

    private void DeathZombie()
    {
        OnDieChange?.Invoke(this);
        zombieAnimation.ZombieDeadAnimation();
        AudioManager.Instance.PlaySound(ClipManager.ZOMBIE_DIE_CLIP);
        _timeRemainingDeactivateZombie.AddTimeRemaining();
    }

    //use in ZombieDeadSMB
    public void ActivateDeadEffect(int index)
    {
        _fxDead[index].SetActive(true);

        if (_fxDead[index].TryGetComponent(out _particle))
        {
            _particle.Play();
        }
    }
}