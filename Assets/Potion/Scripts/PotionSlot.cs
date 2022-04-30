using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSlot : MonoBehaviour
{
    [SerializeField] SpriteRenderer Sprite;
    [SerializeField] SimpleTooltip Tooltip;

    public void SetPotion(PotionItem item)
    {
        this.Sprite.sprite = item.Icon;
        this.Tooltip.infoLeft = item.Type.ToString();
        this.Tooltip.infoRight = item.Tooltip;
    }
}
