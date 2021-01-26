using UnityEngine;


[CreateAssetMenu(fileName = "LevelData", menuName = "Data/GamePlay/LevelData")]
public sealed class LevelData : ScriptableObject
{
    [Header("Level Controller")]
    public int zombieCount;
    public int stepCount;
    public int timerCount;
    public TypeGameGoal typeGameGoal;
    public TypeTargetZombie typeTargetZombie;

    [Header("UI Canvas")]
    public GameObject levelOneUI;
    public GameObject levelTwoUI;
    public GameObject levelThreeUI;
    public GameObject levelFourUI;

    public void ShowUI(GameObject obj)
    {
        Instantiate(obj);
    }

    public void HideUI(GameObject obj)
    {
        Destroy(obj);
    }
}