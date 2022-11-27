using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject timeBar;
    public Slider timerSlider;
    public Image fillImage;
    public int timeSet;
    public int secondsLeft;
    public bool takingAway = false;
    public bool runTimer = false;

    void Start()
    {
        timerSlider = timeBar.GetComponent<Slider>();
        secondsLeft = timeSet;
        timerSlider.value = secondsLeft;
        timerSlider.maxValue = timeSet;
    }


    void Update()
    {
        if(runTimer)
        {
            if (takingAway == false && secondsLeft > 0)
            {
                StartCoroutine(TimerTake());
            }
        }

        //Makes timer bar disappear when at 0
        if (timerSlider.value <= timerSlider.minValue)
        {
            fillImage.enabled = false;
        }

        //Makes timer bar re-appear when above 0
        if (timerSlider.value > timerSlider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }


    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        timerSlider.value = secondsLeft;
        takingAway = false;
    }

    public void ResetTimer()
    {
        if(secondsLeft <= 0)
        {
            secondsLeft = timeSet;
        }
    }
}
