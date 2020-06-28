using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Examples;

public class Api : MonoBehaviour
{
    public Panci[] panci;

    public bool panciIsCooking;
    public bool panCooking;

    // Update is called once per frame
    void Update()
    {
        if(panciIsCooking == true && panci[0].currTemperature < panci[0].maxTemperature)
        {
            panci[0].currTemperature += 2 * Time.deltaTime;
        }
        else if(panciIsCooking == false && panci[0].currTemperature != 0)
        {
            panci[0].currTemperature -= 2 * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Collider_bottom")
        {
            panciIsCooking = true;
        }
        if (other.gameObject.name == "Collider_Bawah")
        {
            panCooking = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Collider_bottom")
        {
            panciIsCooking = false;
        }
        if (other.gameObject.name == "Collider_Bawah")
        {
            panCooking = true;
        }
    }
}
