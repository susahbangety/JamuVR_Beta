namespace VRTK.Examples
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

    public class Timer : MonoBehaviour
    {
        public VRTK_InteractableObject interact;

        public GameObject orderPaper;

        public bool countdownMode;
        public Text countdownText;
        public int countdown;
        public GameObject movePlayer;

        public GameObject orderBar;
        public Text prepareText;
        public int round;
        public bool nextRound;

        public Text timerText;
        public float currentTime;
        public float startingTime;
        
        public bool isPrepare = false;
        public bool isChallenge = false;
        public bool isPickingOrder = false;

        public SnapOrder snapOrder;

        private void Start()
        {
            round = 1;
            currentTime = startingTime;
            countdownText.enabled = false;
            orderBar.SetActive(false);
        }

        private void Update()
        {
            if(isPrepare == true)
            {
                prepareText.text = "Prepared Time";
                Countdown();
            }
            else if(isChallenge == true && isPrepare == false && countdownMode == false)
            {
                prepareText.text = "Round" + ""+round;
                if (currentTime == 0) currentTime = startingTime;
                orderBar.SetActive(true);
                Countdown();
            }
        }

        protected virtual void OnEnable()
        {
            interact = (interact == null ? GetComponent<VRTK_InteractableObject>() : interact);

            interact.InteractableObjectTouched += OnPlaying;
        }

        protected virtual void OnPlaying(object sender, InteractableObjectEventArgs e)
        {
            isPrepare = true;
        }

        public void Countdown()
        {
            currentTime -= 1 * Time.deltaTime;
            timerText.text = currentTime.ToString("0");

            if(currentTime <= 0 && isPrepare == true)
            {
                currentTime = 0;
                startingTime = 360;
                StartCoroutine(ModeCountdown());
                isPrepare = false;
                prepareText.text = "";
                timerText.text = "";
            }
            if ((snapOrder.failOrder == 10 || currentTime <= 0) && isChallenge == true && isPrepare == false)
            {
                currentTime = 0;
                isChallenge = false;
            }
        }

        public IEnumerator ModeCountdown()
        {
            while(countdown > 0)
            {
                countdownText.enabled = true;
                countdownMode = true;
                movePlayer.SetActive(false);
                countdownText.text = countdown.ToString("0");

                yield return new WaitForSeconds(1f);

                countdown--;
            }
            countdownText.text = "Mulai";

            yield return new WaitForSeconds(1f);
            isChallenge = true;

            countdownText.enabled = false;

            movePlayer.SetActive(true);
            countdownMode = false;
        }

        public void NextRound()
        {
            round += 1;
            startingTime -= 20;
            currentTime = startingTime;
            timerText.text = currentTime.ToString();
            nextRound = true;
            countdown = 3;
            StartCoroutine(CountdownNextRound());
        }

        public IEnumerator CountdownNextRound()
        {
            while (countdown > 0)
            {
                isChallenge = false;
                countdownText.enabled = true;
                countdownMode = true;
                movePlayer.SetActive(false);
                countdownText.text = countdown.ToString("0");

                yield return new WaitForSeconds(1f);

                countdown--;
            }
            countdownText.text = "Round" + round;

            yield return new WaitForSeconds(1f);
            isChallenge = true;

            countdownText.enabled = false;
            movePlayer.SetActive(true);
            countdownMode = false;
            nextRound = false;
        }
    }
}
