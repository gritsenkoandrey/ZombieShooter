using UnityEngine;


public sealed class PlayerMove : PlayerBase
{
    private Rigidbody2D _myBody;
    private Vector2 _tempScale;
    private Vector2 _tempPos;
    private float _maxPosY;
    private float _minPosY;
    private float _maxPosX;
    private float _minPosX;

    protected override void Awake()
    {
        base.Awake();

        InitializePlayerMoveData();
        playerAnimations = GetComponent<PlayerAnimations>();
        _myBody = GetComponent<Rigidbody2D>();
    }

    public override void Execute(Vector2 dir)
    {
        if (isPlayerAlive)
        {
            Move(dir);
            Flip(dir);
            Animation();
        }
    }

    private void InitializePlayerMoveData()
    {
        _maxPosY = playerData.maxPosY;
        _minPosY = playerData.minPosY;
        _maxPosX = playerData.maxPosX;
        _minPosX = playerData.minPosX;
    }

    private void Move(Vector2 dir)
    {
        _tempPos = transform.position;

        if (dir.x > 0)
        {
            _myBody.velocity = new Vector2(playerData.GetSpeed(), _myBody.velocity.y);

            if (_tempPos.x > _maxPosX)
            {
                _tempPos.x = _maxPosX;
            }
        }
        else if (dir.x < 0)
        {
            _myBody.velocity = new Vector2(-playerData.GetSpeed(), _myBody.velocity.y);

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
            _myBody.velocity = new Vector2(_myBody.velocity.x, playerData.GetSpeed());

            if (_tempPos.y > _maxPosY)
            {
                _tempPos.y = _maxPosY;
            }
        }
        else if (dir.y < 0)
        {
            _myBody.velocity = new Vector2(_myBody.velocity.x, - playerData.GetSpeed());

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
            playerAnimations.PlayerRunAnimation(true);
        }
        else if (_myBody.velocity.x == 0 && _myBody.velocity.y == 0)
        {
            playerAnimations.PlayerRunAnimation(false);
        }
    }
}