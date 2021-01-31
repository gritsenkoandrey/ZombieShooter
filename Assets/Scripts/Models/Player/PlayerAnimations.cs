using UnityEngine;


public class PlayerAnimations : PlayerBase
{
    private Animator _animator;

    protected override void Awake()
    {
        base.Awake();
        _animator = GetComponent<Animator>();
    }

    public void PlayerRunAnimation(bool isRun)
    {
        _animator.SetBool(NameManager.RUN_PARAMETER, isRun);
    }

    public void PlayerAttackAnimation()
    {
        _animator.SetTrigger(NameManager.ATTACK_PARAMETER);
    }

    public void PlayerSwitchWeaponAnimation(int typeWeapon)
    {
        _animator.SetInteger(NameManager.TYPE_WEAPON_PARAMETER, typeWeapon);
        _animator.SetTrigger(NameManager.SWITH_PARAMETER);
    }

    public void PlayerHurtAnimation()
    {
        _animator.SetTrigger(NameManager.GET_HURT_PARAMETER);
    }

    public void PlayerDeadAnimation()
    {
        _animator.SetTrigger(NameManager.DEAD_PARAMETER);
    }
}