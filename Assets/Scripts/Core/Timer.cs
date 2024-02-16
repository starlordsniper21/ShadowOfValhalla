using UnityEngine;

public class Timer : MonoBehaviour
{
    private float elapsedTime = 0f; // Elapsed time variable
    private bool isTimerRunning = false; // Flag to track whether the timer is running

    // Event delegate for timer tick
    public delegate void TimerTick(float time);
    public event TimerTick OnTimerTick;

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

    // Method to start the timer
    public void StartTimer()
    {
        isTimerRunning = true;
    }

    // Method to stop the timer
    public void StopTimer()
    {
        isTimerRunning = false;
    }
}

