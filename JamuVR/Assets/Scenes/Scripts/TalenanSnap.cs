namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class TalenanSnap : MonoBehaviour
    {
        public VRTK_SnapDropZone snapZone;
        public VRTK_InteractableObject interact;

        protected virtual void OnEnable()
        {
            snapZone = (snapZone == null ? GetComponent<VRTK_SnapDropZone>() : snapZone);
            interact = (interact == null ? GetComponent<VRTK_InteractableObject>() : interact);

            snapZone.ObjectSnappedToDropZone += OnSnap;
            snapZone.ObjectUnsnappedFromDropZone += UnSnap;
        }

        protected virtual void OnSnap(object sender, SnapDropZoneEventArgs e)
        {
            gameObject.tag = "Sliceable";
            interact.validDrop = VRTK_InteractableObject.ValidDropTypes.DropValidSnapDropZone;
            gameObject.transform.parent = null;
        }

        protected virtual void UnSnap(object sender, SnapDropZoneEventArgs e)
        {
           gameObject.tag = "Untagged";
           interact.validDrop = VRTK_InteractableObject.ValidDropTypes.DropAnywhere;
        }
    }
}
