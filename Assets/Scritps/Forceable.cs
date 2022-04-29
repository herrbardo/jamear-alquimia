using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forceable : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 forceVector = Vector2.zero;
    private bool isDragging = false;
    private float magnitude = 100f;

    public float onUseDrag;
    public float onIdleDrag;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = onIdleDrag;
    }

    private void OnMouseDown()
    {
        isDragging = true;
        rb.drag = onUseDrag;
    }

    private void OnMouseUp()
    {
        isDragging = false;
        rb.drag = onIdleDrag;
    }

    private void FixedUpdate()
    {
        if (isDragging)
        {
            forceVector = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
            rb.AddForce(forceVector * magnitude, ForceMode2D.Force);
            Debug.DrawLine(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}