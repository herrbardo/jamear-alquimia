using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOconverter : MonoBehaviour
{
    public bool isInput;
    public bool isPika;
    public bool isLiquidInput;
    // INPUTS
    public VialScript inputVial; // Tag: "Vial"
    bool isVial = false;
    public GameObject inputMaterial;

    // OUTPUTS
    public GameObject arsenic; // Tag: P Ars
    public GameObject phosphore; // P Phos
    public GameObject salt; // P Salt

    public GameObject processedArsenic;
    public GameObject processedPhos;
    public GameObject processedSalt;

    public GameObject water;
    public GameObject oil;
    public GameObject mercury;

    //public GameObject processedBugIngot;
    //public GameObject processedLeadIngot;
    //public GameObject processedGoldIngot;

    public GameObject proccesedIngot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Vial" && isInput)
        {
            isVial = true;
            inputVial = collision.GetComponent<VialScript>();
            Debug.Log("Vial detectado: " + inputVial.vialContent);
            SpawnParticles(inputVial.vialContent);
        }
        if (collision.tag == "Vial" && isLiquidInput)
        {
            isVial = true;
            inputVial = collision.GetComponent<VialScript>();
            Debug.Log("Vial detectado: " + inputVial.vialContent);
            SpawnParticles(inputVial.vialContent);
        }
        if ((collision.tag == "Bugs Ingot" || collision.tag == "Lead Ingot" || collision.tag == "Gold Ingot") && !isInput && isPika)
        {
            inputMaterial = collision.gameObject;
            SpawnParticles(inputMaterial.tag);
        }
        if ((collision.tag == "Arsenic" || collision.tag == "Phos" || collision.tag == "Salt") && !isInput && !isPika)
        {
            inputMaterial = collision.gameObject;
            SpawnParticles(inputMaterial.tag);
        }
    }

    void SpawnParticles(string content)
    {
        if (isVial)
        {
            if (!isLiquidInput)
            {
                if (content == "Arsenic")
                {
                    Destroy(inputVial.gameObject);
                    for (int i = 0; i < 10; i++)
                    {
                        Instantiate(arsenic, gameObject.transform);
                    }
                }
                if (content == "Phos")
                {
                    Destroy(inputVial.gameObject);
                    for (int i = 0; i < 10; i++)
                    {
                        Instantiate(phosphore, gameObject.transform);
                    }
                }
                if (content == "Salt")
                {
                    Destroy(inputVial.gameObject);
                    for (int i = 0; i < 10; i++)
                    {
                        Instantiate(salt, gameObject.transform);
                    }
                }
                if (content == "P_Arsenic")
                {
                    Destroy(inputVial.gameObject);
                    for (int i = 0; i < 10; i++)
                    {
                        Instantiate(processedArsenic, gameObject.transform);
                    }
                }
                if (content == "P_Phos")
                {
                    Destroy(inputVial.gameObject);
                    for (int i = 0; i < 10; i++)
                    {
                        Instantiate(processedPhos, gameObject.transform);
                    }
                }
                if (content == "P_Salt")
                {
                    Destroy(inputVial.gameObject);
                    for (int i = 0; i < 10; i++)
                    {
                        Instantiate(processedSalt, gameObject.transform);
                    }
                }
            }
            else
            {
                if (content == "Water")
                {
                    Destroy(inputVial.gameObject);
                    for (int i = 0; i < 10; i++)
                    {
                        Instantiate(water, gameObject.transform);
                    }
                }
                if (content == "Oil")
                {
                    Destroy(inputVial.gameObject);
                    for (int i = 0; i < 10; i++)
                    {
                        Instantiate(oil, gameObject.transform);
                    }
                }
                if (content == "Mercury")
                {
                    Destroy(inputVial.gameObject);
                    for (int i = 0; i < 10; i++)
                    {
                        Instantiate(mercury, gameObject.transform);
                    }
                }
            }


        }
        if (!isVial)
        {
            if (content == "Arsenic")
            {
                Destroy(inputMaterial);
                Instantiate(processedArsenic, gameObject.transform);
            }
            if (content == "Phos")
            {
                Destroy(inputMaterial);
                Instantiate(processedPhos, gameObject.transform);
            }
            if (content == "Salt")
            {
                Destroy(inputMaterial);
                Instantiate(processedSalt, gameObject.transform);
            }
            if (content == "Bugs Ingot")
            {
                Destroy(inputMaterial);
                GameObject pi = Instantiate(proccesedIngot, gameObject.transform);
                pi.name = "P Bugs";
            }
            if (content == "Lead Ingot")
            {
                Destroy(inputMaterial);
                GameObject pi = Instantiate(proccesedIngot, gameObject.transform);
                pi.name = "P Lead";
            }
            if (content == "Gold Ingot")
            {
                Destroy(inputMaterial);
                GameObject pi = Instantiate(proccesedIngot, gameObject.transform);
                pi.name = "P Gold";
            }
        }
        isVial = false;
    }
}
