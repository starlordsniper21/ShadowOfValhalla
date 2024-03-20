using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToLeaderboard : MonoBehaviour
{
    public float changeTime = 10f;
    public string leaderboardSceneName = "LeaderBoardPanel";
    public string mainMenuSceneName = "Main Menu";

    void Update()
    {
        if (changeTime > 0)
        {
            changeTime -= Time.deltaTime;
            if (changeTime <= 0)
            {
                LoadScene();
            }
        }
    }

    void LoadScene()
    {
        Timer timer = FindObjectOfType<Timer>();
        if (timer == null)
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }
        else
        {
            SceneManager.LoadScene(leaderboardSceneName);
        }
    }
}
