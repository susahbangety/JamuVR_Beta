namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CapMaterials : MonoBehaviour
    {
        public Material capMaterial;
        public string namaBahan;

        private void Start()
        {
            namaBahan = gameObject.name;
        }
    }
}
