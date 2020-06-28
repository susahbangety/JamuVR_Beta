namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SnapZoneKinematic : MonoBehaviour
    {
        public VRTK_InteractableObject interact;

        protected virtual void OnEnable()
        {
            interact = (interact == null ? GetComponent<VRTK_InteractableObject>() : interact);

            interact.InteractableObjectSnappedToDropZone += OnSnap;
            interact.InteractableObjectExitedSnapDropZone += OnRelease;
        }

        protected virtual void OnSnap(object sender, InteractableObjectEventArgs e)
        {
            interact.validDrop = VRTK_InteractableObject.ValidDropTypes.DropValidSnapDropZone;
        }

        protected virtual void OnRelease(object sender, InteractableObjectEventArgs e)
        {
            interact.validDrop = VRTK_InteractableObject.ValidDropTypes.DropAnywhere;
        }
    }
}
