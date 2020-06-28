namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CanSlice : MonoBehaviour
    {
        private VRTK_InteractableObject InteractableObj;
        public Collider col;

        private void Start()
        {
            InteractableObj = gameObject.GetComponent<VRTK_InteractableObject>();
            col = gameObject.GetComponent<Collider>();
        }

        private void Update()
        {
            if(InteractableObj.isGrabbable == false)
            {
                col.isTrigger = true;
            }
            else
            {
                col.isTrigger = false;
            }
        }
    }
}
