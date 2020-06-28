using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class Slice : MonoBehaviour
{
    public Transform cutPlane;

    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        cutPlane.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
