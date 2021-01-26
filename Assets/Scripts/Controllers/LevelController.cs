using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class LevelController : IExecute, IEventBus
{
    public static LevelController Instanse;

    public TypeGameGoal typeGameGoal;
    public TypeTargetZombie typeTargetZombie;

    public int coinCount;

    private int _zombieCount;
    private int _stepCount;
    private int _timerCount;

    private LevelData _levelData;
    private PlayerData _playerData;

    private Text _zombieCounterText;
    private Text _timerCounterText;
    private Text _stepCounterText;
    private Image _playerLife;

    private float _distance;
    private int _initialStepCount;
    private Transform _playerTarget;
    private Vector3 _playerPreviousPos;
    private Vector3 _playerCurrentPos;

    private TimeRemaining _timerCountdown;
    private readonly float _timeCountdownLeft = 1.0f;


    public LevelController()
    {
        if (Instanse != null)
        {
            return;
        }
        Instanse = this;

        InitializationData();

        EventBus.Subscribe(this);

        if (typeGameGoal != TypeGameGoal.NONE || typeGameGoal != TypeGameGoal.GAME_OVER)
        {
            InitializationUILavel();
        }
    }

    public void Execute()
    {
        CountPlayerMovement();
    }

    public void Call()
    {
        if (typeGameGoal == TypeGameGoal.KILL_ZOMBIE)
        {
            //сделать через событие Event Bus
            _zombieCount--;
            _zombieCounterText.text = _zombieCount.ToString();

            if (_zombieCount <= 0)
            {
                Debug.Log("Game Over");
            }
        }
    }

    public void ZombieDied()
    {
    }

    public void PlayerLifeCounter(float fillPercentage)
    {
        //вынести отображение здоровья через view model
        fillPercentage /= _playerData.GetHealth();
        _playerLife.fillAmount = fillPercentage;
    }

    private void TimerCountdawn()
    {
        _timerCount--;
        _timerCounterText.text = _timerCount.ToString();

        if (_timerCount <= 0)
        {
            Debug.Log("Game Over");
            _timerCountdown.RemoveTimeRemaining();
        }
    }

    private void CountPlayerMovement()
    {
        if (typeGameGoal == TypeGameGoal.WALK_TO_GOAL_STEPS)
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
            _stepCounterText.text = _stepCount.ToString();
        }
    }

    private void InitializationData()
    {
        _levelData = Data.Instance.LevelData;
        _playerData = Data.Instance.PlayerData;

        _zombieCount = _levelData.zombieCount;
        _stepCount = _levelData.stepCount;
        _timerCount = _levelData.timerCount;

        typeTargetZombie = _levelData.typeTargetZombie;
        typeGameGoal = _levelData.typeGameGoal;
    }

    private void InitializationUILavel()
    {
        if (typeGameGoal == TypeGameGoal.KILL_ZOMBIE)
        {
            _levelData.ShowUI(_levelData.levelOneUI);
            _zombieCounterText = GameObject.FindGameObjectWithTag(TagManager.GetTag(TypeTag.COUNTER)).GetComponent<Text>();
            _playerLife = GameObject.FindGameObjectWithTag(TagManager.GetTag(TypeTag.LIFE_FULL)).GetComponent<Image>();
            _zombieCounterText.text = _zombieCount.ToString();
        }
        else if (typeGameGoal == TypeGameGoal.WALK_TO_GOAL_STEPS)
        {
            _levelData.ShowUI(_levelData.levelTwoUI);
            _playerTarget = GameObject.FindGameObjectWithTag(TagManager.GetTag(TypeTag.PLAYER)).transform;
            _playerPreviousPos = _playerTarget.position;
            _initialStepCount = _stepCount;
            _stepCounterText = GameObject.FindGameObjectWithTag(TagManager.GetTag(TypeTag.COUNTER)).GetComponent<Text>();
            _stepCounterText.text = _stepCount.ToString();
            _playerLife = GameObject.FindGameObjectWithTag(TagManager.GetTag(TypeTag.LIFE_FULL)).GetComponent<Image>();
        }
        else if (typeGameGoal == TypeGameGoal.DEFEND_FENCE || typeGameGoal == TypeGameGoal.TIMER_COUNTDOWN)
        {
            if (typeGameGoal == TypeGameGoal.DEFEND_FENCE)
            {
                _levelData.ShowUI(_levelData.levelThreeUI);
            }
            else
            {
                _levelData.ShowUI(_levelData.levelFourUI);
            }
            _timerCountdown = new TimeRemaining(TimerCountdawn, _timeCountdownLeft, true);
            _timerCounterText = GameObject.FindGameObjectWithTag(TagManager.GetTag(TypeTag.COUNTER)).GetComponent<Text>();
            _timerCounterText.text = _timerCount.ToString();
            _playerLife = GameObject.FindGameObjectWithTag(TagManager.GetTag(TypeTag.LIFE_FULL)).GetComponent<Image>();
            _timerCountdown.AddTimeRemaining();
        }
        else
        {
            return;
        }
    }
}