using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timePaused : MonoBehaviour
{
    // Reference to your Timer component
    public TimerUI timerUI;

    private void Start()
    {
        // Check if the current scene is named "LeaderBoardPanel"
        if (SceneManager.GetActiveScene().name == "LeaderBoardPanel")
        {
            // Pause the timer by setting the time scale to 0
            Time.timeScale = 0f;
        }
    }

    public void resetTimer()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;

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

