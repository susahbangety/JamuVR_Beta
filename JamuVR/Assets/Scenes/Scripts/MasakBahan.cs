using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasakBahan : MonoBehaviour
{
    public Material cookedMats;
    public Material overcookedMats;

    public Pan pan;

    private void OnTriggerEnter(Collider collision)
    {
        //if(collision.gameObject.name == "Pan")
        //{
        //    if (pan.temperature > 50 && pan.temperature <= 120)
        //    {
        //        gameObject.GetComponent<Renderer>().material = cookedMats;
        //        Debug.Log("Cooked");
        //    }
        //    else if(pan.temperature > 120)
        //    {
        //        gameObject.GetComponent<Renderer>().material = overcookedMats;
        //        Debug.Log("OverCooked");
        //    }
        //}

        if(collision.gameObject.name == "Mengkudu")
        {
            if (pan.temperature >= 50 && pan.temperature <= 120)
            {
                collision.GetComponent<Renderer>().material = cookedMats;
                collision.name = "Mengkudu Matang";
            }
            else if (pan.temperature > 120)
            {
                collision.GetComponent<Renderer>().material = overcookedMats;
                collision.name = "Mengkudu Hangus";
            }
        }
    }
}
