using System.Collections;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    private int _damage;
    private float _speed;
    private Rigidbody2D _body;

    private IEnumerator _coroutineDeactivate;
    private WaitForSeconds _waitForTimeAlive = new WaitForSeconds(2.0f);

    [SerializeField] private GameObject _rocketExplosion = null;

    public int Damage
    {
        get { return _damage; }
        set { _damage = value; }
    }

    private void OnEnable()
    {
        if (CompareTag(TagManager.GetTag(TypeTag.ROCKET_MISSILE)))
        {
            _speed = 350.0f;
        }
        else
        {
            _speed = 2000.0f;
        }

        _coroutineDeactivate = WaitForDeactivate();
        StartCoroutine(_coroutineDeactivate);
    }

    private void OnDisable()
    {
        if (_coroutineDeactivate != null)
        {
            StopCoroutine(_coroutineDeactivate);
        }

        _speed = 0f;
    }

    private IEnumerator WaitForDeactivate()
    {
        yield return _waitForTimeAlive;
        gameObject.SetActive(false);
    }

    public void AddForce(Vector3 dir)
    {
        if (!_body)
        {
            _body = GetComponent<Rigidbody2D>();
        }
        _body.AddForce(dir * _speed);
    }

    public void ExplosionFX()
    {
        Instantiate(_rocketExplosion, transform.position, Quaternion.identity);
        AudioManager.Instance.PlaySound(ClipManager.ROCKET_EXPLOSION_CLIP);
    }
}