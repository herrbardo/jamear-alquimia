using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    [SerializeField] List<Sprite> PotionSprites;
    [SerializeField] public Potions Type;
    [SerializeField] SpriteRenderer SpriteRenderer;

    void Start()
    {
        SpriteRenderer.sprite = PotionSprites[(int)Type];
    }

}
