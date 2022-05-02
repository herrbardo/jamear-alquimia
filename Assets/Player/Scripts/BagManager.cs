using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Vial")
        {
            GameEvents.GetInstance().OnRequestAddVialToInventory(other.gameObject);
        }
    }
}
