using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Examples;

public class Api : MonoBehaviour
{
    public Panci panci;
    public Pan pan;

    //public bool panciIsCooking;
    //public bool panCooking;

    // Update is called once per frame
    void Update()
    {
        Masak();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Collider_bottom")
        {
            if (gameObject.GetComponent<Renderer>().enabled == true)
            {
                panci.isCooking = true;
            }
            else if (gameObject.GetComponent<Renderer>().enabled == false)
            {
                panci.isCooking = false;
            }
        }
        else if(other.gameObject.name == "Collider_Bawah")
        {
            if (gameObject.GetComponent<Renderer>().enabled == true)
            {
                pan.isCooking = true;
            }
            else if (gameObject.GetComponent<Renderer>().enabled == false)
            {
                pan.isCooking = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Collider_bottom")
        {
            panci.isCooking = false;
        }
        else if (other.gameObject.name == "Collider_Bawah")
        {
            pan.isCooking = false;
        }
    }

    void Masak()
    {
        if (panci.isCooking == true)
        {
            panci.currTemperature += 2 * Time.deltaTime;
        }
        else if (panci.isCooking == false && panci.currTemperature > 0)
        {
            panci.currTemperature -= 2 * Time.deltaTime;

            if(panci.currTemperature < 0)
            {
                panci.currTemperature = 0;
            }
        }
        else if (pan.isCooking == true)
        {
            pan.temperature += 2 * Time.deltaTime;
        }
        else if (pan.isCooking == false && pan.temperature > 0)
        {
            pan.temperature -= 2 * Time.deltaTime;

            if (pan.temperature < 0)
            {
                pan.temperature = 0;
            }
        }
    }
}
