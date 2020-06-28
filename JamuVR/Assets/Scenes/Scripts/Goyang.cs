﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goyang : MonoBehaviour
{
    public GameObject mLiquid;
    public GameObject mLiquidMesh;

    public int mSloshSpeed = 60;
    public int mRotateSpeed = 15;

    public int difference = 25;

    // Update is called once per frame
    void Update()
    {
        //Motion
        Slosh();

        //Rotation
        mLiquidMesh.transform.Rotate(Vector3.up * mRotateSpeed * Time.deltaTime, Space.Self);
    }

    private void Slosh()
    {
        //Inverse cup rotation
        Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);
        //Quaternion Rotation = Quaternion.Normalize(transform.localRotation);

        //Rotate to
        Vector3 finalRotation = Quaternion.RotateTowards(mLiquid.transform.localRotation, inverseRotation, mSloshSpeed * Time.deltaTime).eulerAngles;

        //Clamp
        finalRotation.x = ClampRotationValue(finalRotation.x, difference);
        finalRotation.z = ClampRotationValue(finalRotation.z, difference);

        //Set
        mLiquid.transform.localEulerAngles = finalRotation;
    }

    private float ClampRotationValue(float value, float difference)
    {
        float returnValue = 0.0f;

        if (value > 180)
        {
            //Clamp
            returnValue = Mathf.Clamp(value, 360 - difference, 360);
        }
        else
        {
            //Clamp
            returnValue = Mathf.Clamp(value, 0, difference);
        }

        return returnValue;
    }
}
