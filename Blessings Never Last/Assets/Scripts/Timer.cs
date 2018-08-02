using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public float secondsRemaining = 0;
    Text textComponent;
    TimeSpan timerCountdown;

    // Use this for initialization
    void Start()
    {
        // Grab the text component we want to write to
        textComponent = gameObject.GetComponent<Text>();
        // Get init value and store it in timespan at the beginning
        timerCountdown = TimeSpan.FromSeconds(secondsRemaining);
    }

    // Update is called once per frame
    void Update()
    {
        if (secondsRemaining > 0)
        {
            // Countdown
            secondsRemaining -= Time.deltaTime;
            // Convert the float of seconds into a formatted Time variable
            timerCountdown = TimeSpan.FromSeconds(secondsRemaining);
            // use that variable here to print to UI
            textComponent.text = String.Format("{0:D2}:{1:D2}", timerCountdown.Minutes, timerCountdown.Seconds);
        }
    }
}
