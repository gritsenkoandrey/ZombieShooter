using System.Collections;
using UnityEngine;


public class ZombieController : ZombieBase
{
    private ZombieMove _zombieMove;
    private ZombieAnimation _zombieAnimation;

    private Transform _targetTransform;
    private bool _zombieCanAttack;
    private float _distanceAttack = 1.5f;
    private bool _zombieIsAlive;

    [SerializeField] private int _zombieHealth = 10;
    [SerializeField] private GameObject _damageCollider = null;
    [SerializeField] private GameObject[] _fxDead = null;
    [SerializeField] private GameObject _coinCollectable = null;
    //[SerializeField] private TypeTargetZombie _typeTargetZombie = TypeTargetZombie.NONE;

    private GameObject[] _fences;

    private float _timerAttack;

    private void Start()
    {
        _zombieMove = GetComponent<ZombieMove>();
        _zombieAnimation = GetComponent<ZombieAnimation>();
        _zombieIsAlive = true;
        ChooseTarget();
    }

    private void Update()
    {
        if (_zombieIsAlive)
        {
            CheckDistance();
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag(TagManager.GetTag(TypeTag.PLAYER_HEALTH))
            || target.CompareTag(TagManager.GetTag(TypeTag.PLAYER))
            || target.CompareTag(TagManager.GetTag(TypeTag.FENCE)))
        {
            _zombieCanAttack = true;
        }

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

    private void OnTriggerExit2D(Collider2D target)
    {
        if (target.CompareTag(TagManager.GetTag(TypeTag.PLAYER_HEALTH))
            || target.CompareTag(TagManager.GetTag(TypeTag.PLAYER))
            || target.CompareTag(TagManager.GetTag(TypeTag.FENCE)))
        {
            _zombieCanAttack = false;
        }
    }

    private void CheckDistance()
    {
        if (_targetTransform)
        {
            if ((_targetTransform.position - transform.position).sqrMagnitude > _distanceAttack)
            {
                _zombieMove.MoveZombie(_targetTransform);
            }
            else
            {
                if (_zombieCanAttack)
                {
                    _zombieAnimation.ZombieAttackAnimation();
                }
            }
        }
    }

    private IEnumerator DeactivateZombie()
    {
        yield return new WaitForSeconds(2.0f);

        //Instantiate(_coinCollectable, transform.position, Quaternion.identity);

        gameObject.SetActive(false);
    }

    public void ActivateDeadEffect(int index)
    {
        _fxDead[index].SetActive(true);

        if (_fxDead[index].TryGetComponent(out ParticleSystem particle))
        {
            particle.Play();
        }
    }

    public void DealDamage(int damage)
    {
        _zombieAnimation.ZombieHurtAnimation();
        _zombieHealth -= damage;

        if (_zombieHealth <= 0)
        {
            DeathZombie();
        }
    }

    private void DeathZombie()
    {
        _zombieIsAlive = false;
        _zombieAnimation.ZombieDeadAnimation();
        StartCoroutine(DeactivateZombie());
    }

    //use in Animation AttackMeleeWeapon
    private void ActivateDamagePoint()
    {
        _damageCollider.SetActive(true);
    }

    private void DeactivateDamagePoint()
    {
        _damageCollider.SetActive(false);
    }

    private void ChooseTarget()
    {
        if (LevelController.Instanse.typeTargetZombie == TypeTargetZombie.PLAYER)
        {
            _targetTransform = GameObject.FindGameObjectWithTag(TagManager.GetTag(TypeTag.PLAYER)).transform;
        }
        else if (LevelController.Instanse.typeTargetZombie == TypeTargetZombie.FENCE)
        {
            _fences = GameObject.FindGameObjectsWithTag(TagManager.GetTag(TypeTag.FENCE));
            _targetTransform = _fences[Random.Range(0, _fences.Length)].transform;
        }
        else
        {
            return;
        }
    }
}