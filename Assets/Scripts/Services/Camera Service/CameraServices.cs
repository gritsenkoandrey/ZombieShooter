﻿using UnityEngine;


public sealed class CameraServices
{
    public Camera CameraMain { get; private set; }

    public CameraServices()
    {
        SetCamera(Camera.main);
    }

    public void SetCamera(Camera camera)
    {
        CameraMain = camera;
    }
}