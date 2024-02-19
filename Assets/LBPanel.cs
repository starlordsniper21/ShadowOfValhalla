using Firebase.Database;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardPanel : MonoBehaviour
{
    public DataSaver dataSaver;
    DatabaseReference reference;
    public List<TextMeshProUGUI> namesTextList;
    public List<TextMeshProUGUI> timesTextList;

    private void Start()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
        FetchLeaderboardData();
    }

    public void FetchLeaderboardData()
    {
        dataSaver.LoadDataFn();
        List<(string, string)> leaderboardData = new List<(string, string)>();
        for (int i = 0; i < dataSaver.dts.names.Count; i++)
        {
            string playerName = dataSaver.dts.names[i];
            string completionTime = dataSaver.dts.time[i];
            leaderboardData.Add((playerName, completionTime));
        }
        leaderboardData.Sort((x, y) => CompareCompletionTimes(x.Item2, y.Item2));

        for (int i = 0; i < namesTextList.Count; i++)
        {
            if (i < leaderboardData.Count)
            {
                namesTextList[i].text = leaderboardData[i].Item1;
                timesTextList[i].text = leaderboardData[i].Item2;
            }
            else
            {
                namesTextList[i].text = "";
                timesTextList[i].text = "";
            }
        }
    }

    private int CompareCompletionTimes(string time1, string time2)
    {

        string[] parts1 = time1.Split(':');
        string[] parts2 = time2.Split(':');
        int minutes1 = int.Parse(parts1[0]);
        int seconds1 = int.Parse(parts1[1]);
        int minutes2 = int.Parse(parts2[0]);
        int seconds2 = int.Parse(parts2[1]);
        int totalTime1 = minutes1 * 60 + seconds1;
        int totalTime2 = minutes2 * 60 + seconds2;

        return totalTime1.CompareTo(totalTime2);
    }

}
