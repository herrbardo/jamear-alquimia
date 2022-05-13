using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatManager : MonoBehaviour
{
    [SerializeField] Button BtnUnlockPotion;

    void Update()
    {
        BtnUnlockPotion.gameObject.SetActive(GameManager.Instance.EnableCheats);
    }
}
