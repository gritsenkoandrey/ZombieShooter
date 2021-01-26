using UnityEngine;
using UnityEngine.UI;


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
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(PauseGame);
        _resumeButton.onClick.RemoveListener(ResumeGame);
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
}