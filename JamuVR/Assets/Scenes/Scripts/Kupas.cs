using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kupas : MonoBehaviour
{
    public GameObject hasil;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Pisau_blade")
        {
            Instantiate(hasil, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
