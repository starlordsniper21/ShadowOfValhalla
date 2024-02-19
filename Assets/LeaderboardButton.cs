using UnityEngine;
using UnityEngine.UI;

public class LeaderboardButton : MonoBehaviour
{
    public LeaderboardPanel leaderboardPanel;

    void Start()
    {
        leaderboardPanel = FindObjectOfType<LeaderboardPanel>();
        if (leaderboardPanel == null)
        {
            Debug.LogError("LeaderboardPanel component not found in the scene.");
        }
    }

    public void OnButtonClick()
    {
        if (leaderboardPanel != null)
        {
            leaderboardPanel.FetchLeaderboardData();
        }
    }
}
