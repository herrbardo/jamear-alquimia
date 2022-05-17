using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents
{
    static UIEvents instance;

    private UIEvents()
    {

    }

    public static UIEvents GetInstance()
    {
        if(instance == null)
            instance = new UIEvents();
        return instance;
    }

    public delegate void UIButtonPressedDelegate(string buttonName, bool enabledSwitch);
    public UIButtonPressedDelegate UIButtonPressed;

    public void OnUIButtonPressed(string buttonName, bool enabledSwitch)
    {
        if(UIButtonPressed != null)
            UIButtonPressed(buttonName, enabledSwitch);
    }
}