using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceScript : MonoBehaviour
{
    public Sensor increaseSensor;  // Sensor de aumento de temperatura
    public Sensor decreaseSensor;  // Sensor de decremento de temperatura

    public Sensor materialSensor; // Sensor de material ingresado
    public Sensor doorSensor;  // Sensor de puerta abierta/cerrada  true/false

    public Forceable doorInteractor; // Script que permite interactuar con la puerta

    private int temperature;   // Escalar del valor de la temperatura
    public GameObject temperatureSlider; // Sprite rojo que se escala para representar un aumento de Tº en el termometro

    private bool temp1 = false; // Boolean para chequear estado de T 1
    private bool temp2 = false; // Boolean para chequear estado de T 2
    private bool temp3 = false; // Boolean para chequear estado de T 3

    private bool proccesing = false;
    public GameObject outputTransform;

    public GameObject materialOutput; // Gameobject del material de salida --> Lingotes

    public ParticleSystem flameEffect; // Efecto de aumento de temperatura
    public ParticleSystem readyEffect; // Efecto de nuevo material instanciado

    private float deltaChange = 0.2f; // Temporizador de 0.2 segundos para evitar que se dispare la temperatura, mide cada cuanto puede aumentar la T
    private float nextDegree; // Variable auxiliar para el temporizador

    void Start()
    {
        temperature = 0; // Inicio la T = 0
        readyEffect.Stop();
    }

    void Update()
    {
        if (increaseSensor.detection && Time.time > nextDegree && temperature < 30) // Si detecto aumento, tengo el tiempo y estoy debajo de la T superior
        {
            nextDegree = Time.time + deltaChange; // Timer
            temperature++; // Aumento temperatura
        }
        if (decreaseSensor.detection && Time.time > nextDegree && temperature > 0) // Si detecto decremento, tengo el tiempo y estoy sobre la T inferior
        {
            nextDegree = Time.time + deltaChange; // TImer
            temperature--; // Decremento temperatura
        }
        
        // Chequeo en cada if en donde se encuentra la T y modifico los boolean y el sprite respectivamente
        if (temperature <= 0f)
        {
            temperatureSlider.transform.localScale = new Vector3(0.64f, 1f, 1f);
            temp1 = false;
            temp2 = false;
            temp3 = false;

            //readyToProcess = true;
        }
        if (temperature >= 10 && temperature < 19f)
        {
            temperatureSlider.transform.localScale = new Vector3(0.64f, 2f, 1f);
            temp1 = true;
            temp2 = false;
            temp3 = false;

            //readyToProcess = true;
        }
        if (temperature >= 20f && temperature < 29f)
        {
            temperatureSlider.transform.localScale = new Vector3(0.64f, 3f, 1f);
            temp1 = false;
            temp2 = true;
            temp3 = false;

            //readyToProcess = true;
        }
        if (temperature == 30f)
        {
            temperatureSlider.transform.localScale = new Vector3(0.64f, 4f, 1f);
            temp1 = false;
            temp2 = false;
            temp3 = true;

            //readyToProcess = true;
        }

        var emission = flameEffect.emission; // Cargo emision en una variable aparte.
        emission.rateOverTime = temperature; // Cantidad sobre tiempo la igualo a la temperatura actual del loop

        if (materialSensor.detection && !proccesing)
        {
            Debug.Log("Ingresó el material: " + materialSensor.materialDetected);
            if (materialSensor.materialInput != null)
            {
                if (doorSensor.detection && !proccesing && (materialSensor.materialDetected == "Bugs" || materialSensor.materialDetected == "Lead" || materialSensor.materialDetected == "Gold"))
                {
                    doorInteractor.enabled = false;
                    if (materialSensor.materialDetected == "Bugs" && temp1)
                    {
                        materialSensor.materialDetected = "";
                        Debug.Log("Se cerro con material apto dentro");
                        StartCoroutine(TiempoDeProcesado());
                        Debug.Log("Procesando");
                        proccesing = true;
                        doorInteractor.enabled = true;
                    }
                    if (materialSensor.materialDetected == "Lead" && temp2)
                    {
                        materialSensor.materialDetected = "";
                        Debug.Log("Se cerro con material apto dentro");
                        StartCoroutine(TiempoDeProcesado());
                        Debug.Log("Procesando");
                        proccesing = true;
                        doorInteractor.enabled = true;
                    }
                    if (materialSensor.materialDetected == "Gold" && temp3)
                    {
                        materialSensor.materialDetected = "";
                        Debug.Log("Se cerro con material apto dentro");
                        StartCoroutine(TiempoDeProcesado());
                        Debug.Log("Procesando");
                        proccesing = true;
                        doorInteractor.enabled = true;
                    }

                }
            }
        }
        if (!doorSensor.detection)
        {
            readyEffect.Stop();
            proccesing = false;
        }
    }

    IEnumerator TiempoDeProcesado()
    {
        yield return new WaitForSeconds(5);
        GameObject mo = Instantiate(materialOutput, outputTransform.transform);
        mo.tag = materialSensor.materialInput.tag + " Ingot";
        Destroy(materialSensor.materialInput);
        readyEffect.Play();
        Debug.Log("Material Procesado");
    }
}
