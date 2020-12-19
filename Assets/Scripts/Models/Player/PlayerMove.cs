using UnityEngine;


public sealed class PlayerMove : MonoBehaviour
{
    private PlayerData _playerData;
    private PlayerAnimations _playerAnimations;

    private Rigidbody2D _myBody;
    private Vector3 _tempScale;

    private void Awake()
    {
        _playerData = Data.Instance.PlayerData;

        _myBody = GetComponent<Rigidbody2D>();
        _playerAnimations = GetComponent<PlayerAnimations>();
    }

    public void Execute(Vector2 dir)
    {
        Move(dir);
        Flip(dir);
        Animation();
    }

    private void Move(Vector2 dir)
    {
        if (dir.x > 0)
        {
            _myBody.velocity = new Vector2(_playerData.GetSpeed(), _myBody.velocity.y);
        }
        else if (dir.x < 0)
        {
            _myBody.velocity = new Vector2(-_playerData.GetSpeed(), _myBody.velocity.y);
        }
        else
        {
            _myBody.velocity = new Vector2(0f, _myBody.velocity.y);
        }

        if (dir.y > 0)
        {
            _myBody.velocity = new Vector2(_myBody.velocity.x, _playerData.GetSpeed());
        }
        else if (dir.y < 0)
        {
            _myBody.velocity = new Vector2(_myBody.velocity.x, -_playerData.GetSpeed());
        }
        else
        {
            _myBody.velocity = new Vector2(_myBody.velocity.x, 0f);
        }
    }

    private void Flip(Vector2 dir)
    {
        _tempScale = transform.localScale;
        if (dir.x > 0)
        {
            _tempScale.x = -1.0f;
        }
        else if (dir.x < 0)
        {
            _tempScale.x = 1.0f;
        }
        transform.localScale = _tempScale;
    }

    private void Animation()
    {
        if (_myBody.velocity.x != 0 || _myBody.velocity.y != 0)
        {
            _playerAnimations.PlayerRunAnimation(true);
        }
        else if (_myBody.velocity.x == 0 && _myBody.velocity.y == 0)
        {
            _playerAnimations.PlayerRunAnimation(false);
        }
    }
}