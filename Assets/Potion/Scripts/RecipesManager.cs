using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecipesManager : MonoBehaviour
{
    [SerializeField] List<GameObject> PotionSlots;
    [SerializeField] List<PotionItem> Potions;

    int lastIndexUnlocked;
    List<Potions> unlockedPotions;


    private void Awake()
    {
        GameEvents.GetInstance().PotionUnlocked += PotionUnlocked;
    }

    private void OnDestroy()
    {
        GameEvents.GetInstance().PotionUnlocked -= PotionUnlocked;
    }

    void Start()
    {
        lastIndexUnlocked = -1;
        unlockedPotions = new List<Potions>();
    }

    void PotionUnlocked(Potions potion)
    {
        lastIndexUnlocked++;
        GameObject currentSlot = PotionSlots[lastIndexUnlocked];
        PotionSlot slotManager = currentSlot.GetComponent<PotionSlot>();
        PotionItem currentPotion = Potions.Where(p => p.Type == potion).FirstOrDefault();

        if(currentPotion == null)
        {
            Debug.Log(potion.ToString() + " no está en la lista");
            return;
        }
        
        if(unlockedPotions.Contains(potion))
            return;
        
        slotManager.SetPotion(currentPotion);
        unlockedPotions.Add(potion);
    }
}
