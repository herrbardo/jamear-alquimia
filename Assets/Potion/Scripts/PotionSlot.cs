using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class PotionSlot : MonoBehaviour
{
    [SerializeField] SpriteRenderer Sprite;
    [SerializeField] SimpleTooltip Tooltip;
    [SerializeField] GameObject PotionPrefab;

    PotionItem currentPotionItem;

    public void SetPotion(PotionItem item)
    {
        StringBuilder text = new StringBuilder();
        text.AppendLine(item.Type.ToString());
        text.AppendLine(item.Tooltip);
        text.AppendLine(item.Recipe);

        this.Sprite.sprite = item.Icon;
        this.Tooltip.infoLeft = text.ToString();
        this.currentPotionItem = item;
    }

    private void OnMouseUp()
    {
        if(GameManager.Instance.EnableCheats)
        {
            GameObject newPotion = Instantiate(this.PotionPrefab, this.transform.position, Quaternion.identity);
            PotionScript script = newPotion.GetComponent<PotionScript>();

            if(this.currentPotionItem == null)
                script.Type = Potions.Fail;
            else
                script.Type = this.currentPotionItem.Type;
        }
    }
}
