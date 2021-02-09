using System;
using Interfaces;
using UnityEngine;


public sealed class LevelController : BaseController, IExecute, IInitialization, IZombieDie, IFenceDie, IStartLevel, ICleanUp
{
    private int _coinCount;
    private int _zombieCount;
    private int _fenceCount;
    private readonly int _maxFence = 3;
    private int _stepCount;
    private int _timerCount;

    private LevelData _levelData;

    private float _distance;
    private int _initialStepCount;
    private Transform _playerTarget;
    private Vector3 _playerPreviousPos;
    private Vector3 _playerCurrentPos;

    private TimeRemaining _timeRemainingTimer;
    private readonly float _timeToTimer = 1.0f;

    private bool _isStartLevel = false;

    public void Initialization()
    {
        EventBus.Subscribe(this);
        InitializationData();
    }

    public void Execute()
    {
        Steps();
    }

    //IZombieDie
    public void ZombieDestroy()
    {
        if (_levelData.typeGameGoal == TypeGameGoal.KILL_ZOMBIE)
        {
            _zombieCount--;
            Interface.UICounter.ShowCounter(_zombieCount);

            if (_zombieCount <= 0)
            {
                GameOver();
            }
        }
    }

    //IFenceDie
    public void FenceDestroy()
    {
        if (_levelData.typeGameGoal == TypeGameGoal.DEFEND_FENCE)
        {
            _fenceCount--;

            if (_fenceCount <= 0)
            {
                GameOver();
            }
        }
    }

    //IStartLevel
    public void StartLevel()
    {
        if (!_isStartLevel)
        {
            switch (_levelData.typeGameGoal)
            {
                case TypeGameGoal.KILL_ZOMBIE:
                    _levelData.SpawnGameLevel(_levelData.levelOneUI, _levelData.gameLevelOne);
                    _zombieCount = _levelData.zombieCount;
                    Interface.UICounter.ShowCounter(_zombieCount);
                    break;
                case TypeGameGoal.WALK_TO_GOAL_STEPS:
                    _levelData.SpawnGameLevel(_levelData.levelTwoUI, _levelData.gameLevelTwo);
                    _playerTarget = GameObject.FindGameObjectWithTag(TagManager.GetTag(TypeTag.PLAYER)).transform;
                    _stepCount = _levelData.stepCount;
                    _playerPreviousPos = _playerTarget.position;
                    _initialStepCount = _stepCount;
                    Interface.UICounter.ShowCounter(_stepCount);
                    break;
                case TypeGameGoal.DEFEND_FENCE:
                    _levelData.SpawnGameLevel(_levelData.levelThreeUI, _levelData.gameLevelThree);
                    _levelData.SpawnFences();
                    _fenceCount = _maxFence;
                    _timeRemainingTimer = new TimeRemaining(Timer, _timeToTimer, true);
                    _timerCount = _levelData.timerCount;
                    Interface.UICounter.ShowCounter(_timerCount);
                    _timeRemainingTimer.AddTimeRemaining();
                    break;
                case TypeGameGoal.TIMER_COUNTDOWN:
                    _levelData.SpawnGameLevel(_levelData.levelFourUI, _levelData.gameLevelFour);
                    _timeRemainingTimer = new TimeRemaining(Timer, _timeToTimer, true);
                    _timerCount = _levelData.timerCount;
                    Interface.UICounter.ShowCounter(_timerCount);
                    _timeRemainingTimer.AddTimeRemaining();
                    break;
            }

            _isStartLevel = true;
        }
    }

    private void Timer()
    {
        _timerCount--;

        Interface.UICounter.ShowCounter(_timerCount);

        if (_timerCount <= 0)
        {
            GameOver();
            _timeRemainingTimer.RemoveTimeRemaining();
        }
    }

    private void Steps()
    {
        if (_levelData.typeGameGoal == TypeGameGoal.WALK_TO_GOAL_STEPS)
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
                            GameOver();
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
                Interface.UICounter.ShowCounter(_stepCount);
            }
        }
    }

    private void InitializationData()
    {
        _levelData = Data.Instance.LevelData;
        _levelData.typeTargetZombie = TypeTargetZombie.NONE;
        _levelData.typeGameGoal = TypeGameGoal.NONE;
    }

    private void GameOver()
    {
        Debug.Log("Game Over");
        Interface.GameMenu.ShowGameOverPanel();
        _levelData.typeGameGoal = TypeGameGoal.GAME_OVER;
    }

    public void Cleaner()
    {
        EventBus.Unsubscribe(this);
    }
}