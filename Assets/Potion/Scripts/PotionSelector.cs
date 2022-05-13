using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PotionSelector : MonoBehaviour
{
    [SerializeField] SpriteRenderer BubbleRenderer;
    [SerializeField] SpriteRenderer PotionRenderer;
    [SerializeField] List<PotionItem> Potions;

    PotionItem currentPotion;

    private void Awake()
    {
        GameEvents.GetInstance().CustomerReachedSpot += CustomerReachedSpot;
        GameEvents.GetInstance().RequestNewCustomer += RequestNewCustomer;
    }

    private void OnDestroy()
    {
        GameEvents.GetInstance().CustomerReachedSpot -= CustomerReachedSpot;
        GameEvents.GetInstance().RequestNewCustomer -= RequestNewCustomer;
    }

    void Start()
    {
        BubbleRenderer.enabled = PotionRenderer.enabled = false;
    }

    PotionItem CustomerReachedSpot()
    {
        if(Potions.Count == 0)
            return null;

        int randomIndex = Random.Range(0, Potions.Count);
        currentPotion = Potions[randomIndex];

        PotionRenderer.sprite = currentPotion.Icon;
        BubbleRenderer.enabled = PotionRenderer.enabled = true;
        return currentPotion;
    }

    void RequestNewCustomer()
    {
        BubbleRenderer.enabled = PotionRenderer.enabled = false;
    }
}
