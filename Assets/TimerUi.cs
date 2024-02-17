using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    private Timer timer; // Reference to the Timer script
    public TextMeshProUGUI timerText; // Reference to the TextMeshProUGUI component

    private void Start()
    {
        // Find the Timer script component in the scene
        timer = FindObjectOfType<Timer>();

        if (timer == null)
        {
            Debug.LogError("Timer script not found in the scene.");
        }
        else
        {
            // Subscribe to the timer events
            timer.OnTimerTick += UpdateTimerUI;

            // If the timer is already running, update the UI immediately
            if (timer.isTimerRunning)
            {
                UpdateTimerUI(timer.elapsedTime);
            }
        }
    }

    private void UpdateTimerUI(float newValue)
    {
        // Update the text of the TextMeshPro UI element with the current timer value
        timerText.text = "Timer: " + FormatTime(newValue);
    }

    private string FormatTime(float timeInSeconds)
    {
        // Format the timer value into minutes and seconds
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the timer events
        if (timer != null)
        {
            timer.OnTimerTick -= UpdateTimerUI;
        }
    }
}
