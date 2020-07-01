namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using VRTK.Controllables;

    public class BukuResep : MonoBehaviour
    {
        public VRTK_BaseControllable baseControl;
        public VRTK_InteractableObject interact;

        public bool isOpen;

        public Texture[] halamanMats;
        public GameObject bukuKiri;
        public GameObject bukuKanan;

        public int index;

        private void Update()
        {
            
        }

        protected virtual void OnEnable()
        {
            baseControl = (baseControl == null ? GetComponent<VRTK_BaseControllable>() : baseControl);
            interact = (interact == null ? GetComponent<VRTK_InteractableObject>() : interact);

            baseControl.MinLimitExited += BookOpen;
            baseControl.MinLimitReached += BookClosed;

            interact.InteractableObjectUsed += ChangePage;
        }
        
        protected virtual void BookOpen(object sender, ControllableEventArgs e)
        {
            isOpen = true;
        }

        protected virtual void BookClosed(object sender, ControllableEventArgs e)
        {
            isOpen = false;
        }

        protected virtual void ChangePage(object sender, InteractableObjectEventArgs e)
        {
            //if (bukuKiri.GetComponent<Renderer>().materials[2].mainTexture == halamanMats[0] && 
            //    bukuKanan.GetComponent<Renderer>().materials[2].mainTexture == halamanMats[0])
            //{
            //    bukuKiri.GetComponent<Renderer>().materials[2].mainTexture = halamanMats[1];
            //    bukuKanan.GetComponent<Renderer>().materials[2].mainTexture = halamanMats[1];
            //}
            Debug.Log("Used");
        }
    }
}
