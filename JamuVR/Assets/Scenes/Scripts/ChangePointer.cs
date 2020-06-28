using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ChangePointer : MonoBehaviour
{
    public VRTK_Pointer Pointer;
    public VRTK_StraightPointerRenderer straightPointer;
    public VRTK_BezierPointerRenderer bezierPointer;

    public GameObject menuCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Pointer = GetComponent<VRTK_Pointer>();
        straightPointer = GetComponent<VRTK_StraightPointerRenderer>();
        bezierPointer = GetComponent<VRTK_BezierPointerRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (menuCanvas.activeSelf)
        {

        }
    }
}
