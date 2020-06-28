namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SnapZone : MonoBehaviour
    {
        public VRTK_SnapDropZone snap;

        protected void OnCollisionEnter(Collision collision)
        {
            snap = (snap == null ? GetComponent<VRTK_SnapDropZone>() : snap);

            Debug.Log(snap.GetCurrentSnappedInteractableObject());
        }
    }
}
