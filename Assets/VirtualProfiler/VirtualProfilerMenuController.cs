﻿using System;
using Assets.SmartMenu;
using UnityEngine;

namespace Assets.VirtualProfiler
{

    public class VirtualProfilerMenuController : MonoBehaviour
    {
        private readonly SmartMenuController _menuController = new SmartMenuController(new MainMenuView());

        public void OnGUI()
        {
            try
            {
                _menuController.OnGUI();
            }
            catch (Exception e)
            {
                Logger.Error("An exception occurred while navigating the menu.", e);
            }
        }

    }
}