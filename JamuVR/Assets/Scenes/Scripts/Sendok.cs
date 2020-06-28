using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sendok : MonoBehaviour
{
    public GameObject gulaPreset;
    public GameObject pastePreset;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Collider_Gula" && pastePreset.activeSelf == false)
        {
            gulaPreset.SetActive(true);
        }
        if(other.gameObject.name == "paste" && gulaPreset.activeSelf == false)
        {
            pastePreset.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }
}
