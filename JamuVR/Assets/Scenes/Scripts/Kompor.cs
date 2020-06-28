namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using VRTK.Controllables;

    public class Kompor : MonoBehaviour
    {
        public VRTK_BaseControllable baseControl;

        public GameObject fire;

        protected virtual void OnEnable()
        {
            baseControl = (baseControl == null ? GetComponent<VRTK_BaseControllable>() : baseControl);

            baseControl.MaxLimitReached += EnableFire;
            baseControl.MinLimitReached += DisableFire;
        }

        protected virtual void EnableFire(object sender, ControllableEventArgs e)
        {
            fire.SetActive(true);
        }

        protected virtual void DisableFire(object sender, ControllableEventArgs e)
        {
            fire.SetActive(false);
        }
    }
}
