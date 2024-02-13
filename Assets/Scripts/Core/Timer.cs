using UnityEngine;

public class Timer : MonoBehaviour
{
    private float elapsedTime = 0f; // Elapsed time variable

    // Event delegate for timer tick
    public delegate void TimerTick(float time);
    public event TimerTick OnTimerTick;

    private void Update()
    {
        // Update the timer
        elapsedTime += Time.deltaTime;

        // Emit the current elapsed time
        OnTimerTick?.Invoke(elapsedTime);
    }
}
