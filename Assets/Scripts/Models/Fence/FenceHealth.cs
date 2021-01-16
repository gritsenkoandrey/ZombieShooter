using System.Collections;
using UnityEngine;


public class FenceHealth : FenceBase
{
    [SerializeField] private int _health = 100;
    [SerializeField] private ParticleSystem _woodBreakFX = null;
    [SerializeField] private ParticleSystem _woodExplodeFX = null;
    private readonly WaitForSeconds _timeToDestroyFence = new WaitForSeconds(0.2f);

    public int Health { get { return _health; } private set { _health = value; } }

    public void DealDamage(int damage)
    {
        Health -= damage;
        _woodBreakFX.Play();

        if (Health <= 0)
        {
            IsFenceDestroy = true;
            _woodExplodeFX.Play();
            StartCoroutine(DeactivateGameobject());
        }
    }

    private IEnumerator DeactivateGameobject()
    {
        yield return _timeToDestroyFence;
        gameObject.SetActive(false);
    }
}