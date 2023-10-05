using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestManager2 : MonoBehaviour
{
    public int guardsToDefeat = 3;
    public int currentGuardsDefeated = 0;
    public int enemiesToDefeat = 5;
    public int currentEnemiesDefeated = 0;
    public int dungeonGuardsToDefeat = 5; // Number of guards to defeat in the dungeon
    public int currentDungeonGuardsDefeated = 0; // Current number of dungeon guards defeated
    public TextMeshProUGUI questProgressText;

    public enum QuestState
    {
        ExploreCastle,
        DefeatGuards,
        GoToMainHall,
        FindAnotherWay,
        DefeatEnemies,
        FollowRightPath,
        DefeatDungeonGuards,
        GoToDungeon // Added the eighth quest state "GoToDungeon"
    }

    private QuestState questState = QuestState.ExploreCastle;

    private bool hasExploredCastleCheckpoint = false;

    private void Start()
    {
        UpdateQuestProgressText();
    }

    public void GuardDefeated()
    {
        if (questState == QuestState.DefeatGuards)
        {
            currentGuardsDefeated++;

            if (currentGuardsDefeated >= guardsToDefeat)
            {
                ChangeQuestState(QuestState.GoToMainHall);
            }

            UpdateQuestProgressText();
        }
       
    }

    public void EnemyDefeated()
    {
        if (questState == QuestState.DefeatEnemies)
        {
            currentEnemiesDefeated++;

            if (currentEnemiesDefeated >= enemiesToDefeat)
            {
                ChangeQuestState(QuestState.FollowRightPath);
            }

            UpdateQuestProgressText();
        }
        
    }

    public void DungeonGuardsDefeated()
    {
        if (questState == QuestState.DefeatDungeonGuards)
        {
            currentDungeonGuardsDefeated++;

            if (currentDungeonGuardsDefeated >= dungeonGuardsToDefeat)
            {
                // Transition to the next quest state, which is "GoToDungeon."
                InitiateGoToDungeonQuest();
            }

            UpdateQuestProgressText();
        }
    }



    public void InitiateExploreCastleQuest()
    {
        if (questState == QuestState.ExploreCastle && !hasExploredCastleCheckpoint)
        {
            hasExploredCastleCheckpoint = true;
            ChangeQuestState(QuestState.DefeatGuards);
        }
    }

    public void InitiateGoToMainHallQuest()
    {
        if (questState == QuestState.DefeatGuards)
        {
            ChangeQuestState(QuestState.GoToMainHall);
        }
    }

    public void InitiateFindAnotherWayQuest()
    {
        if (questState == QuestState.GoToMainHall)
        {
            ChangeQuestState(QuestState.FindAnotherWay);
        }
    }

    public void InitiateDefeatEnemiesQuest()
    {
        if (questState == QuestState.FindAnotherWay)
        {
            ChangeQuestState(QuestState.DefeatEnemies);
        }
    }

    public void InitiateFollowRightPathQuest()
    {
        if (questState == QuestState.DefeatEnemies)
        {
            ChangeQuestState(QuestState.FollowRightPath);
        }
    }

    public void InitiateDefeatDungeonGuardsQuest()
    {
        if (questState == QuestState.FollowRightPath)
        {
            ChangeQuestState(QuestState.DefeatDungeonGuards);
        }
    }

    public void InitiateGoToDungeonQuest() // Method to initiate the eighth quest "GoToDungeon"
    {
        if (questState == QuestState.DefeatDungeonGuards)
        {
            ChangeQuestState(QuestState.GoToDungeon);
        }
    }

    public QuestState GetQuestState()
    {
        return questState;
    }

    void UpdateQuestProgressText()
    {
        switch (questState)
        {
            case QuestState.ExploreCastle:
                questProgressText.text = "Explore the Castle";
                break;
            case QuestState.DefeatGuards:
                questProgressText.text = "Defeat enemy Guards: " + currentGuardsDefeated + " / " + guardsToDefeat;
                break;
            case QuestState.GoToMainHall:
                questProgressText.text = "Go to the Main Hall";
                break;
            case QuestState.FindAnotherWay:
                questProgressText.text = "Find Another Way to the Main Hall";
                break;
            case QuestState.DefeatEnemies:
                questProgressText.text = "Defeat Enemies: " + currentEnemiesDefeated + " / " + enemiesToDefeat;
                break;
            case QuestState.FollowRightPath:
                questProgressText.text = "Follow the Path on your right to the Main Hall";
                break;
            case QuestState.DefeatDungeonGuards:
                questProgressText.text = "Defeat the enemy Guards: " + currentDungeonGuardsDefeated + " / " + dungeonGuardsToDefeat;
                break;
            case QuestState.GoToDungeon:
                questProgressText.text = "Go down to the Castle's Dungeon"; // Eighth quest text
                break;
        }
    }

    void ChangeQuestState(QuestState newState)
    {
        questState = newState;
        UpdateQuestProgressText();
    }
}
