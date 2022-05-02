using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    private bool isFree = true;

    public VialSpawner vialSpawner;

    private void OnMouseDown()
    {
        if (isFree)
        {
            vialSpawner.isPouring = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Vial")
        {
            isFree = false;
            Debug.Log(isFree);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Vial")
        {
            isFree = true;
            Debug.Log(isFree);
        }
    }
}
