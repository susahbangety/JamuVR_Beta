namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class GrabOrder : MonoBehaviour
    {
        public VRTK_InteractableObject interact;
        public bool canGrab;

        public RandomOrder randomOrder;
        public SnapOrder snapOrder;

        private void Update()
        {
            if (snapOrder.jamuOrder.Count > 0/* && snapOrder.strukOrder.Contains(gameObject)*/)
            {
                interact.isGrabbable = false;
            }else if (snapOrder.jamuOrder.Count == 0 && canGrab == false)
            {
                interact.isGrabbable = true;
            }
        }

        protected virtual void OnEnable()
        {
            interact = (interact == null ? GetComponent<VRTK_InteractableObject>() : interact);

            if (snapOrder.jamuOrder.Count == 0 && canGrab == false)
            {
                interact.InteractableObjectGrabbed += OnGrab;
                interact.InteractableObjectUngrabbed += UnGrab;
            }
        }

        protected virtual void OnGrab(object sender, InteractableObjectEventArgs e)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            snapOrder.strukOrder.Remove(gameObject);
            canGrab = true;
            if (snapOrder.jamuOrder.Count == 0)
            {
                randomOrder.isPicking = true;
            }
        }

        protected virtual void UnGrab(object sender, InteractableObjectEventArgs e)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
