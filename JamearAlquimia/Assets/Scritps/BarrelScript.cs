using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public GameObject instantiable;

    private void OnMouseDown()
    {
        Instantiate(instantiable, Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10), Quaternion.identity);
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0, 0, 10));
    }
}
