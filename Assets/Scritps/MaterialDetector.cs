using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialDetector : MonoBehaviour
{
    public string powder;
    public string liquid;
    public string material;

    public bool powderOk;
    public bool liquidOk;
    public bool materialOk;

    public int components = 0;

    public CauldronScript cooked;

    private void Update()
    {
        if (cooked.isDone)
        {
            powderOk = false;
            liquidOk = false;
            materialOk = false;
            components = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if ((collision.tag == "P_Phos" || collision.tag == "P_Arsenic" || collision.tag == "P_Salt") && !powderOk)
        {
            powder = collision.tag;
            if (components < 3)
            {
                components++;
            }
            else
            {
                components = 0;
            }
            Destroy(collision.gameObject);
            powderOk = true;
        }
        if ((collision.tag == "Water" || collision.tag == "Oil" || collision.tag == "Mercury") && !liquidOk)
        {
            liquid = collision.tag;
            if (components < 3)
            {
                components++;
            }
            else
            {
                components = 0;
            }
            Destroy(collision.gameObject);
            liquidOk = true;
        }
        if ((collision.gameObject.name == "P Bugs" || collision.gameObject.name == "P Lead" || collision.gameObject.name == "P Gold") && !materialOk)
        {
            material = collision.name;
            if (components < 3)
            {
                components++;
            }
            else
            {
                components = 0;
            }
            Destroy(collision.gameObject);
            materialOk = true;
        }
        if (components == 3 && cooked.isDone)
        {
            powderOk = false;
            liquidOk = false;
            materialOk = false;
            components = 0;
        }
    }
}
