using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorManager : MonoBehaviour
{
    public void GoToHerrbardoScene()
    {
        SceneManager.LoadScene("HerrBardoTest");
    }

    public void GoToNikezScene()
    {
        SceneManager.LoadScene("BKPSCENE");
    }
}
