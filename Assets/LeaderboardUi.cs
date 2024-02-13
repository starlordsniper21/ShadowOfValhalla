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

    public TextMeshProUGUI timerText;
    public Timer timer;

    public DataSaver dataSaver;

    DatabaseReference reference;

    bool canSubmit = true;

    private void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        FetchLeaderboardData();

        timer.OnTimerTick += UpdateTimerText;
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

        int currentTimeSeconds = Mathf.FloorToInt(Time.time);
        int minutes = currentTimeSeconds / 60;
        int seconds = currentTimeSeconds % 60;
        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

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

    IEnumerator SubmitCooldown()
    {
        canSubmit = false; // Set flag to false to prevent further submissions

        // Wait for 5 minutes
        yield return new WaitForSeconds(300f); // 300 seconds = 5 minutes

        canSubmit = true; // Set flag to true to allow submissions again
    }

    private void UpdateTimerText(float time)
    {
        string formattedTime = FormatTime(time);
        timerText.text = formattedTime;
    }


    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }



}
