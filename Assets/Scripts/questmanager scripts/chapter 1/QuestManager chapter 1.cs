using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public int enemiesToKill = 5;
    public int currentEnemiesKilled = 0;
    public int guardsToKill = 5;
    public int currentguardsKilled = 0;
    public TextMeshProUGUI questProgressText; // Reference to TextMeshPro Text element.

    private enum QuestState { InvestigateVillage, DefeatEnemies, traveltoakumajoCastle, EntertheakumajoCastle, DefeatGuards, GoInsideCastle }
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

            if (currentEnemiesKilled >= enemiesToKill)
            {
                ChangeQuestState(QuestState.traveltoakumajoCastle);
            }

            UpdateQuestProgressText();
        }
    }

    public void InitiateInvestigateVillageQuest()
    {
        if (questState == QuestState.InvestigateVillage)
        {
            ChangeQuestState(QuestState.DefeatEnemies); // Transition to the next quest.
        }
    }

    public void traveltoakumajocastle()
    {
        if (questState == QuestState.DefeatEnemies)
        {
            ChangeQuestState(QuestState.traveltoakumajoCastle);
        }
    }

    public void EntertheakumajoCastle()
    {
        if (questState == QuestState.traveltoakumajoCastle)
        {
            ChangeQuestState(QuestState.EntertheakumajoCastle);
        }
    }

    // Method to transition to the "Defeat Guards" quest.
    public void DefeatTheGuards()
    {
        if (questState == QuestState.EntertheakumajoCastle)
        {
            ChangeQuestState(QuestState.DefeatGuards);
        }
    }

    // Separate logic for the "Defeat Guards" quest.
    public void GuardsDefeated()
    {
        if (questState == QuestState.DefeatGuards)
        {
            currentguardsKilled++;

            if (currentguardsKilled >= guardsToKill)
            {
                ChangeQuestState(QuestState.GoInsideCastle);
            }

            UpdateQuestProgressText();
        }
    }

    // Method to transition to the 7th quest "Go Inside the Castle."
    public void GoInsideCastle()
    {
        if (questState == QuestState.GoInsideCastle)
        {
           
        }
    }

    void UpdateQuestProgressText()
    {
        switch (questState)
        {
            case QuestState.InvestigateVillage:
                questProgressText.text = "Investigate the Village";
                break;
            case QuestState.DefeatEnemies:
                questProgressText.text = "Defeat All Canute's goons: " + currentEnemiesKilled + " / " + enemiesToKill;
                break;
            case QuestState.traveltoakumajoCastle:
                questProgressText.text = "travel to the akumajo Castle";
                break;
            case QuestState.EntertheakumajoCastle:
                questProgressText.text = "Enter the  akumajo Castle";
                break;
            case QuestState.DefeatGuards:
                questProgressText.text = "Defeat The Guards in front of the entrance: " + currentguardsKilled + " / " + guardsToKill;
                break;
            case QuestState.GoInsideCastle:
                questProgressText.text = "Go Inside the Castle";
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
