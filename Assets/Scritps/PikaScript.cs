using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PikaScript : MonoBehaviour
{
    public Sensor handleSensor;
    private float deltaChange = 0.2f; // Temporizador de 0.2 segundos para evitar que se dispare la temperatura, mide cada cuanto puede aumentar la T
    private float nextDegree; // Variable auxiliar para el temporizador
    private int spinCounter;
    public GameObject stopCollider;
    // Start is called before the first frame update
    void Start()
    {
        spinCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (handleSensor.detection && Time.time > nextDegree)
        {
            nextDegree = Time.time + deltaChange;
            spinCounter++;
        }
        if (spinCounter >= 10)
        {
            stopCollider.SetActive(false);
            spinCounter = 0;
            StartCoroutine(StopRestart());
        }
    }

    IEnumerator StopRestart()
    {
        yield return new WaitForSeconds(3);
        stopCollider.SetActive(true);
    }
}
