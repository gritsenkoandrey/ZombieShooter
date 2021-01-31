using UnityEngine;


public class ZombieAnimation : ZombieBase
{
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();

        _animator = GetComponent<Animator>();
    }

    public void ZombieAttackAnimation()
    {
        _animator.SetTrigger(NameManager.ATTACK_PARAMETER);
    }

    public void ZombieHurtAnimation()
    {
        _animator.SetTrigger(NameManager.GET_HURT_PARAMETER);
    }

    public void ZombieDeadAnimation()
    {
        _animator.SetTrigger(NameManager.DEAD_PARAMETER);
    }
}