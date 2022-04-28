using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public GameObject instantiable;
    public GameObject spawner;

    private float elementRate = 1f;
    private float nextElement;

    private bool isPowder = false;

    private void Start()
    {
        if (this.gameObject.tag == "PowderDropper")
        {
            spawner = null;
            elementRate = 0.5f;
            isPowder = true;
        }
    }

    private void OnMouseDown()
    {
        if (Time.time > nextElement)
        {
            if (isPowder)
            {
                nextElement = Time.time + elementRate;
                Instantiate(instantiable, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10f), Quaternion.identity);
            }
            else
            {
                nextElement = Time.time + elementRate;
                GameObject go = Instantiate(instantiable, spawner.transform.position, Quaternion.identity);
                go.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000f);
            }
        }
    }

}
