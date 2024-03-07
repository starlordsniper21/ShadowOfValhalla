using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timePaused : MonoBehaviour
{
    // Reference to your Timer component
    public TimerUI timerUI;

    public void resetTimer()
    {
        // Clear all PlayerPrefs
        PlayerPrefs.DeleteAll();

        // Load the Main Menu scene
        SceneManager.LoadScene("Main Menu");

        // Reset time scale to normal
        Time.timeScale = 1;

        // Reset the timer if TimeManager is present in the scene
        TimeManager timeManager = FindObjectOfType<TimeManager>();
        if (timeManager != null)
        {
            timeManager.ResetTimer();
        }
        else
        {
            Debug.LogWarning("TimeManager not found!");
        }
    }
}
