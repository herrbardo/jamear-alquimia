using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void Button_Click()
    {
        UIEvents.GetInstance().OnUIButtonPressed(gameObject.name, true);
    }
}
