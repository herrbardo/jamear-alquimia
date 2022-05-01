using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    public bool isFurnaceSensor = false;
    public bool isFurnaceDoorSensor = false;
    public bool detection = false;

    public string materialDetected;
    public GameObject materialInput;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activator" && !isFurnaceSensor)
        {
            detection = true;
        }
        if (isFurnaceSensor && collision.tag == "Gate" && isFurnaceDoorSensor)
        {
            detection = true;
            Debug.Log("Se cerró puerta");
        }
        if (isFurnaceSensor && (collision.tag == "Gold" || collision.tag == "Lead" || collision.tag == "Bugs") && !isFurnaceDoorSensor)
        {
            detection = true;
            materialDetected = collision.tag;
            materialInput = collision.gameObject;
            Debug.Log("Detecto " + collision.tag);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Activator" && !isFurnaceSensor)
        {
            detection = false;
        }
        if (isFurnaceSensor && collision.tag == "Gate" && isFurnaceDoorSensor)
        {
            detection = false;
            Debug.Log("Se abrió puerta");
        }
        if (isFurnaceSensor && (collision.tag == "Gold" || collision.tag == "Lead" || collision.tag == "Bugs") && !isFurnaceDoorSensor)
        {
            detection = true;
            materialDetected = collision.tag;
            materialInput = null;
            Debug.Log("Se retiró " + collision.tag);
        }
    }

}
