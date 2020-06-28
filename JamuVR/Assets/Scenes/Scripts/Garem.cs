namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Garem : MonoBehaviour
    {
        public VRTK_InteractableObject interact;

        public int pourThreshold = 45;
        public bool isPouring = false;

        public Transform[] spawnPos;
        public GameObject garemCube;

        protected virtual void OnEnable()
        {
            interact = (interact == null ? GetComponent<VRTK_InteractableObject>() : interact);
            
            bool pourCheck = CalculatePourAngle() < pourThreshold;

            if (isPouring != pourCheck)
            {
                isPouring = pourCheck;

                if (isPouring)
                {
                    interact.InteractableObjectUsed += OnUsed;
                }
            }
        }

        protected virtual void OnUsed(object sender, InteractableObjectEventArgs e)
        {
            for (int i = 0; i < spawnPos.Length; i++)
            {
                GameObject GaremCube = Instantiate(garemCube, spawnPos[i].position, spawnPos[i].rotation) as GameObject;
                Destroy(GaremCube, 3f);
            }
        }

        private float CalculatePourAngle()
        {
            return transform.forward.y * Mathf.Rad2Deg;
        }
    }
}
