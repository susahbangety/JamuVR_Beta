namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class PopupNamaBahan : MonoBehaviour
    {
        public VRTK_InteractableObject interact;

        public Text bahanText;
        public string namaBahan;

        private void Start()
        {
            namaBahan = gameObject.name;
            bahanText = GameObject.Find("NamaBahan").GetComponent<Text>();
        }

        protected virtual void OnEnable()
        {
            interact = (interact == null ? GetComponent<VRTK_InteractableObject>() : interact);

            interact.InteractableObjectGrabbed += OnGrabbed;
            interact.InteractableObjectUngrabbed += UnGrabbed;
        }

        protected virtual void OnGrabbed(object sender, InteractableObjectEventArgs e)
        {
            bahanText.enabled = true;
            bahanText.text = namaBahan;
        }

        protected virtual void UnGrabbed(object sender, InteractableObjectEventArgs e)
        {
            bahanText.enabled = false;
        }
    }
}
