using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public FluidSpawner fluidSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            Debug.Log("Pouring fluids!");
            fluidSpawner.isPouring = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            Debug.Log("Stopped pouring fluids!");
            fluidSpawner.isPouring = false;
        }
    }
}
