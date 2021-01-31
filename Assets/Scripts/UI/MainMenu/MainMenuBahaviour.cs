using UnityEngine;
using UnityEngine.UI;


public class MainMenuBahaviour : BaseUI
{
    [SerializeField] private GameObject _characterSelectPanel = null;
    [SerializeField] private Button _openCharacterSelectPanel = null;
    [SerializeField] private Button _closeCharacterSelectPanel = null;

    [SerializeField] private Button _missionOneButton = null;
    [SerializeField] private Button _missionTwoButton = null;
    [SerializeField] private Button _missionThreeButton = null;
    [SerializeField] private Button _missionFourButton = null;

    private void OnEnable()
    {
        _openCharacterSelectPanel.onClick.AddListener(OpenCharacterSelectPanel);
        _closeCharacterSelectPanel.onClick.AddListener(CloseCharacterSelectPanel);

        _missionOneButton.onClick.AddListener(StartMissionOne);
        _missionTwoButton.onClick.AddListener(StartMissionTwo);
        _missionThreeButton.onClick.AddListener(StartMissionThree);
        _missionFourButton.onClick.AddListener(StartMissionFour);
    }

    private void OnDisable()
    {
        _openCharacterSelectPanel.onClick.RemoveListener(OpenCharacterSelectPanel);
        _closeCharacterSelectPanel.onClick.RemoveListener(CloseCharacterSelectPanel);

        _missionOneButton.onClick.RemoveListener(StartMissionOne);
        _missionTwoButton.onClick.RemoveListener(StartMissionTwo);
        _missionThreeButton.onClick.RemoveListener(StartMissionThree);
        _missionFourButton.onClick.RemoveListener(StartMissionFour);
    }

    public override void Hide()
    {
        gameObject.SetActive(false);
        HideUI.Invoke();
    }

    public override void Show()
    {
        gameObject.SetActive(true);
        ShowUI.Invoke();
    }

    private void OpenCharacterSelectPanel()
    {
        _characterSelectPanel.SetActive(true);
    }

    private void CloseCharacterSelectPanel()
    {
        _characterSelectPanel.SetActive(false);
    }

    private void StartMissionOne()
    {
        Data.Instance.LevelData.typeGameGoal = TypeGameGoal.KILL_ZOMBIE;
        Data.Instance.LevelData.typeTargetZombie = TypeTargetZombie.PLAYER;
        Next();
    }

    private void StartMissionTwo()
    {
        Data.Instance.LevelData.typeGameGoal = TypeGameGoal.DEFEND_FENCE;
        Data.Instance.LevelData.typeTargetZombie = TypeTargetZombie.FENCE;
        Next();
    }

    private void StartMissionThree()
    {
        Data.Instance.LevelData.typeGameGoal = TypeGameGoal.WALK_TO_GOAL_STEPS;
        Data.Instance.LevelData.typeTargetZombie = TypeTargetZombie.PLAYER;
        Next();
    }

    private void StartMissionFour()
    {
        Data.Instance.LevelData.typeGameGoal = TypeGameGoal.TIMER_COUNTDOWN;
        Data.Instance.LevelData.typeTargetZombie = TypeTargetZombie.PLAYER;
        Next();
    }

    private void Next()
    {
        Hide();
        EventBus.RaiseEvent<IStartLevel>(h => h.StartLevel());
        EventBus.RaiseEvent<ISpawnZombie>(h => h.SpawnZombie());
    }
}