using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionUnlocker : MonoBehaviour
{
    [SerializeField] Potions PotionToUnlock;

    int count = 0;

    public void Unlock()
    {
        if(count > 8)
            return;
        GameEvents.GetInstance().OnPotionUnlocked(PotionToUnlock);
        PotionToUnlock = PotionToUnlock + 1;
        count++;
    }
}
