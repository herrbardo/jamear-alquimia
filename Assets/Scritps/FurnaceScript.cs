using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceScript : MonoBehaviour
{
    public Sensor increaseSensor;
    public Sensor decreaseSensor;

    private int temperature;
    public GameObject temperatureSlider;

    public ParticleSystem flameEffect;

    private float deltaChange = 0.2f;
    private float nextDegree;

    void Start()
    {
        temperature = 0;
    }

    void Update()
    {
        if (increaseSensor.detection && Time.time > nextDegree && temperature < 30)
        {
            nextDegree = Time.time + deltaChange;
            temperature++;
            //temperatureSlider.transform.localScale += new Vector3(0, Mathf.Lerp(0, 3f, temperature/3), 0);
        }
        if (decreaseSensor.detection && Time.time > nextDegree && temperature > 0)
        {
            nextDegree = Time.time + deltaChange;
            temperature--;
            //temperatureSlider.transform.localScale -= new Vector3(0, Mathf.Lerp(0, 1f, temperature/3), 0);
        }
        
        if (temperature <= 0f)
        {
            temperatureSlider.transform.localScale = new Vector3(0.64f, 1f, 1f);
        }
        if (temperature >= 10 && temperature < 19f)
        {
            temperatureSlider.transform.localScale = new Vector3(0.64f, 2f, 1f);
        }
        if (temperature >= 20f && temperature < 29f)
        {
            temperatureSlider.transform.localScale = new Vector3(0.64f, 3f, 1f);
        }
        if (temperature == 30f)
        {
            temperatureSlider.transform.localScale = new Vector3(0.64f, 4f, 1f);
        }
        flameEffect.emissionRate = temperature;
        //termometerSprite.transform.localScale += new Vector3(0, Mathf.Lerp(0, 1.47f, temperature), 0);
    }
}
