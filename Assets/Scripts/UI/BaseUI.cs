﻿using System;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseUI : MonoBehaviour
{
    public Action ShowUI = delegate { };
    public Action HideUI = delegate { };

    public abstract void Show();
    public abstract void Hide();

    //private Dictionary<Type, IPartUI> _partMainMenu;

    //protected virtual void Awake()
    //{
    //    _partMainMenu = new Dictionary<Type, IPartUI>(5);
    //    var partMainMenus = GetComponents<MonoBehaviour>();

    //    foreach (var mainMenu in partMainMenus)
    //    {
    //        if (mainMenu is IPartUI partUI)
    //        {
    //            _partMainMenu.Add(partUI.Type, partUI);
    //        }
    //    }
    //}

    //public T GetPart<T>() where T : IPartUI
    //{
    //    return (T)_partMainMenu[typeof(T)];
    //}
}