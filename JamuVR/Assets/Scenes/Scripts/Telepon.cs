namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Telepon : MonoBehaviour
    {
        public GameObject shopUI;

        public VRTK_InteractableObject interact;

        protected virtual void OnEnable()
        {
            interact = (interact == null ? GetComponent<VRTK_InteractableObject>() : interact);

            interact.InteractableObjectGrabbed += EnableRGB;
            interact.InteractableObjectSnappedToDropZone += OnSnap;
            interact.InteractableObjectExitedSnapDropZone += OnRelease;
        }

        protected virtual void EnableRGB(object sender, InteractableObjectEventArgs e)
        {
            shopUI.SetActive(true);
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }

        protected virtual void OnSnap(object sender, InteractableObjectEventArgs e)
        {
            shopUI.SetActive(false);
            interact.validDrop = VRTK_InteractableObject.ValidDropTypes.DropValidSnapDropZone;
        }

        protected virtual void OnRelease(object sender, InteractableObjectEventArgs e)
        {
            interact.validDrop = VRTK_InteractableObject.ValidDropTypes.DropAnywhere;
        }
    }
}
