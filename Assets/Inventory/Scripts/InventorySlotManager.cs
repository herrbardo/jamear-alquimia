using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySlotManager : MonoBehaviour
{
    public bool IsFree { get { return vial == null; } }
    
    GameObject vial;
    
    void Start()
    {
        
    }

    void Update()
    {
        if(!IsFree)
            KeepVialAttached();
    }

    public void AddVialToSlot(GameObject vial)
    {
        VialScript script = vial.GetComponent<VialScript>();
        vial.transform.parent = this.transform;
        script.IsAttached = true;
        this.vial = vial;
    }

    void KeepVialAttached()
    {
        vial.transform.position = this.transform.position;
    }

    public void RemoveItem()
    {
        this.vial = null;
    }
}
