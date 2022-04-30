using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewPotion", menuName = "ScriptableObjects/Herrbardo/PotionItem", order = 1)]
public class PotionItem : ScriptableObject
{
    [SerializeField] public Sprite Icon;
    [SerializeField] public string Tooltip;
    [SerializeField] public Potions Type;
    [SerializeField] public string Recipe;
}
