using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Examples;

public class DestroyBahan : MonoBehaviour
{
    public Panci panci;

    private void Start()
    {
        panci = GameObject.Find("Panci").GetComponent<Panci>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Wadah_Panci" && panci.isCooking == true)
        {
            Destroy(gameObject);
        }
    }
}
