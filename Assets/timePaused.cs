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
        Time.timeScale = 1f;

        // Check if the timerUI reference is not null before using it
        if (timerUI != null)
        {
            // Call the UpdateTimerUI method on the timerUI instance
            

            // Reset the timer
        }
        else
        {
            Debug.LogWarning("TimerUI reference is null.");
        }

        // Load the main menu scene
        SceneManager.LoadSceneAsync("Main Menu");
    }




}

