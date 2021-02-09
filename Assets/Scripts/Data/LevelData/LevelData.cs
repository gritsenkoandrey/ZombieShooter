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

    [Header("Game Level")]
    public GameObject gameLevelOne;
    public GameObject gameLevelTwo;
    public GameObject gameLevelThree;
    public GameObject gameLevelFour;

    [Header("Fence")]
    [SerializeField] private GameObject _fence = null;

    /// <summary>
    /// Instantiate Game Level and Game UI
    /// </summary>
    public void SpawnGameLevel(GameObject ui, GameObject background)
    {
        Instantiate(ui);
        Instantiate(background);
    }

    public void SpawnFences()
    {
        Instantiate(_fence, new Vector2(1.0f, -0.33f), Quaternion.identity);
        Instantiate(_fence, new Vector2(1.0f, -1.633f), Quaternion.identity);
        Instantiate(_fence, new Vector2(1.0f, -3.233f), Quaternion.identity);
    }
}