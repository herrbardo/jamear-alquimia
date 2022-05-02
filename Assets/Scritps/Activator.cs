using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public FluidSpawner fluidSpawner;
    public AudioSource soundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            fluidSpawner.isPouring = true;
            soundEffect.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            fluidSpawner.isPouring = false;
        }
    }
}
