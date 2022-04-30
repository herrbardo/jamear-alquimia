using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionUnlocker : MonoBehaviour
{
    [SerializeField] Potions PotionToUnlock;

    public void Unlock()
    {
        GameEvents.GetInstance().OnPotionUnlocked(PotionToUnlock);
    }
}
