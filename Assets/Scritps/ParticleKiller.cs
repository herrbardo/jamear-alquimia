using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleKiller : MonoBehaviour
{
    public bool isMixer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Water")
        {
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "Oil")
        {
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "Mercury")
        {
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "Salt")
        {
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "Phos")
        {
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "Arsenic")
        {
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "P_Salt")
        {
            Destroy(collision.gameObject);
        }
        if (collision.collider.tag == "P_Phos")
        {
            Destroy(collision.gameObject);
        }
        if (collision.collider.name == "P_Arsenic")
        {
            Destroy(collision.gameObject);
        }
        if (isMixer)
        {
            if (collision.collider.name == "P Bugs")
            {
                Destroy(collision.gameObject);
            }
            if (collision.collider.name == "P Lead")
            {
                Destroy(collision.gameObject);
            }
            if (collision.collider.name == "P Gold")
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
