using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameMenuBehaviour : BaseUI
{
    [SerializeField] private Button _pauseButton = null;
    [SerializeField] private Button _resumeButton = null;
    [SerializeField] private Button _quitButton = null;

    [SerializeField] private GameObject _pausePanel = null;
    [SerializeField] private GameObject _gameOverPanel = null;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(PauseGame);
        _resumeButton.onClick.AddListener(ResumeGame);
        _quitButton.onClick.AddListener(QuitGame);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(PauseGame);
        _resumeButton.onClick.RemoveListener(ResumeGame);
        _quitButton.onClick.RemoveListener(QuitGame);
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

    private void PauseGame()
    {
        _pausePanel.SetActive(true);
        Services.Instance.TimeService.SetTimeScale(0.0f);
    }

    private void ResumeGame()
    {
        _pausePanel.SetActive(false);
        Services.Instance.TimeService.SetTimeScale(1.0f);
    }

    private void QuitGame()
    {
        Data.Instance.LevelData.typeTargetZombie = TypeTargetZombie.NONE;
        Data.Instance.LevelData.typeGameGoal = TypeGameGoal.NONE;
        Services.Instance.TimeService.SetTimeScale(1.0f);

        SceneManager.LoadScene(0);
    }
}