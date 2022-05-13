using System.Collections;
using UnityEngine;
using System;

public class CauldronScript : MonoBehaviour
{
    public Sensor right;
    public Sensor left;
    private bool isLeft;
    private bool isRight;
    public int spoonCounter;

    public ParticleSystem gasEffect;
    public ParticleSystem potionEffect;

    public Transform potionSpawner;
    public bool isDone;

    public GameObject outputPotion;
    private Potions potionType;
    private string liquid;
    private string powder;
    private string material;
    public MaterialDetector components;
    private bool proceed;

    // Start is called before the first frame update
    void Start()
    {
        isRight = true;
        isLeft = false;
        isDone = false;
        potionEffect.Stop();
        proceed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (components.components == 3 && !proceed)
        {
            if (components.liquid == "Oil" && components.powder == "P_Phos" && components.material == "P Lead")
            {
                potionType = Potions.Strength;
            }
            else if (components.liquid == "Water" && components.powder == "P_Salt" && components.material == "P Gold")
            {
                //curacion
                potionType = Potions.Health;
            }
            else if (components.liquid == "Oil" && components.powder == "P_Arsenic" && components.material == "P Lead")
            {
                //veneno
                potionType = Potions.Poison;
            }
            else if (components.liquid == "Mercury" && components.powder == "P_Phos" && components.material == "P Bugs")
            {
                //vision noc
                potionType = Potions.NightVision;
            }
            else if (components.liquid == "Mercury" && components.powder == "P_Arsenic" && components.material == "P Bugs")
            {
                //invisi
                potionType = Potions.Invisibility;
            }
            else if (components.liquid == "Water" && components.powder == "P_Arsenic" && components.material == "P Gold")
            {
                //amor
                potionType = Potions.Love;
            }
            else if (components.liquid == "Mercury" && components.powder == "P_Phos" && components.material == "P Bugs")
            {
                //debili
                potionType = Potions.Weakness;
            }
            else if (components.liquid == "Oil" && components.powder == "P_Salt" && components.material == "P Gold")
            {
                //fortuna
                potionType = Potions.Fortune;
            }
            else if (components.liquid == "Water" && components.powder == "P_Salt" && components.material == "P Lead")
            {
                //anitdot
                potionType = Potions.Antidote;
            }
            else
            {
                //fail
                potionType = Potions.Fail;
            }
            proceed = true;
            Debug.Log(components.liquid + ", " + components.powder + ", " + components.material);
            components.liquid = null;
            components.powder = null;
            components.material = null;
        }

        if (isDone)
        {
            GameObject potion = Instantiate(outputPotion, potionSpawner);
            potion.GetComponent<PotionScript>().Type = potionType;
            spoonCounter = 0;
            potionEffect.Play();
            isDone = false;//

            GameEvents.GetInstance().OnPotionUnlocked(potionType);
        }

        if (proceed && !isDone)
        {
            if (spoonCounter < 30 && components.components == 3)
            {
                if (right.detection && isRight)
                {
                    spoonCounter++;
                    isRight = false;
                    isLeft = true;
                }
                if (left.detection && isLeft)
                {
                    spoonCounter++;
                    isRight = true;
                    isLeft = false;
                }
            }
            else
            {
                isDone = true;
                proceed = false;
            }
        }

        var emission = gasEffect.emission;
        emission.rateOverTime = spoonCounter;

    }
}
