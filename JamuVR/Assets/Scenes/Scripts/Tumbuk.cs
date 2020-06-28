namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Tumbuk : MonoBehaviour
    {
        public VRTK_InteractableObject interact;
        public GameObject pastePreset;

        private void OnCollisionEnter(Collision collision)
        {
            if ((collision.gameObject.name == "Kunyit" || collision.gameObject.name == "Lempuyang" || collision.gameObject.name == "Temulawak") && collision.gameObject.GetComponent<Cuci>().isCleaning == true)
            {
                pastePreset.SetActive(true);
                Destroy(collision.gameObject);
            }
        }
    }
}
