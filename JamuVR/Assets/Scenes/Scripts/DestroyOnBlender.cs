using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Examples;

public class DestroyOnBlender : MonoBehaviour
{
    public Blender blender;

    // Start is called before the first frame update
    void Start()
    {
        blender = GameObject.Find("On/Off").GetComponent<Blender>();
    }

    // Update is called once per frame
    void Update()
    {
        if(blender.isSpinning == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
