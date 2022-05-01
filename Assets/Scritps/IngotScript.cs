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
    }
}
