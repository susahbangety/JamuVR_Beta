namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnitySimpleLiquid;

    public class SnapZoneBlenderFunction : MonoBehaviour
    {
        public VRTK_InteractableObject interact;
        public LiquidContainer liquidContainer;

        public GameObject parent = null;

        private void Update()
        {
            if(interact.isGrabbable && liquidContainer.isOpen == false)
            {
                parent = GameObject.Find("Gagang");
                gameObject.transform.parent = GameObject.Find("Gagang").transform;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<Rigidbody>().useGravity = false;
            }
        }

        protected virtual void OnEnable()
        {
            interact = (interact == null ? GetComponent<VRTK_InteractableObject>() : interact);

            interact.InteractableObjectGrabbed += LostParent;
            interact.InteractableObjectUngrabbed += OnRelease;
            interact.InteractableObjectSnappedToDropZone += OnSnap;
        }

        protected virtual void OnSnap(object sender, InteractableObjectEventArgs e)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            liquidContainer.isOpen = false;
            parent = GameObject.Find("Gagang");
            gameObject.transform.parent = GameObject.Find("Gagang").transform;
        }

        protected virtual void OnRelease(object sender, InteractableObjectEventArgs e)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            parent = GameObject.Find("Blender");
            gameObject.transform.parent = GameObject.Find("Blender").transform;
            
        }

        protected virtual void LostParent(object sender, InteractableObjectEventArgs e)
        {
            parent = GameObject.Find("Blender");
            gameObject.transform.parent = GameObject.Find("Blender").transform;
            liquidContainer.isOpen = true;
        }
    }
}
