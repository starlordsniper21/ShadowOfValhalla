using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    private Timer timer;
    private float startTimeValue; // Store the timer value at the start of the scene

    private void Start()
    {
        timer = FindObjectOfType<Timer>();
        if (timer == null)
        {
            Debug.LogWarning("Timer not found!");
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

        // Pause the timer if it exists
        if (timer != null)
        {
            timer.PauseTimer();
        }
    }

    public void Home()
    {
        // Save the current scene index and the timer value at the start of the scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LastSceneIndex", currentSceneIndex);
        PlayerPrefs.SetFloat("StartTimeValue", startTimeValue);

        // Load the main menu scene
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

        // Resume the timer if it exists
        if (timer != null)
        {
            timer.StartTimer();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    // Method to set the start time value at the beginning of each scene
    public void SetStartTimeValue(float value)
    {
        startTimeValue = value;
    }
}
