using Interfaces;
using UnityEngine;


public sealed class LevelController : BaseController, IExecute, IInitialization, IEnemyDie, IStartLevel
{
    //public int coinCount;

    private int _zombieCount;
    private int _stepCount;
    private int _timerCount;

    private LevelData _levelData;

    private float _distance;
    private int _initialStepCount;
    private Transform _playerTarget;
    private Vector3 _playerPreviousPos;
    private Vector3 _playerCurrentPos;

    private TimeRemaining _timerCountdown;
    private readonly float _timeCountdownLeft = 1.0f;

    private bool _isStartLevel = false;

    public void Initialization()
    {
        InitializationData();
        EventBus.Subscribe(this);
    }

    public void Execute()
    {
        CountPlayerMovement();
    }

    public void EnemyDie()
    {
        if (_levelData.typeGameGoal == TypeGameGoal.KILL_ZOMBIE)
        {
            _zombieCount--;
            UIInterface.UICounter.ShowCounter(_zombieCount);

            if (_zombieCount <= 0)
            {
                Debug.Log("Game Over");
            }
        }
    }

    public void StartLevel()
    {
        if (!_isStartLevel)
        {
            if (Data.Instance.LevelData.typeGameGoal == TypeGameGoal.KILL_ZOMBIE)
            {
                _levelData.ShowUI(_levelData.levelOneUI);
                UIInterface.UICounter.ShowCounter(_zombieCount);
            }
            else if (Data.Instance.LevelData.typeGameGoal == TypeGameGoal.WALK_TO_GOAL_STEPS)
            {
                _levelData.ShowUI(_levelData.levelTwoUI);
                _playerTarget = GameObject.FindGameObjectWithTag(TagManager.GetTag(TypeTag.PLAYER)).transform;
                _playerPreviousPos = _playerTarget.position;
                _initialStepCount = _stepCount;
                UIInterface.UICounter.ShowCounter(_stepCount);
            }
            else if (Data.Instance.LevelData.typeGameGoal == TypeGameGoal.DEFEND_FENCE || _levelData.typeGameGoal == TypeGameGoal.TIMER_COUNTDOWN)
            {
                if (Data.Instance.LevelData.typeGameGoal == TypeGameGoal.DEFEND_FENCE)
                {
                    _levelData.ShowUI(_levelData.levelThreeUI);
                }
                else
                {
                    _levelData.ShowUI(_levelData.levelFourUI);
                }
                _timerCountdown = new TimeRemaining(TimerCountdawn, _timeCountdownLeft, true);

                UIInterface.UICounter.ShowCounter(_timerCount);
                _timerCountdown.AddTimeRemaining();
            }

            _isStartLevel = true;
        }
    }

    private void TimerCountdawn()
    {
        _timerCount--;

        UIInterface.UICounter.ShowCounter(_timerCount);

        if (_timerCount <= 0)
        {
            Debug.Log("Game Over");
            _timerCountdown.RemoveTimeRemaining();
        }
    }

    private void CountPlayerMovement()
    {
        if (Data.Instance.LevelData.typeGameGoal == TypeGameGoal.WALK_TO_GOAL_STEPS)
        {
            if (_playerTarget)
            {
                _playerCurrentPos = _playerTarget.position;
                _distance = Mathf.Abs(_playerCurrentPos.x - _playerPreviousPos.x);

                if (_playerCurrentPos.x > _playerPreviousPos.x)
                {
                    if (_distance > 1)
                    {
                        _stepCount--;

                        if (_stepCount <= 0)
                        {
                            Debug.Log("Game Over");
                        }
                        _playerPreviousPos = _playerTarget.position;
                    }
                }
                else if (_playerCurrentPos.x < _playerPreviousPos.x)
                {
                    if (_distance > 0.8f)
                    {
                        _stepCount++;

                        if (_stepCount >= _initialStepCount)
                        {
                            _stepCount = _initialStepCount;
                        }
                        _playerPreviousPos = _playerTarget.position;
                    }
                }
                UIInterface.UICounter.ShowCounter(_stepCount);
            }
        }
    }

    private void InitializationData()
    {
        _levelData = Data.Instance.LevelData;

        _zombieCount = Data.Instance.LevelData.zombieCount;
        _stepCount = Data.Instance.LevelData.stepCount;
        _timerCount = Data.Instance.LevelData.timerCount;

        _levelData.typeTargetZombie = TypeTargetZombie.NONE;
        _levelData.typeGameGoal = TypeGameGoal.NONE;
    }
}