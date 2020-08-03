namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using EzySlice;

    public class Slicer : MonoBehaviour
    {
        public Collider collide;
        public Transform cutPlane;
        public LayerMask layerMask;
        public VRTK_InteractableObject Interact;

        protected virtual void OnEnable()
        {
            Interact = (Interact == null ? GetComponent<VRTK_InteractableObject>() : Interact);

            Interact.InteractableObjectGrabbed += OnGrab;
            Interact.InteractableObjectUngrabbed += OnRelease;
        }

        protected virtual void OnDisable()
        {
            Interact = (Interact == null ? GetComponent<VRTK_InteractableObject>() : Interact);

            Interact.InteractableObjectGrabbed -= OnGrab;
            Interact.InteractableObjectUngrabbed -= OnRelease;
        }

        protected virtual void OnGrab(object sender, InteractableObjectEventArgs e)
        {
            collide.isTrigger = true;
        }

        protected virtual void OnRelease(object sender, InteractableObjectEventArgs e)
        {
            collide.isTrigger = false;
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Sliceable")
            {
                Slice();
            }
        }

        public void Slice()
        {
            Collider[] hits = Physics.OverlapBox(cutPlane.position, new Vector3(5, 0.1f, 5), cutPlane.rotation, layerMask);

            if (hits.Length <= 0)
                return;

            for (int i = 0; i < hits.Length; i++)
            {
                SlicedHull hull = SliceObject(hits[i].gameObject, hits[i].GetComponent<CapMaterials>().capMaterial);
                if (hull != null)
                {
                    GameObject bottom = hull.CreateLowerHull(hits[i].gameObject, hits[i].GetComponent<CapMaterials>().capMaterial);
                    GameObject top = hull.CreateUpperHull(hits[i].gameObject, hits[i].GetComponent<CapMaterials>().capMaterial);
                    AddHullComponents(bottom);
                    AddHullComponents(top);
                    top.name = hits[i].GetComponent<CapMaterials>().namaBahan;
                    bottom.name = hits[i].GetComponent<CapMaterials>().namaBahan;
                    Destroy(hits[i].gameObject);
                }
            }
        }

        public void AddHullComponents(GameObject go)
        {
            go.AddComponent<CapMaterials>().capMaterial = go.GetComponent<Renderer>().materials[1];

            go.layer = 9;
            Rigidbody rb = go.AddComponent<Rigidbody>();
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            MeshCollider collider = go.AddComponent<MeshCollider>();
            collider.convex = true;
            VRTK_InteractableObject Interactable = go.AddComponent<VRTK_InteractableObject>();
            go.AddComponent<DestroyBahan>();
            Interactable.isGrabbable = true;
            go.tag = "Sliceable";

            rb.AddExplosionForce(100, go.transform.position, 20);
        }

        public SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
        {
            // slice the provided object using the transforms of this object
            if (obj.GetComponent<MeshFilter>() == null)
                return null;

            return obj.Slice(cutPlane.position, cutPlane.up, crossSectionMaterial);
        }
    }
}
