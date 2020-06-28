namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using VRTK.Controllables;
    using UnitySimpleLiquid;

    public class Blender : MonoBehaviour
    {
        public VRTK_BaseControllable baseControllable;
        public Animator bladeSpin;
        public bool isSpinning;

        public CheckIngredient ingredients;
        public LiquidContainer liquidContainer;

        protected virtual void OnEnable()
        {
            baseControllable = (baseControllable == null ? GetComponent<VRTK_BaseControllable>() : baseControllable);

            baseControllable.MinLimitReached += DisableSpinning;
            baseControllable.MaxLimitReached += EnableSpinning;
        }

        protected virtual void EnableSpinning(object sender, ControllableEventArgs e)
        {
            bladeSpin.SetBool("IsSpin", true);

            if(ingredients.ingredients.Count > 0)
            {
                ingredients.ingredients.Clear();
                StartCoroutine(FillBlender());
            }
            isSpinning = true;
        }

        protected virtual void DisableSpinning(object sender, ControllableEventArgs e)
        {
            bladeSpin.SetBool("IsSpin", false);
            isSpinning = false;
            StopCoroutine(FillBlender());
        }

        protected virtual IEnumerator FillBlender()
        {
            while (liquidContainer.FillAmountPercent <= 1)
            {
                liquidContainer.FillAmountPercent += Time.deltaTime;
                yield return null;
            }
        }
    }
}
