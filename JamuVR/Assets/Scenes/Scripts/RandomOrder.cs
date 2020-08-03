using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Examples;
using VRTK.Examples;

public class RandomOrder : MonoBehaviour
{
    public Menu[] menu;
    public List<Ordering> ordering;

    public GameObject orderPaper;
    public GameObject originalPos;
    public float orderingTime;
    public Text orderTimeText;

    [System.Serializable]
    public class Menu
    {
        public int menuNumber;
        public string nama;
        public int harga;
    }

    [System.Serializable]
    public class Ordering
    {
        public GameObject menuObj;
        public int orderNumber;

        public Text namaOrder;
        public string orderName;

        public Text hargaOrder;
        public int orderHarga;

        public int minProb;
        public int maxProb;
    }

    [Header ("TOTAL")]
    public Text totalHarga;
    public float total;

    public bool isPicking;
    public SnapOrder snapOrder;

    public Timer timer;
    public RandomSpawnOrder randomSpawnOrder;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("Ring Bell").GetComponent<Timer>();
        snapOrder = GameObject.Find("SnapOrderan").GetComponent<SnapOrder>();
        randomSpawnOrder = GameObject.Find("OrderBar").GetComponent<RandomSpawnOrder>();
        //orderTimeText = GameObject.Find("OrderTimer").GetComponent<Text>();
        originalPos = GameObject.Find("Order");

        if (orderPaper.activeSelf == true)
        {
            random();

            if (ordering[0].menuObj.activeSelf == true)
            {
                Order();
            }

            orderingTime = 360f;
            if(ordering[1].menuObj.activeSelf == true)
            {
                orderingTime = 720f;
            }
        }
    }

    private void Update()
    {
        //for (int i = 0; i < ordering.Count; i++)
        //{
            if (isPicking == true && snapOrder.jamuOrder.Count < 2 && snapOrder.strukPicking.Count < 1)
            {
                OrderingCountdown();
                snapOrder.jamuOrder.Add(ordering[0].orderName);

                if (ordering[1].menuObj.activeSelf == true)
                {
                    snapOrder.jamuOrder.Add(ordering[1].orderName);
                }
                if (snapOrder.jamuOrder.Count == 2)
                {
                    if (snapOrder.jamuOrder[1] == snapOrder.jamuOrder[0])
                    {
                        snapOrder.jamuOrder.Remove(snapOrder.jamuOrder[1]);
                    }
                }
                if ((snapOrder.jamuSukses.Count > 0 && snapOrder.jamuSukses.Count == snapOrder.jamuOrder.Count) || orderingTime == 0)
                {
                    orderPaper.SetActive(false);
                    orderPaper.transform.position = originalPos.transform.position;
                    orderPaper.transform.rotation = originalPos.transform.rotation;
                    snapOrder.jamuOrder.Clear();
                    snapOrder.jamuSukses.Clear();
                    orderingTime = 0;
                    orderTimeText.text = "";
                    //orderPaper.GetComponent<GrabOrder>().canGrab = false;
                    randomSpawnOrder.doneOrdering.Add(orderPaper);
                }
            timer.isPickingOrder = true;
            }
            else if(snapOrder.jamuOrder.Count > 0)
            {
                isPicking = false;
            }
        
    }

    void Order()
    {
        ordering[0].orderNumber = menu[Random.Range(0, menu.Length)].menuNumber;

        if (ordering[1].menuObj.activeSelf == true)
        {
            ordering[1].orderNumber = menu[Random.Range(0, menu.Length)].menuNumber;
        }

        while (ordering[1].orderNumber == ordering[0].orderNumber && ordering[1].menuObj.activeSelf == true)
        {
            ordering[1].orderNumber = menu[Random.Range(0, menu.Length)].menuNumber;
        }

        for (int i = 0; i < ordering.Count; i++)
        {
            if (ordering[i].orderNumber == menu[0].menuNumber)
            {
                ordering[i].orderName = menu[0].nama;
                ordering[i].orderHarga = menu[0].harga;
            }
            else if (ordering[i].orderNumber == menu[1].menuNumber)
            {
                ordering[i].orderName = menu[1].nama;
                ordering[i].orderHarga = menu[1].harga;
            }
            else if (ordering[i].orderNumber == menu[2].menuNumber)
            {
                ordering[i].orderName = menu[2].nama;
                ordering[i].orderHarga = menu[2].harga;
            }
            //else if (ordering[i].orderNumber == menu[3].menuNumber)
            //{
            //    ordering[i].orderName = menu[3].nama;
            //    ordering[i].orderHarga = menu[3].harga;
            //}
            //else if (ordering[i].orderNumber == menu[4].menuNumber)
            //{
            //    ordering[i].orderName = menu[4].nama;
            //    ordering[i].orderHarga = menu[4].harga;
            //}
            //else if (ordering[i].orderNumber == menu[5].menuNumber)
            //{
            //    ordering[i].orderName = menu[5].nama;
            //    ordering[i].orderHarga = menu[5].harga;
            //}
            //else if (ordering[i].orderNumber == menu[6].menuNumber)
            //{
            //    ordering[i].orderName = menu[6].nama;
            //    ordering[i].orderHarga = menu[6].harga;
            //}
        }

        ordering[0].namaOrder.text = ordering[0].orderName;
        ordering[1].namaOrder.text = ordering[1].orderName;

        ordering[0].hargaOrder.text = ordering[0].orderHarga.ToString();
        ordering[1].hargaOrder.text = ordering[1].orderHarga.ToString();

        total = ordering[0].orderHarga + ordering[1].orderHarga;
        totalHarga.text = total.ToString();
    }

    void random()
    {
        int i = Random.Range(0, 100);

        for (int j = 0; j < ordering.Count; j++)
        {
            if (i >= ordering[j].minProb && i <= ordering[j].maxProb)
            {
                ordering[j].menuObj.SetActive(true);
            }
        }
    }

    public void OrderingCountdown()
    {
        orderingTime -= 1 * Time.deltaTime;
        orderTimeText.text = orderingTime.ToString("0");

        if (orderingTime <= 0)
        {
            orderingTime = 0;
        }
    }
}
