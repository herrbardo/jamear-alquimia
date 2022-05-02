using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    public string potionType;

    public GameObject healing;
    public GameObject strength;
    public GameObject poison;
    public GameObject nightVision;
    public GameObject invisibility;
    public GameObject love;
    public GameObject weakness;
    public GameObject fortune;
    public GameObject antidote;
    public GameObject fail;

    void Start()
    {
        if (potionType == "Healing")
        {
            healing.SetActive(true);
        }
        if (potionType == "Strength")
        {
            strength.SetActive(true);
        }
        if (potionType == "Poison")
        {
            poison.SetActive(true);
        }
        if (potionType == "NightVision")
        {
            nightVision.SetActive(true);
        }
        if (potionType == "Invisibility")
        {
            invisibility.SetActive(true);
        }
        if (potionType == "Love")
        {
            love.SetActive(true);
        }
        if (potionType == "Weakness")
        {
            weakness.SetActive(true);
        }
        if (potionType == "Fortune")
        {
            fortune.SetActive(true);
        }
        if (potionType == "Antidote")
        {
            antidote.SetActive(true);
        }
        if (potionType == "Fail")
        {
            fail.SetActive(true);
        }
    }


}
