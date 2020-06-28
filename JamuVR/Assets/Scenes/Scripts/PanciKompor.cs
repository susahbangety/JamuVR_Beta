namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PanciKompor : MonoBehaviour
    {
        public VRTK_SnapDropZone snapZone;

        public GameObject colliderPanci;

        protected virtual void OnEnable()
        {
            snapZone = (snapZone == null ? GetComponent<VRTK_SnapDropZone>() : snapZone);

            snapZone.ObjectSnappedToDropZone += OnSnap;
            snapZone.ObjectUnsnappedFromDropZone += UnSnap;
        }

        protected virtual void OnSnap(object sender, SnapDropZoneEventArgs e)
        {
            colliderPanci.SetActive(true);
        }

        protected virtual void UnSnap(object sender, SnapDropZoneEventArgs e)
        {
            colliderPanci.SetActive(false);
        }
    }
}
