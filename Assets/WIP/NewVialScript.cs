using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewVialScript : MonoBehaviour
{
    private Forceable movementScript;

    public GameObject topStop;

    private int particleQuantity;
    [NonSerialized] public bool IsAttached;

    void Start()
    {
        movementScript = GetComponent<Forceable>();
        topStop.SetActive(false);
    }

    void Update()
    {
        if (particleQuantity == 15)
        {
            topStop.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Water" || collision.tag == "Oil" || collision.tag == "Mercury")
        {
            collision.gameObject.transform.SetParent(transform);
            collision.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Vial"; 
            particleQuantity++;
            Debug.Log(particleQuantity);
        }
    }

    private void OnMouseDown()
    {
        if (IsAttached)
        {
            InventorySlotManager slot = this.transform.parent.GetComponent<InventorySlotManager>();
            slot.RemoveItem();
            this.transform.parent = null;
            IsAttached = false;
        }
    }
}
