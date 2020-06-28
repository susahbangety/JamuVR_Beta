namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnitySimpleLiquid;
    using VRTK.Controllables;

    public class Keran : MonoBehaviour
    {
        public VRTK_BaseControllable baseControl;
        public VRTK_SnapDropZone snapZone;
        public LiquidContainer liquidContainer;

        public Collider collide;
        public GameObject panciCollider;

        protected virtual void OnEnable()
        {
            baseControl = (baseControl == null ? GetComponent<VRTK_BaseControllable>() : baseControl);
            snapZone = (snapZone == null ? GetComponent<VRTK_SnapDropZone>() : snapZone);

            baseControl.MinLimitExited += Opened;
            baseControl.MaxLimitExited += Closed;

            snapZone.ObjectSnappedToDropZone += OnSnap;
            snapZone.ObjectUnsnappedFromDropZone += DisableSnap;
        }

        protected virtual void Opened(object sender, ControllableEventArgs e)
        {
            liquidContainer.isOpen = true;
        }

        protected virtual void Closed(object sender, ControllableEventArgs e)
        {
            liquidContainer.isOpen = false;
        }

        protected virtual void OnSnap(object sender, SnapDropZoneEventArgs e)
        {
            collide.enabled = true;
            panciCollider.SetActive(false);
        }

        protected virtual void DisableSnap(object sender, SnapDropZoneEventArgs e)
        {
            collide.enabled = false;
            panciCollider.SetActive(true);
        }
    }
}
