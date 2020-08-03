namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SwitchLampu : MonoBehaviour
    {
        public bool isOn;
        public GameObject lights;

        public VRTK_InteractableObject interact;

        protected virtual void OnEnable()
        {
            interact = (interact == null ? GetComponent<VRTK_InteractableObject>() : interact);

            interact.InteractableObjectUsed += SwitchOn;
            interact.InteractableObjectUnused += SwitchOff;
        }

        protected virtual void SwitchOn(object sender, InteractableObjectEventArgs e)
        {
            isOn = true;
            gameObject.transform.Rotate(25, 0, 0);
            lights.SetActive(true);
        }

        protected virtual void SwitchOff(object sender, InteractableObjectEventArgs e)
        {
            isOn = false;
            gameObject.transform.Rotate(-25, 0, 0);
            lights.SetActive(false);
        }
    }
}
