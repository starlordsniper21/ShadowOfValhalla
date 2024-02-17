using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timePaused : MonoBehaviour
{
    // Reference to your Timer component
    public Timer timer; // Make sure to assign this in the Inspector

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

        // Check if the timer reference is not null before using it
        if (timer != null)
        {
            // Reset the timer
            timer.ResetTimer();
        }
        else
        {
            Debug.LogWarning("Timer reference is null.");
        }

        // Load the main menu scene
        SceneManager.LoadSceneAsync("Main Menu");
    }
}

