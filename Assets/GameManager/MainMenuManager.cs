using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    private void Start()
    {
        GlobalDJ.Instance.PlaySong(0);
    }

    public void Play()
    {
        TransitionEvents.GetInstance().OnTransitionToScene("BKPSCENE");
    }

    public void Options()
    {

    }

    public void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
