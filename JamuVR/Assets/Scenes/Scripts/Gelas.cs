namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnitySimpleLiquid;

    public class Gelas : MonoBehaviour
    {
        public LiquidContainer liquidContainer;
        public string namaJamu;

        public JenisJamu[] jenisJamu;

        [System.Serializable]
        public class JenisJamu
        {
            public string jamuName;
            public Color warnaJamu;
        }

        public SnapOrder snapOrder;
        public VRTK_SnapDropZone snapZone;

        public bool isChecked;

        // Update is called once per frame
        void Update()
        {
            if (liquidContainer.LiquidColor == jenisJamu[0].warnaJamu)
            {
                namaJamu = jenisJamu[0].jamuName;
            }
            if (liquidContainer.LiquidColor == jenisJamu[1].warnaJamu)
            {
                namaJamu = jenisJamu[1].jamuName;
            }
            if (liquidContainer.LiquidColor == jenisJamu[2].warnaJamu)
            {
                namaJamu = jenisJamu[2].jamuName;
            }

            OnSnapChecked();
        }

        protected virtual void OnEnable()
        {
            snapZone = (snapZone == null ? GetComponent<VRTK_SnapDropZone>() : snapZone);

            snapZone.ObjectSnappedToDropZone += OnSnap;
        }

        protected virtual void OnSnap(object sender, SnapDropZoneEventArgs e)
        {
            snapOrder.isChecked = true;
        }

        public void OnSnapChecked()
        {
            if (!snapOrder.isChecked) return;
            bool isCorrect = false;
            isChecked = false;
            for (int i = 0; i < snapOrder.jamuOrder.Count; i++)
            {
                if (namaJamu == snapOrder.jamuOrder[i])
                {
                    isCorrect = true;
                    snapOrder.check[i] = true;
                    snapOrder.succesOrder += 1;
                    //snapOrder.DoneOrdering(snapOrder.jamuOrder[i]);
                    snapOrder.jamuSukses.Add(namaJamu);
                    snapOrder.failOrder -= 1;
                    snapOrder.a++;
                    if (snapOrder.failOrder < 0)
                    {
                        snapOrder.failOrder = 0;
                    }
                    snapOrder.succesText.text = snapOrder.succesOrder.ToString();
                }
                else if (namaJamu != snapOrder.jamuOrder[i] && !isChecked)
                {
                    snapOrder.check[i] = false;
                    snapOrder.failOrder += 1;
                    snapOrder.failText.text = snapOrder.failOrder.ToString();
                    isChecked = true;
                }
                Destroy(gameObject);
            }
            if (isCorrect) snapOrder.SuccesOrdering();
            else snapOrder.WrongOrdering();
            snapOrder.isChecked = false;
        }
    }
}
