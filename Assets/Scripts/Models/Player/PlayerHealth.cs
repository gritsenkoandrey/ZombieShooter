using UnityEngine;


public class PlayerHealth : PlayerBase
{
    private int _health;
    [SerializeField] private GameObject[] _bloodFX = null;
    private PlayerAnimations _playerAnim;

    public int Health { get { return _health; } private set { _health = value; } }

    private void Awake()
    {
        _playerAnim = GetComponentInParent<PlayerAnimations>();
        _health = (int)Data.Instance.PlayerData.GetHealth();
    }

    public void DealDamage(int damage)
    {
        Health -= damage;
        LevelController.Instanse.PlayerLifeCounter(Health);
        _playerAnim.PlayerHurtAnimation();

        if (Health <= 0)
        {
            IsPlayerDead = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
            _playerAnim.PlayerDeadAnimation();
            _bloodFX[Random.Range(0, _bloodFX.Length)].SetActive(true);
        }
    }
}