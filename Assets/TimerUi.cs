using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public Timer timer; // Reference to the Timer script
    public TextMeshProUGUI timerText;

    private void Start()
    {
        // Subscribe to the timer tick event to update the UI text
        if (timer != null)
        {
            timer.OnTimerTick += UpdateTimeUI;
        }
        else
        {
            Debug.LogWarning("Timer reference is not set in TimerUI!");
        }
    }

    private void OnDestroy()
    {
        // Unsubscribe from the timer tick event to prevent memory leaks
        if (timer != null)
        {
            timer.OnTimerTick -= UpdateTimeUI;
        }
    }

    private void UpdateTimeUI(float time)
    {
        // Calculate hours, minutes, seconds, and milliseconds
        int hours = Mathf.FloorToInt(time / 3600);
        int minutes = Mathf.FloorToInt((time % 3600) / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);

        // Format the time string in stopwatch format (HH:MM:SS:MS)
        string formattedTime = string.Format("{0:00}:{1:00}:{2:00}:{3:000}",
            hours, // Hours
            minutes, // Minutes
            seconds, // Seconds
            milliseconds); // Milliseconds

        // Update the TextMeshPro text element with the formatted time
        timerText.text = "Elapsed Time: " + formattedTime;
    }
}
