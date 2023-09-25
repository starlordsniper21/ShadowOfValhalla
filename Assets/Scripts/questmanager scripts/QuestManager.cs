using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public int enemiesToKill = 5;
    public int currentEnemiesKilled = 0;
    public TextMeshProUGUI questProgressText; // Reference to TextMeshPro Text element.

    private enum QuestState { InvestigateVillage, DefeatEnemies, GoToCastle }
    private QuestState questState = QuestState.InvestigateVillage;

    private void Start()
    {
        // Initialize your quest system here.
        UpdateQuestProgressText();
    }

    public void EnemyKilled()
    {
        if (questState == QuestState.DefeatEnemies)
        {
            currentEnemiesKilled++;

            // Check if all enemies are defeated.
            if (currentEnemiesKilled >= enemiesToKill)
            {
                ChangeQuestState(QuestState.GoToCastle);
            }

            UpdateQuestProgressText();
        }
    }

    //  method to initiate the "Investigate the Village" quest.
    public void InitiateInvestigateVillageQuest()
    {
        if (questState == QuestState.InvestigateVillage)
        {
            ChangeQuestState(QuestState.DefeatEnemies); // Transition to the next quest.
        }
    }

    void UpdateQuestProgressText()
    {
        // Update the TextMeshPro Text element based on the current quest state.
        switch (questState)
        {
            case QuestState.InvestigateVillage:
                questProgressText.text = "Investigate the Village";
                break;
            case QuestState.DefeatEnemies:
                questProgressText.text = "Defeat All Canute's goons: " + currentEnemiesKilled + " / " + enemiesToKill;
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
