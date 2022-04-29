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

    public event CustomerReachedSpotDelegate CustomerReachedSpot;

    public void OnCustomerReachedSpot()
    {
        if(CustomerReachedSpot!= null)
            CustomerReachedSpot();
    }
}
