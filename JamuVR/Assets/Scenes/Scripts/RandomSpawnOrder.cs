using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Examples;

public class RandomSpawnOrder : MonoBehaviour
{
    public List<GameObject> doneOrdering = new List<GameObject>();

    public GameObject[] orderPaper;
    public Text clearText;
    private int wait = 2;

    public Timer timer;
    public SnapOrder snapOrder;

    private void Start()
    {
        //for (int i = 0; i < orderPaper.Length; i++)
        //{
        //    doneOrdering.Add(orderPaper[i]);
        //}
    }

    private void Update()
    {
        SpawnOrderan();
    }

    public void SpawnOrderan()
    {
        if(doneOrdering.Count == 1)
        {
            timer.NextRound();
            doneOrdering.Clear();
        }
    }

    IEnumerator WaitSpawnOrderan()
    {
        while (wait > 0)
        {
            clearText.text = "Selesai";
            timer.isChallenge = false;

            yield return new WaitForSeconds(1);

            wait--;
        }
        timer.startingTime -= 20;
        timer.round += 1;

        yield return new WaitForSeconds(1);

        clearText.text = timer.currentTime.ToString("0");
        timer.isChallenge = true;
    }
}
