using UnityEngine;


public sealed class UIInterface
{
    private UICounter _uICounter;
    private GameMenuBehaviour _gameMenu;
    private MainMenuBahaviour _mainMenu;

    public UICounter UICounter
    {
        get
        {
            if (!_uICounter)
            {
                _uICounter = Object.FindObjectOfType<UICounter>();
            }
            return _uICounter;
        }
    }

    public GameMenuBehaviour GameMenu
    {
        get
        {
            if (!_gameMenu)
            {
                _gameMenu = Object.FindObjectOfType<GameMenuBehaviour>();
            }
            return _gameMenu;
        }
    }

    public MainMenuBahaviour MainMenu
    {
        get
        {
            if (!_mainMenu)
            {
                _mainMenu = Object.FindObjectOfType<MainMenuBahaviour>();
            }
            return _mainMenu;
        }
    }
}