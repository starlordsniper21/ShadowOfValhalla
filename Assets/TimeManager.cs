using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager instance;
    public Timer timer;
    private bool destroyOnLoad = true; // Flag to determine whether to destroy the instance on scene load

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            if (destroyOnLoad)
                DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Add a method to set destroyOnLoad flag
    public void SetDestroyOnLoad(bool destroy)
    {
        destroyOnLoad = destroy;
    }

    public void StartTimer()
    {
        if (timer != null)
        {
            timer.StartTimer();
        }
    }

    public void StopTimer()
    {
        if (timer != null)
        {
            timer.PauseTimer();
        }
    }

    public void ResetTimer()
    {
        if (timer != null)
        {
            timer.ResetTimer();
        }
    }
}
