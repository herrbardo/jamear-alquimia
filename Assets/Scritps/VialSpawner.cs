using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialSpawner : MonoBehaviour
{
    public GameObject vial;
    public bool isPouring = false;

    private float vialRate = 1f;
    private float nextVial;

    private void Update()
    {
        if (isPouring && Time.time > nextVial)
        {
            nextVial = Time.time + vialRate;
            Instantiate(vial, transform.position, Quaternion.identity);
            isPouring = false;
        }
    }
}