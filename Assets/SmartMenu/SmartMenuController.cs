﻿using System;
using Assets.VirtualProfiler;

namespace Assets.SmartMenu
{

    public class SmartMenuController
    {
        private readonly ISmartMenu _defaultMenu;
        private ISmartMenu _nextMenu;

        public SmartMenuController(ISmartMenu defaultMenu)
        {
            _defaultMenu = defaultMenu;
            _nextMenu = defaultMenu;
        }

        public void OnGUI()
        {
            _nextMenu = _nextMenu == null ? CreateDefaultMenu() : CreateNextMenu();
        }

        protected ISmartMenu CreateDefaultMenu()
        {
            try
            {
                return _defaultMenu.CreateMenu();
            }
            catch (Exception e)
            { // TODO KPH: do something here?  Log?
                Logger.Warning("Exception while generating default menu.", e);
            }

            return _defaultMenu.CreateMenu();
        }

        protected ISmartMenu CreateNextMenu()
        {
            try
            {
                return _nextMenu.CreateMenu();
            }
            catch (Exception e)
            {
                Logger.Error("There was a problem generating the next menu!", e);
                return _defaultMenu.CreateMenu();
            }
        }

    }

}
