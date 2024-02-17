using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float elapsedTime = 0f; // Elapsed time variable
    public bool isTimerRunning = false; // Flag to track whether the timer is running

    // Event delegate for timer tick
    public delegate void TimerTick(float time);
    public event TimerTick OnTimerTick;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            StartTimer(); // Start the timer if it's not the main menu scene
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if the timer is running
        if (isTimerRunning)
        {
            // Update the timer only when it's running
            elapsedTime += Time.deltaTime;

            // Emit the current elapsed time
            OnTimerTick?.Invoke(elapsedTime);

            // Print or log the elapsed time
            Debug.Log("Elapsed Time: " + elapsedTime);
        }
    }

    // Method to start the timer manually
    public void StartTimer()
    {
        isTimerRunning = true;
    }

    // Method to stop the timer
    public void StopTimer()
    {
        Debug.Log("Paused Timer");
        isTimerRunning = false;
        Time.timeScale = 0;
    }

    // Method to reset the timer
    public void ResetTimer()
    {
        elapsedTime = 0f;
    }
}
