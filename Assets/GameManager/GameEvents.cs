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

    public delegate PotionItem CustomerReachedSpotDelegate();
    public delegate void PotionUnlockedDelegate(Potions potion);
    public delegate void RequestAddVialToInventoryDelegate(GameObject vial);
    public delegate void RequestNewCustomerDelegate();

    public event CustomerReachedSpotDelegate CustomerReachedSpot;
    public event PotionUnlockedDelegate PotionUnlocked;
    public event RequestAddVialToInventoryDelegate RequestAddVialToInventory;
    public event RequestNewCustomerDelegate RequestNewCustomer;

    public PotionItem OnCustomerReachedSpot()
    {
        if(CustomerReachedSpot!= null)
            return CustomerReachedSpot();
        
        return null;
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

    public void OnRequestNewCustomer()
    {
        if(RequestNewCustomer != null)
            RequestNewCustomer();
    }
}
