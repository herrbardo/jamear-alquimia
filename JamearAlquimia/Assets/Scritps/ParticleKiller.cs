using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleKiller : MonoBehaviour
{
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
    }
}
