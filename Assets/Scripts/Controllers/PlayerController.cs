using Interfaces;
using UnityEngine;

public class PlayerController : BaseController, IInitialization, IPlayerDie
{
    public void Initialization()
    {
        EventBus.Subscribe(this);
    }

    public void PlayerDie()
    {
        Interface.GameMenu.ShowGameLostPanel();
        Data.Instance.LevelData.typeGameGoal = TypeGameGoal.GAME_OVER;
    }
}
