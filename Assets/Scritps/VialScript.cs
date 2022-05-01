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

    public GameObject waterFiller;
    public GameObject oilFiller;
    public GameObject mercuryFiller;

    public GameObject saltFiller;
    public GameObject arsenicFiller;
    public GameObject phosFiller;

    public GameObject topStop;

    private bool isFull;
    float collisionTime;

    void Start()
    {
        waterFiller.SetActive(false);
        oilFiller.SetActive(false);
        mercuryFiller.SetActive(false);

        saltFiller.SetActive(false);
        arsenicFiller.SetActive(false);
        phosFiller.SetActive(false);

        topStop.SetActive(false);

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
        topStop.SetActive(true);
        isFull = true;
    }

    void SetFull(Powder powder)
    {
        if(powder == Powder.Salt)
            saltFiller.SetActive(true);
        else if(powder == Powder.Arsenic)
            arsenicFiller.SetActive(true);
        else if(powder == Powder.Phos)
            phosFiller.SetActive(true);

        Tooltip.infoLeft = powder.ToString();
        SetFull();
    }

    void SetFull(Liquid liquid)
    {
        if(liquid == Liquid.Water)
            waterFiller.SetActive(true);
        else if(liquid == Liquid.Oil)
            oilFiller.SetActive(true);
        else if(liquid == Liquid.Mercury)
            mercuryFiller.SetActive(true);
        
        Tooltip.infoLeft = liquid.ToString();
        SetFull();
    }
}
