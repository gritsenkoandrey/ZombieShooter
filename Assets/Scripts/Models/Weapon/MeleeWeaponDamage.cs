using UnityEngine;


public class MeleeWeaponDamage : MonoBehaviour
{
    [SerializeField] private LayerMask _colLayer;
    [SerializeField] private float _radius = 3.0f;
    private readonly Collider2D[] _colliders = new Collider2D[1];

    private void Update()
    {
        if (gameObject.activeSelf)
        {
            int target = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _colliders, _colLayer);

            for (int i = 0; i < target; i++)
            {
                if (_colliders[i].CompareTag(TagManager.GetTag(TypeTag.ZOMBIE_HEALTH)))
                {
                    _colliders[i].transform.root.GetComponent<ZombieController>()
                        .DealDamage(GetComponentInParent<WeaponBase>().weapon.damage);
                    //after one lucky hit to disable the collider
                    gameObject.SetActive(false);
                }
            }
        }
    }
}