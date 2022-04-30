using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gearbox : MonoBehaviour
{
    public Rigidbody2D rb;

    public Rigidbody2D rbGearRight;
    public Rigidbody2D rbGearLeft;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rbGearRight.angularVelocity = rb.angularVelocity;
        rbGearLeft.angularVelocity = -rb.angularVelocity;
    }
}
