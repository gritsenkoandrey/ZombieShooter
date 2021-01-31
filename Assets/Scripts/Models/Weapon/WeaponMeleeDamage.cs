using UnityEngine;


public class WeaponMeleeDamage : WeaponMelee
{
    [SerializeField] private float _radius = 0.25f;
    private readonly Collider2D[] _colliders = new Collider2D[1];
    private int _countTarget;

    private void Update()
    {
        AttackZombie();
    }

    private void AttackZombie()
    {
        if (gameObject.activeSelf)
        {
            _countTarget = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _colliders, LayerManager.ZombieHealthLayer);

            for (int i = 0; i < _countTarget; i++)
            {
                if (_colliders[i].CompareTag(TagManager.GetTag(TypeTag.ZOMBIE_HEALTH)))
                {
                    _colliders[i].transform.root.GetComponent<ZombieHealth>().DealDamage(weapon.damage);
                    //after one lucky hit to disable the collider
                    gameObject.SetActive(false);
                }
            }
        }
    }
}