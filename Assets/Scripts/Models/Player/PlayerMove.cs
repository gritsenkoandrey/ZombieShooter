using UnityEngine;


public sealed class PlayerMove : PlayerBase
{
    private PlayerData _playerData;
    private PlayerAnimations _playerAnimations;

    private Rigidbody2D _myBody;
    private Vector2 _tempScale;

    private Vector2 _tempPos;
    private float _maxPosY;
    private float _minPosY;
    private float _maxPosX;
    private float _minPosX;

    private void Awake()
    {
        InitializePlayerData();

        _myBody = GetComponent<Rigidbody2D>();
        _playerAnimations = GetComponent<PlayerAnimations>();
    }

    public void Execute(Vector2 dir)
    {
        if (!IsPlayerDead)
        {
            Move(dir);
            Flip(dir);
            Animation();
        }
    }

    private void Move(Vector2 dir)
    {
        _tempPos = transform.position;

        if (dir.x > 0)
        {
            _myBody.velocity = new Vector2(_playerData.GetSpeed(), _myBody.velocity.y);

            if (_tempPos.x > _maxPosX)
            {
                _tempPos.x = _maxPosX;
            }
        }
        else if (dir.x < 0)
        {
            _myBody.velocity = new Vector2(-_playerData.GetSpeed(), _myBody.velocity.y);

            if (_tempPos.x < _minPosX)
            {
                _tempPos.x = _minPosX;
            }
        }
        else
        {
            _myBody.velocity = new Vector2(0f, _myBody.velocity.y);
        }

        if (dir.y > 0)
        {
            _myBody.velocity = new Vector2(_myBody.velocity.x, _playerData.GetSpeed());

            if (_tempPos.y > _maxPosY)
            {
                _tempPos.y = _maxPosY;
            }
        }
        else if (dir.y < 0)
        {
            _myBody.velocity = new Vector2(_myBody.velocity.x, -_playerData.GetSpeed());

            if (_tempPos.y < _minPosY)
            {
                _tempPos.y = _minPosY;
            }
        }
        else
        {
            _myBody.velocity = new Vector2(_myBody.velocity.x, 0f);
        }

        transform.position = _tempPos;
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

    private void InitializePlayerData()
    {
        _playerData = Data.Instance.PlayerData;
        _maxPosY = _playerData.maxPosY;
        _minPosY = _playerData.minPosY;
        _maxPosX = _playerData.maxPosX;
        _minPosX = _playerData.minPosX;
    }
}