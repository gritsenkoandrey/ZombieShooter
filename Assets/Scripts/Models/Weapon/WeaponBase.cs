using UnityEngine;


public abstract class WeaponBase : MonoBehaviour
{
    public Weapon weapon;

    protected PlayerAnimations playerAnimations;
    protected float lastShot;

    protected virtual void Awake()
    {
        playerAnimations = GetComponentInParent<PlayerAnimations>();
    }

    public virtual void CallAttack() { }
    protected virtual void ProcessAttack() { }
}