using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] List<InventorySlotManager> Slots;

    private void Awake()
    {
        GameEvents.GetInstance().RequestAddVialToInventory += RequestedAddNewVial;
    }

    private void OnDestroy()
    {
        GameEvents.GetInstance().RequestAddVialToInventory -= RequestedAddNewVial;
    }

    void RequestedAddNewVial(GameObject vial)
    {
        InventorySlotManager freeSlot = Slots.Where(s => s.IsFree).FirstOrDefault();

        if(freeSlot == null)
        {
            //TODO: Hacer alguna animación ó sonido para indicar que el inventario está lleno
        }
        else
            freeSlot.AddVialToSlot(vial);
    }
}
