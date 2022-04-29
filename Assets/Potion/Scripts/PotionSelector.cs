using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSelector : MonoBehaviour
{
    [SerializeField] SpriteRenderer BubbleRenderer;
    [SerializeField] SpriteRenderer PotionRenderer;
    [SerializeField] List<PotionItem> Potions;

    PotionItem currentPotion;

    private void Awake()
    {
        GameEvents.GetInstance().CustomerReachedSpot += CustomerReachedSpot;
    }

    private void OnDestroy()
    {
        GameEvents.GetInstance().CustomerReachedSpot -= CustomerReachedSpot;
    }

    void Start()
    {
        BubbleRenderer.enabled = PotionRenderer.enabled = false;
    }

    void CustomerReachedSpot()
    {
        if(Potions.Count == 0)
            return;

        int randomIndex = Random.Range(0, Potions.Count);
        currentPotion = Potions[randomIndex];

        PotionRenderer.sprite = currentPotion.Icon;
        BubbleRenderer.enabled = PotionRenderer.enabled = true;
    }
}
