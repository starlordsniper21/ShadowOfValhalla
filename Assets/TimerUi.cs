using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    private Timer timer;
    public TextMeshProUGUI timerText;

    private void Start()
    {
        timer = FindObjectOfType<Timer>();

        if (timer == null)
        {
            Debug.LogError("Timer script not found in the scene.");
        }
        else
        {
            timer.OnTimerTick += UpdateTimerUI;
            if (timer.isTimerRunning)
            {
                UpdateTimerUI(timer.elapsedTime);
            }
        }
    }

    private void UpdateTimerUI(float newValue)
    {
        timerText.text = "Time: " + FormatTime(newValue);
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
        if (timer != null)
        {
            timer.OnTimerTick -= UpdateTimerUI;
        }
    }
}
