using UnityEngine;
using Interfaces;


public class LevelController : IInitialization, IExecute
{
    public static LevelController Instanse;

    public TypeGameGoal typeGameGoal;
    public TypeTargetZombie typeTargetZombie;

    public LevelController()
    {
        Instanse = this;
    }

    public void Initialization()
    {
        typeTargetZombie = TypeTargetZombie.FENCE;
        typeGameGoal = TypeGameGoal.WALK_TO_GOAL_STEPS;
    }

    public void Execute()
    {
        //todo
    }
}