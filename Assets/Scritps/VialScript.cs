using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class VialScript : MonoBehaviour
{
    [SerializeField] float DelayToClose;
    [SerializeField] float TimeToFillLiquid;
    [SerializeField] SimpleTooltip Tooltip;
    [NonSerialized] public bool IsAttached;
    [SerializeField] GameObject WaterFiller;
    [SerializeField] GameObject OilFiller;
    [SerializeField] GameObject MercuryFiller;
    [SerializeField] GameObject SaltFiller;
    [SerializeField] GameObject ArsenicFiller;
    [SerializeField] GameObject PhosFiller;
    [SerializeField] GameObject TopStop;

    public string vialContet;
    bool isFull;

    float collisionTime;

    void Start()
    {
        WaterFiller.SetActive(false);
        OilFiller.SetActive(false);
        MercuryFiller.SetActive(false);
        SaltFiller.SetActive(false);
        ArsenicFiller.SetActive(false);
        PhosFiller.SetActive(false);
        TopStop.SetActive(false);

        isFull = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(isFull)
            return;

        string otherTag = collision.gameObject.tag;
        List<string> powders = Enum.GetNames(typeof(Powder)).ToList();
        List<string> elements = Enum.GetNames(typeof(Element)).ToList();
        List<string> liquids = Enum.GetNames(typeof(Liquid)).ToList();

        if(elements.Contains(otherTag))
        {
            Tooltip.infoLeft = otherTag;
            collision.gameObject.transform.parent = this.transform;
            Invoke("SetFull", DelayToClose);
        }
        else if(powders.Contains(otherTag))
        {
            Enum.TryParse(otherTag, out Powder powder);
            SetFull(powder);
        }
        else if(liquids.Contains(otherTag))
        {
            collisionTime += Time.time;

            if(collisionTime > TimeToFillLiquid)
            {
                Enum.TryParse(otherTag, out Liquid liquid);
                SetFull(liquid);
            }
        }
    }

    void SetFull()
    {
        TopStop.SetActive(true);
        isFull = true;
    }

    void SetFull(Powder powder)
    {
        if(powder == Powder.Salt)
        {
            SaltFiller.SetActive(true);
            vialContet = "Salt";
        }
        else if(powder == Powder.Arsenic)
        {
            ArsenicFiller.SetActive(true);
            vialContet = "Arsenic";
        }
        else if(powder == Powder.Phos)
        {
            PhosFiller.SetActive(true);
            vialContet = "Phos";
        }


        vialContet = powder.ToString();
        Tooltip.infoLeft = powder.ToString();
        SetFull();
    }

    void SetFull(Liquid liquid)
    {
        if(liquid == Liquid.Water)
            WaterFiller.SetActive(true);
        else if(liquid == Liquid.Oil)
            OilFiller.SetActive(true);
        else if(liquid == Liquid.Mercury)
            MercuryFiller.SetActive(true);
        
        Tooltip.infoLeft = liquid.ToString();
        SetFull();
    }

    private void OnMouseDown()
    {
        if(IsAttached)
        {
            InventorySlotManager slot = this.transform.parent.GetComponent<InventorySlotManager>();
            slot.RemoveItem();
            this.transform.parent = null;
            IsAttached = false;
        }
    }
}
