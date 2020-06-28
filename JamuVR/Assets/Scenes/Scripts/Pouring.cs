using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pouring : MonoBehaviour
{
    public int pourThreshold = 45;
    public Transform origin = null;
    public GameObject streamPrefab = null;
    public Renderer rend;
    public float currFillAmount;
    public float isi;

    public bool isPouring = false;
    public Streams currentStream = null;

    private void Update()
    {
        bool pourCheck = CalculatePourAngle() < pourThreshold;
        isi = rend.material.GetFloat("_FillAmount");
        
        if (isPouring != pourCheck)
        {
            isPouring = pourCheck;

            if (isPouring)
            {
                StartPour();
            }
            else if (isPouring && isi > 0.75f)
            {
                EndPour();
            }
            else
            {
                EndPour();
            }
        }
    }

    private void StartPour()
    {
        Debug.Log("Start");
        currentStream = CreateStream();
        currentStream.Begin();
    }

    private void EndPour()
    {
        Debug.Log("End");
        currentStream.End();
        currentStream = null;
    }

    private void StopPour()
    {
        Debug.Log("Stop");
        currentStream.End();
        currentStream = null;
    }

    private float CalculatePourAngle()
    {
        return transform.forward.y * Mathf.Rad2Deg;
    }

    private Streams CreateStream()
    {
        GameObject streamObj = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);

        return streamObj.GetComponent<Streams>();
    }
}
