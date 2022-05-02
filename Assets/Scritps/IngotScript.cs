using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngotScript : MonoBehaviour
{
    void Start()
    {
        if (tag == "Bugs Ingot")
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if (tag == "Lead Ingot")
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (tag == "Gold Ingot")
        {
            GetComponent<SpriteRenderer>().color = new Color(250f, 255f, 0f);
        }
        if (gameObject.name == "P Bugs")
        {
            GetComponent<SpriteRenderer>().color = Color.grey;
        }
        if (gameObject.name == "P Lead")
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (gameObject.name == "P Gold")
        {
            GetComponent<SpriteRenderer>().color = new Color(250f, 255f, 0f);
        }
    }
}
