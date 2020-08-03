namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Panci : MonoBehaviour
    {
        public bool isCooking;
        public float currTemperature;
        //public float maxTemperature = 100f;

        public GameObject insideCollider;

        public VRTK_InteractableObject interact;

        protected virtual void OnEnable()
        {
            interact = (interact == null ? GetComponent<VRTK_InteractableObject>() : interact);

            //interact.InteractableObjectEnabled += EnableCollider;
            //interact.InteractableObjectDisabled += DisableCollider;
        }

        protected virtual void EnableCollider(object sender, InteractableObjectEventArgs e)
        {
            gameObject.GetComponent<Collider>().enabled = true;
            insideCollider.SetActive(false);
        }

        protected virtual void DisableCollider(object sender, InteractableObjectEventArgs e)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            insideCollider.SetActive(true);
        }
    }
}
