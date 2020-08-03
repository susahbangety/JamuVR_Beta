namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SnapGelas : MonoBehaviour
    {
        public VRTK_InteractableObject interact;

        public GameObject parent;

        protected virtual void OnEnable()
        {
            interact = (interact == null ? GetComponent<VRTK_InteractableObject>() : interact);

            interact.InteractableObjectSnappedToDropZone += OnSnap;
            interact.InteractableObjectUnsnappedFromDropZone += OnRelease;
        }

        protected virtual void OnSnap(object sender, InteractableObjectEventArgs e)
        {
            interact.validDrop = VRTK_InteractableObject.ValidDropTypes.DropValidSnapDropZone;
            gameObject.GetComponent<Collider>().enabled = false;

            parent = interact.GetStoredSnapDropZone().gameObject;
            gameObject.transform.parent = parent.transform;
        }

        protected virtual void OnRelease(object sender, InteractableObjectEventArgs e)
        {
            interact.validDrop = VRTK_InteractableObject.ValidDropTypes.DropAnywhere;
            gameObject.GetComponent<Collider>().enabled = true;
            gameObject.transform.parent = null;
        }

        
    }
}
