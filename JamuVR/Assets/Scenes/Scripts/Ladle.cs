namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnitySimpleLiquid;

    public class Ladle : MonoBehaviour
    {
        public VRTK_InteractableObject interact;
        public LiquidContainer liquidContainer;

        public LiquidContainer panciLiquidContainer;

        public Collider centong;
        public string namaJamu;

        private void Update()
        {
            if(liquidContainer.FillAmountPercent > 0)
            {
                gameObject.GetComponent<Collider>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<Collider>().enabled = true;
            }
        }

        protected virtual void OnEnable()
        {
            interact = (interact == null ? GetComponent<VRTK_InteractableObject>() : interact);

            interact.InteractableObjectGrabbed += OnGrabbed;
            interact.InteractableObjectUngrabbed += OnUnGrabbed;
        }

        protected virtual void OnGrabbed(object sender, InteractableObjectEventArgs e)
        {
            centong.isTrigger = true;
        }

        protected virtual void OnUnGrabbed(object sender, InteractableObjectEventArgs e)
        {
            centong.isTrigger = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.name == "Wadah_Panci" && panciLiquidContainer.FillAmountPercent > 0)
            {
                liquidContainer.LiquidColor = panciLiquidContainer.LiquidColor;
                liquidContainer.FillAmountPercent = 1;

                panciLiquidContainer.FillAmountPercent -= 0.1f;
            }
        }
    }
}
