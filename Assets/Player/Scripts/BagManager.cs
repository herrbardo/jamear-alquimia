using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Vial")
        {
            GameEvents.GetInstance().OnRequestAddVialToInventory(collision.gameObject);
        }
    }

}
