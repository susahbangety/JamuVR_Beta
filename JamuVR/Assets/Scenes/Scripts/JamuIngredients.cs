using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnitySimpleLiquid;
using UnityEngine.UI;
using VRTK.Examples;

public class JamuIngredients : MonoBehaviour
{
    public LiquidContainer liquidContainer;
    public JenisJamu[] jenisJamu;
    public JamuBahan[] bahan;

    public Panci panci;
    public string namaJamu;

    private void Update()
    {
        JamuMix();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Jahe")
        {
            bahan[0].qtyBahan += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Kencur")
        {
            bahan[1].qtyBahan += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Kapulaga isi")
        {
            bahan[2].qtyBahan += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Cabe jawa")
        {
            bahan[3].qtyBahan += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "GaremCube(Clone)")
        {
            bahan[4].qtyBahan = 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Gula preset")
        {
            bahan[5].qtyBahan = 1;
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.name == "spoon_wadah")
        {
            bahan[6].qtyBahan = 1;
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.name == "Jahe Merah")
        {
            bahan[7].qtyBahan += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Cengkeh")
        {
            bahan[8].qtyBahan += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Daun Sambiloto")
        {
            bahan[9].qtyBahan += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Gula aren")
        {
            bahan[10].qtyBahan += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Kunyit")
        {
            bahan[11].qtyBahan += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Mengkudu")
        {
            bahan[12].qtyBahan += 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "Lempuyang")
        {
            bahan[13].qtyBahan += 1;
            Destroy(other.gameObject);
        }
    }

    void JamuMix()
    {
        if (panci.currTemperature > 50f)
        {
            //Jamu Masuk Angin
            if (bahan[0].qtyBahan >= 1 && bahan[1].qtyBahan >= 1 && bahan[2].qtyBahan >= 3)
            {
                //liquidContainer.LiquidColor = Color.Lerp(liquidContainer.LiquidColor, jenisJamu[0].warnaJamu, 0.5f * Time.deltaTime);
                liquidContainer.LiquidColor = jenisJamu[0].warnaJamu;
                namaJamu = "Jamu Masuk Angin";
            }

            //Jamu Cabe Puyang
            if (bahan[3].qtyBahan >= 15 && bahan[4].qtyBahan == 1 && bahan[6].qtyBahan == 1)
            {
                //liquidContainer.LiquidColor = Color.Lerp(liquidContainer.LiquidColor, jenisJamu[1].warnaJamu, 0.5f * Time.deltaTime);
                liquidContainer.LiquidColor = jenisJamu[1].warnaJamu;
                namaJamu = "Jamu Cabe Puyang";
            }

            //Jamu Pencegah Asam Urat
            if (bahan[7].qtyBahan >= 1 && bahan[8].qtyBahan >= 10 && bahan[9].qtyBahan >= 1 && bahan[10].qtyBahan >= 1 && bahan[11].qtyBahan >= 1 && bahan[12].qtyBahan >= 2)
            {
                //liquidContainer.LiquidColor = Color.Lerp(liquidContainer.LiquidColor, jenisJamu[2].warnaJamu, 0.5f * Time.deltaTime);
                liquidContainer.LiquidColor = jenisJamu[2].warnaJamu;
                namaJamu = "Jamu Pencegah Asam Urat";
            }
        }
    }

    [System.Serializable]
    public class JenisJamu
    {
        public string namaJamu;
        public Color warnaJamu;
    }

    [System.Serializable]
    public class JamuBahan
    {
        public string namaBahan;
        public int qtyBahan;
    }
}
