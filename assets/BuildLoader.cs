﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BuildLoader : MonoBehaviour
{
    private void Awake()
    {
        if (!Application.isEditor)
        {
            LoadPersistent();
        }
    }

    private void LoadPersistent()
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive);
    }
}
