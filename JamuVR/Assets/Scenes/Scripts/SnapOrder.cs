using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Examples;

public class SnapOrder : MonoBehaviour
{
    public List<GameObject> strukOrder = new List<GameObject>();
    public List<string> jamuOrder = new List<string>();
    public List<GameObject> strukPicking = new List<GameObject>();
    public float orderingTimer;

    public int succesOrder;
    public Text succesText;

    public int failOrder;
    public Text failText;

    public int rating = 100;
    public Text ratingText;

    public List<string> jamuSukses = new List<string>();
    public bool[] check;
    public bool isChecked;
    public bool isCalculated;

    public int a = 0;

    [Header("Post Game")]
    public GameObject postGame;
    public GameObject midGame;
    public Text postRatingText;

    [Header("Penghasilan")]
    public Text penghasilanText;
    public float penghasilan;

    [Header("Another Script")]
    public Timer timer;

    private void Update()
    {
        //if (jamuOrder.Count == 2)
        //{
        //    if (jamuOrder[1] == jamuOrder[0])
        //    {
        //        jamuOrder.Remove(jamuOrder[1]);
        //    }
        //}
    }

    public void SuccesOrdering()
    {
        if (jamuSukses.Count > 0 && a > 0)
        {
            if (timer.currentTime >= 180 && timer.currentTime <= 360)
            {
                penghasilan += 20000;
            }
            if(timer.currentTime < 180)
            {
                penghasilan += 10000;
            }
        }
        penghasilanText.text = penghasilan.ToString();
        a = 0;
    }

    public void WrongOrdering()
    {
        penghasilan += 2000;
        penghasilanText.text = penghasilan.ToString();
        rating -= 10;
        ratingText.text = rating.ToString() +"%";
    }

    public void DoneOrdering(string namaObject)
    {
        jamuOrder.Remove(namaObject);
    }

    public void PostGame()
    {
        postGame.SetActive(true);
        midGame.SetActive(false);
        postRatingText.text = rating.ToString();
    }
}
