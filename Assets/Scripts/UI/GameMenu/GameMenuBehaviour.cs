using UnityEngine;
using UnityEngine.UI;


public class GameMenuBehaviour : BaseUI
{
    [SerializeField] private Button _pauseButton = null;
    [SerializeField] private GameObject _pausePanel = null;
    [SerializeField] private GameObject _gameOverPanel = null;

    private void OnEnable()
    {
        //Add Listener
    }

    private void OnDisable()
    {
        //Romove Listener
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
}