using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class PotionSlot : MonoBehaviour
{
    [SerializeField] SpriteRenderer Sprite;
    [SerializeField] SimpleTooltip Tooltip;

    public void SetPotion(PotionItem item)
    {
        StringBuilder text = new StringBuilder();
        text.AppendLine(item.Type.ToString());
        text.AppendLine(item.Tooltip);
        text.AppendLine(item.Recipe);

        this.Sprite.sprite = item.Icon;
        this.Tooltip.infoLeft = text.ToString();
    }
}
