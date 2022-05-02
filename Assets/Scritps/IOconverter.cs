using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IOconverter : MonoBehaviour
{
    // INPUTS
    public VialScript inputVial; // Tag: "Vial"
    public GameObject inputMaterial;

    // OUTPUTS
    public GameObject arsenic; // Tag: P Ars
    public GameObject phosphore; // P Phos
    public GameObject salt; // P Salt

    public GameObject processedBugIngot;
    public GameObject processedLeadIngot;
    public GameObject processedGoldIngot;

    private void OnMouseUpAsButton()
    {
        ////if (inputVial != null)
        ////{
        //    if (inputVial.vialContet == "Arsenic")
        //    {
        //        Instantiate(processedArsenic, gameObject.transform);
        //    Instantiate(processedArsenic, gameObject.transform);
        //    Instantiate(processedArsenic, gameObject.transform);
        //    Destroy(inputVial.gameObject);
        //}
        ////}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Vial")
        {
            inputVial = collision.GetComponent<VialScript>();
            Debug.Log("Vial detectado: " + inputVial.vialContet);
            SpawnParticles(inputVial.vialContet);
        }
        if (collision.tag == "P Ars")
        {

        }
        //if (inputVial.vialContet == "Arsenic")
        //{
        //    Instantiate(processedArsenic, gameObject.transform);
        //    Instantiate(processedArsenic, gameObject.transform);
        //    Instantiate(processedArsenic, gameObject.transform);
        //    Destroy(inputVial.gameObject);
        //}
    }

    void SpawnParticles(string content)
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
    }
}
