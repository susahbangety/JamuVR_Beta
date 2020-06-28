using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySimpleLiquid;

public class CheckIngredient : MonoBehaviour
{
    public List<GameObject> ingredients = new List<GameObject>();

    public bool spinning;

    public LiquidContainer liquidContainer;

    public List<JamuPreset> preset = new List<JamuPreset>();

    [System.Serializable]
    public class JamuPreset
    {
        public string namaJamu;
        public Color warnaJamu;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Jahe")
        {
            ingredients.Add(other.gameObject);
        }
        if (other.gameObject.name == "Kencur")
        {
            ingredients.Add(other.gameObject);
        }
        if (other.gameObject.name == "Kapulaga")
        {
            ingredients.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ingredients.Remove(other.gameObject);
    }
}
