using System;
using UnityEngine;


public abstract class ZombieBase : MonoBehaviour
{
    protected ZombieMove zombieMove;
    protected ZombieAnimation zombieAnimation;
    protected ZombieHealth zombieHealth;
    protected ZombieAttack zombieAttack;

    public virtual event Action<ZombieBase> OnDieChange;

    protected virtual void Awake()
    {
        zombieMove = GetComponent<ZombieMove>();
        zombieAnimation = GetComponent<ZombieAnimation>();
        zombieHealth = GetComponent<ZombieHealth>();
        zombieAttack = GetComponent<ZombieAttack>();
    }

    public virtual void Execute() { }

    protected void DestroyZombie()
    {
        gameObject.SetActive(false);
    }
}