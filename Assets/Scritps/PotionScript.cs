using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    [SerializeField] List<Sprite> PotionSprites;
    [SerializeField] Potions Type;
    [SerializeField] SpriteRenderer SpriteRenderer;

    void Start()
    {
        switch(Type)
        {
            default:
            case Potions.Health:
                SpriteRenderer.sprite = PotionSprites[0];
            break;

            case Potions.Strength:
                SpriteRenderer.sprite = PotionSprites[0];
            break;

            case Potions.Poison:
                SpriteRenderer.sprite = PotionSprites[0];
            break;

            case Potions.NightVision:
                SpriteRenderer.sprite = PotionSprites[0];
            break;

            case Potions.Invisibility:
                SpriteRenderer.sprite = PotionSprites[0];
            break;

            case Potions.Love:
                SpriteRenderer.sprite = PotionSprites[0];
            break;

            case Potions.Weakness:
                SpriteRenderer.sprite = PotionSprites[0];
            break;

            case Potions.Fortune:
                SpriteRenderer.sprite = PotionSprites[0];
            break;

            case Potions.Antidote:
                SpriteRenderer.sprite = PotionSprites[0];
            break;
        }
    }

}
