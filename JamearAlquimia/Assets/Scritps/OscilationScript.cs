using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilationScript : MonoBehaviour
{
    public float delta = 0.05f;
    public float speed = 3.0f;
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
    }
}
