using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager instance;

    // Reference to the Timer object
    public Timer timer;

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scene changes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }

    // Method to start the timer manually
    public void StartTimer()
    {
        if (timer != null)
        {
            timer.StartTimer();
        }
    }

    // Method to stop the timer
    public void StopTimer()
    {
        if (timer != null)
        {
            timer.StopTimer();
        }
    }

    // Method to reset the timer
    public void ResetTimer()
    {
        if (timer != null)
        {
            timer.ResetTimer();
        }
    }
}
