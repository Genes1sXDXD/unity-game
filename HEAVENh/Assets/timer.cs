using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float initialTimerValue = 360.0f; // 6 minutes in seconds
    private float timerValue;
    

    void Start()
    {
        timerValue = initialTimerValue;
    }

    void Update()
    {
        if (timerValue > 0)
        {
            timerValue -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            // Timer has reached 0, reset the timer
        
            ResetTimer();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timerValue / 60);
        int seconds = Mathf.FloorToInt(timerValue % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
   

    void ResetTimer()
    {
        timerValue = initialTimerValue;
    }
}

