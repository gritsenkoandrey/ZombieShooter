using UnityEngine;


public class ZombieDamage : ZombieBase
{
    [SerializeField] private float _radius = 1.0f;
    [SerializeField] private int _damage = 3;
    private readonly Collider2D[] _colliders = new Collider2D[1];
    private int _countTarget;

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            AttackPlayer();
            AttackFence();
        }
    }

    private void AttackPlayer()
    {
        if (!PlayerBase.IsPlayerDead)
        {
            _countTarget = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _colliders, LayerManager.ZombieAttackLayer);

            for (int i = 0; i < _countTarget; i++)
            {
                if (_colliders[i].CompareTag(TagManager.GetTag(TypeTag.PLAYER_HEALTH)))
                {
                    _colliders[i].GetComponent<PlayerHealth>().DealDamage(_damage);
                    gameObject.SetActive(false);
                }
            }
        }
    }

    private void AttackFence()
    {
        if (!FenceBase.IsFenceDestroy)
        {
            _countTarget = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _colliders, LayerManager.ZombieAttackLayer);

            for (int i = 0; i < _countTarget; i++)
            {
                if (_colliders[i].CompareTag(TagManager.GetTag(TypeTag.FENCE)))
                {
                    _colliders[i].GetComponent<FenceHealth>().DealDamage(_damage);
                    gameObject.SetActive(false);
                }
            }
        }
    }
}