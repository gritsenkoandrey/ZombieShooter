﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameMenuBehaviour : BaseUI
{
    [SerializeField] private Button _pauseButton = null;
    [SerializeField] private Button _resumeButton = null;
    [SerializeField] private Button _quitButton = null;
    [SerializeField] private Button _continueButtonEnd = null;
    [SerializeField] private Button _continueButtonLost = null;

    [SerializeField] private GameObject _pausePanel = null;
    [SerializeField] private GameObject _gameEndPanel = null;
    [SerializeField] private GameObject _gameLostPanel = null;

    private void OnEnable()
    {
        _pauseButton.onClick.AddListener(PauseGame);
        _resumeButton.onClick.AddListener(ResumeGame);
        _quitButton.onClick.AddListener(QuitGame);
        _continueButtonEnd.onClick.AddListener(QuitGame);
        _continueButtonLost.onClick.AddListener(QuitGame);
    }

    private void OnDisable()
    {
        _pauseButton.onClick.RemoveListener(PauseGame);
        _resumeButton.onClick.RemoveListener(ResumeGame);
        _quitButton.onClick.RemoveListener(QuitGame);
        _continueButtonEnd.onClick.RemoveListener(QuitGame);
        _continueButtonLost.onClick.RemoveListener(QuitGame);
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

    public void ShowGameEndPanel()
    {
        _gameEndPanel.SetActive(true);
        Services.Instance.TimeService.SetTimeScale(0.0f);
    }

    public void ShowGameLostPanel()
    {
        _gameLostPanel.SetActive(true);
        Services.Instance.TimeService.SetTimeScale(0.0f);
    }
}