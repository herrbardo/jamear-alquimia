using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluidSpawner : MonoBehaviour
{
    public GameObject fluid;
    public bool isPouring = false;

    private float fluidRate = 0.1f;
    private float nextFluid;

    private float delta = 0.05f;
    private float speed = 3.0f;
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
        if (isPouring && Time.time > nextFluid)
        {
            nextFluid = Time.time + fluidRate;
            Instantiate(fluid, transform.position, Quaternion.identity);
        }
    }
}
