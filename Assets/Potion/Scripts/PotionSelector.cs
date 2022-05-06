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
    }

    private void OnDestroy()
    {
        GameEvents.GetInstance().CustomerReachedSpot -= CustomerReachedSpot;
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
        //currentPotion = Potions.Where(p => p.Type == global::Potions.Health).FirstOrDefault();

        PotionRenderer.sprite = currentPotion.Icon;
        BubbleRenderer.enabled = PotionRenderer.enabled = true;
        return currentPotion;
    }
}
