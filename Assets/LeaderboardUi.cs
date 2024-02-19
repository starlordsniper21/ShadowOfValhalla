using UnityEngine;
using TMPro;
using Firebase.Database;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class LeaderboardUI : MonoBehaviour
{
    public List<TextMeshProUGUI> namesTextList;
    public List<TextMeshProUGUI> timesTextList;
    public TMP_InputField nameInputField;
    public Button submitButton;
    private Timer timer; // Reference to your Timer script
    public DataSaver dataSaver;

    DatabaseReference reference;
    bool canSubmit = true;

    private void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FetchLeaderboardData();
        timer = FindObjectOfType<Timer>(); // Dynamically find the Timer object
    }

    void FetchLeaderboardData()
    {
        dataSaver.LoadDataFn();
        for (int i = 0; i < namesTextList.Count; i++)
        {
            if (i < dataSaver.dts.names.Count)
            {
                namesTextList[i].text = dataSaver.dts.names[i];
            }
            else
            {
                namesTextList[i].text = "";
            }
        }

        for (int i = 0; i < timesTextList.Count; i++)
        {
            if (i < dataSaver.dts.time.Count)
            {
                timesTextList[i].text = dataSaver.dts.time[i].ToString();
            }
            else
            {
                timesTextList[i].text = "";
            }
        }
    }

    public void SubmitTime()
    {
        if (!canSubmit)
        {
            Debug.LogWarning("You can only submit data once every 5 minutes.");
            return;
        }

        // Ensure Timer is not null and running
        if (timer != null && timer.isTimerRunning)
        {
            string formattedTime = FormatTime(timer.elapsedTime);
            string playerName = nameInputField.text;

            if (string.IsNullOrEmpty(playerName))
            {
                Debug.LogWarning("Please enter your name.");
                return;
            }

            dataSaver.dts.names.Add(playerName);
            dataSaver.dts.time.Add(formattedTime);

            // Save the data
            dataSaver.SaveDataFn();

            // Fetch leaderboard data after submitting time
            FetchLeaderboardData();

            StartCoroutine(SubmitCooldown());
        }
        else
        {
            Debug.LogWarning("Timer is not running.");
        }
    }

    IEnumerator SubmitCooldown()
    {
        canSubmit = false;
        yield return new WaitForSeconds(300f);

        canSubmit = true;
    }


    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
