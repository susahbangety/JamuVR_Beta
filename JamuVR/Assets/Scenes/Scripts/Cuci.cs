using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuci : MonoBehaviour
{
    public bool isCleaning;
    public GameObject pastePreset;

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.name == "LiquidParticlesKeran(Clone)")
        {
            isCleaning = true;
        }
    }
}
