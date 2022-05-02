using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGravity : MonoBehaviour
{
    public float gravityDirection; // -1 a 1, -1 invierte gravedad 1 devuelve a normal


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Arsenic")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityDirection;
        }
        if (collision.tag == "Phos")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityDirection;
        }
        if (collision.tag == "Salt")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = gravityDirection;
        }
    }
}
