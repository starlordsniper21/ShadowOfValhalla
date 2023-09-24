using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public int enemiesToKill = 5;
    public int currentEnemiesKilled = 0;
    public TextMeshProUGUI questProgressText; // Reference to TextMeshPro Text element.

    private enum QuestState { DefeatEnemies, GoToCastle }
    private QuestState questState = QuestState.DefeatEnemies;

    private void Start()
    {
        // Initialize your quest system here.
        UpdateQuestProgressText();
    }

    public void EnemyKilled()
    {
        currentEnemiesKilled++;

        // Check if all enemies are defeated.
        if (currentEnemiesKilled >= enemiesToKill)
        {
            ChangeQuestState(QuestState.GoToCastle);
        }

        UpdateQuestProgressText();
    }

    void UpdateQuestProgressText()
    {
        // Update the TextMeshPro Text element based on the current quest state.
        switch (questState)
        {
            case QuestState.DefeatEnemies:
                questProgressText.text = "Defeat All Enemies: " + currentEnemiesKilled + " / " + enemiesToKill;
                break;
            case QuestState.GoToCastle:
                questProgressText.text = "Go to the Castle";
                break;
        }
    }

    void ChangeQuestState(QuestState newState)
    {
        questState = newState;
        UpdateQuestProgressText();
    }

    // Implement additional methods for loading the next level, handling checkpoints, etc.
}
