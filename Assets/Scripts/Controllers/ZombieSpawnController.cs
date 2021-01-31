using Interfaces;
using UnityEngine;


public sealed class ZombieSpawnController : BaseController, IInitialization, IExecute, ISpawnZombie
{
    private TimeRemaining _timeRemainingSpawnNextZombie;
    private readonly float _timeToSpawnNextZombie = 3.5f;

    private float _xPos;
    private float _yPos;

    private bool _isSpawn = false;

    public void Initialization()
    {
        EventBus.Subscribe(this);
        _timeRemainingSpawnNextZombie = new TimeRemaining(StartSpawningZombies, _timeToSpawnNextZombie, true);
    }

    public void Execute()
    {
        ZombieList.Execute();
    }

    //срабатывает при клике на выбор уровня один раз
    public void SpawnZombie()
    {
        if (!_isSpawn)
        {
            _timeRemainingSpawnNextZombie.AddTimeRemaining();
            _isSpawn = true;
        }
    }

    private void StartSpawningZombies()
    {
        if (Data.Instance.LevelData.typeGameGoal == TypeGameGoal.DEFEND_FENCE)
        {
            _xPos = Services.Instance.CameraServices.CameraMain.transform.position.x;
            _xPos += 15.0f;

            _yPos = Random.Range(Data.Instance.ZombieData.minPosY, Data.Instance.ZombieData.maxPosY);

            Data.Instance.ZombieData.SpawnZombie(_xPos, _yPos);
        }

        if (Data.Instance.LevelData.typeGameGoal == TypeGameGoal.KILL_ZOMBIE
              || Data.Instance.LevelData.typeGameGoal == TypeGameGoal.TIMER_COUNTDOWN
              || Data.Instance.LevelData.typeGameGoal == TypeGameGoal.WALK_TO_GOAL_STEPS)
        {
            _xPos = Services.Instance.CameraServices.CameraMain.transform.position.x;
            if (Random.Range(0, 2) == 1)
            {
                _xPos += Random.Range(10.0f, 15.0f);
            }
            else
            {
                _xPos -= Random.Range(10.0f, 15.0f);
            }

            _yPos = Random.Range(Data.Instance.ZombieData.minPosY, Data.Instance.ZombieData.maxPosY);

            Data.Instance.ZombieData.SpawnZombie(_xPos, _yPos);
        }

        if (Data.Instance.LevelData.typeGameGoal == TypeGameGoal.GAME_OVER)
        {
            _timeRemainingSpawnNextZombie.RemoveTimeRemaining();
        }
    }
}