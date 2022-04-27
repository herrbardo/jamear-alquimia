using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VialScript : MonoBehaviour
{
    private int waterCounter;
    private int oilCounter;
    private int mercuryCounter;

    private int saltCounter;
    private int arsenicCounter;
    private int phosCounter;

    public GameObject waterFiller;
    public GameObject oilFiller;
    public GameObject mercuryFiller;

    public GameObject saltFiller;
    public GameObject arsenicFiller;
    public GameObject phosFiller;

    public GameObject topStop;

    private bool isFull;

    void Start()
    {
        waterCounter = 0;
        oilCounter = 0;
        mercuryCounter = 0;

        saltCounter = 0;
        arsenicCounter = 0;
        phosCounter = 0;

        waterFiller.SetActive(false);
        oilFiller.SetActive(false);
        mercuryFiller.SetActive(false);

        saltFiller.SetActive(false);
        arsenicFiller.SetActive(false);
        phosFiller.SetActive(false);

        topStop.SetActive(false);

        isFull = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isFull)
        {
            if (collision.gameObject.tag == "Water")
            {
                waterCounter++;
                if (waterCounter == 30)
                {
                    topStop.SetActive(true);
                    waterFiller.SetActive(true);
                    isFull = true;
                }
            }
            if (collision.gameObject.tag == "Oil")
            {
                oilCounter++;
                if (oilCounter == 30)
                {
                    topStop.SetActive(true);
                    oilFiller.SetActive(true);
                    isFull = true;
                }
            }
            if (collision.gameObject.tag == "Mercury")
            {
                mercuryCounter++;
                if (mercuryCounter == 30)
                {
                    topStop.SetActive(true);
                    mercuryFiller.SetActive(true);
                    isFull = true;
                }
            }
            if (collision.gameObject.tag == "Salt")
            {
                saltCounter++;
                if (saltCounter == 5)
                {
                    topStop.SetActive(true);
                    saltFiller.SetActive(true);
                    isFull = true;
                }
            }
            if (collision.gameObject.tag == "Arsenic")
            {
                arsenicCounter++;
                if (arsenicCounter == 5)
                {
                    topStop.SetActive(true);
                    arsenicFiller.SetActive(true);
                    isFull = true;
                }
            }
            if (collision.gameObject.tag == "Phos")
            {
                phosCounter++;
                if (phosCounter == 5)
                {
                    topStop.SetActive(true);
                    phosFiller.SetActive(true);
                    isFull = true;
                }
            }
        }
    }

}
