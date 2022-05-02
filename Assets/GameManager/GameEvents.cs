using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents
{
    private static GameEvents instance;

    private GameEvents(){}

    public static GameEvents GetInstance()
    {
        if(instance == null)
            instance = new GameEvents();
        return instance;
    }

    public delegate void CustomerReachedSpotDelegate();
    public delegate void PotionUnlockedDelegate(Potions potion);
    public delegate void RequestAddVialToInventoryDelegate(GameObject vial);

    public event CustomerReachedSpotDelegate CustomerReachedSpot;
    public event PotionUnlockedDelegate PotionUnlocked;
    public event RequestAddVialToInventoryDelegate RequestAddVialToInventory;

    public void OnCustomerReachedSpot()
    {
        if(CustomerReachedSpot!= null)
            CustomerReachedSpot();
    }

    public void OnPotionUnlocked(Potions potion)
    {
        if(PotionUnlocked != null)
            PotionUnlocked(potion);
    }

    public void OnRequestAddVialToInventory(GameObject vial)
    {
        if(RequestAddVialToInventory != null)
            RequestAddVialToInventory(vial);
    }
}
