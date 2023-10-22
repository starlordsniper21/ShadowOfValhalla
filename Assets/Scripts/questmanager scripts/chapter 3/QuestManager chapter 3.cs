using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestManager3 : MonoBehaviour
{
    public int batsToKill = 5;
    public int currentbatsKilled = 0;
    public int EnemiesToKill = 5;
    public int currentEnemiesKilled = 0;
    public int GeneralToKill = 1;
    public int currentGeneralKilled = 0;
    public TextMeshProUGUI questProgressText; // Reference to TextMeshPro Text element.

    private enum QuestState { ExploreDungeon, KeepExploringDungeon, ClearAreaOfEnemies, KeepExploringTheDungeon, KillTheGuards,GoTotheNextFloor, DefeatTheWarlockGeneral, AdvanceTothenextfloor}
    private QuestState questState = QuestState.ExploreDungeon;

    private void Start()
    {
        // Initialize your quest system here.
        UpdateQuestProgressText();
    }

    public void BatKilled()
    {
        if (questState == QuestState.ClearAreaOfEnemies)
        {
            currentbatsKilled++;

            if (currentbatsKilled >= batsToKill)
            {
                ChangeQuestState(QuestState.KeepExploringTheDungeon);
            }

            UpdateQuestProgressText();
        }
    }

    public void InitiateExploreDungeonQuest()
    {
        if (questState == QuestState.ExploreDungeon)
        {
            ChangeQuestState(QuestState.KeepExploringDungeon); // Transition to the next quest.
        }
    }

    public void KeepExploringDungeon()
    {
        if (questState == QuestState.KeepExploringDungeon)
        {
            ChangeQuestState(QuestState.ClearAreaOfEnemies);
        }
    }

    public void KeepExploringTheDungeon()
    {
        if (questState == QuestState.KeepExploringTheDungeon)
        {
            ChangeQuestState(QuestState.KillTheGuards);
        }
    }

    public void EnemiesKilled()
    {
        if (questState == QuestState.KillTheGuards)
        {
            currentEnemiesKilled++;

            if (currentEnemiesKilled >= EnemiesToKill)
            {
                ChangeQuestState(QuestState.GoTotheNextFloor);
            }

            UpdateQuestProgressText();
        }
    }

    public void GototheNextfloor()
    {
        if (questState == QuestState.GoTotheNextFloor)
        {
            ChangeQuestState(QuestState.DefeatTheWarlockGeneral);
        }
    }

    public void GeneralKilled()
    {
        if (questState == QuestState.DefeatTheWarlockGeneral)
        {
            currentGeneralKilled++;

            if (currentGeneralKilled >= GeneralToKill)
            {
                ChangeQuestState(QuestState.AdvanceTothenextfloor); ;
            }

            UpdateQuestProgressText();
        }
    }

    public void advancetothenextfloor()
    {
        if (questState ==QuestState.AdvanceTothenextfloor)
        {  }
        UpdateQuestProgressText();
    }

    void UpdateQuestProgressText()
    {
        switch (questState)
        {
            case QuestState.ExploreDungeon:
                questProgressText.text = "Talk to the Wounded Man";
                break;
            case QuestState.KeepExploringDungeon:
                questProgressText.text = "Keep Exploring the Dungeon";
                break;
            case QuestState.ClearAreaOfEnemies:
                questProgressText.text = "Clear the swarm of Bats: " + currentbatsKilled + " / " + batsToKill;
                break;
            case QuestState.KeepExploringTheDungeon:
                questProgressText.text = "Keep Exploring The Dungeon";
                break;
            case QuestState.KillTheGuards:
                questProgressText.text = "Kill all The Guards:" +currentEnemiesKilled + "/" + EnemiesToKill;
                break;
            case QuestState.GoTotheNextFloor:
                questProgressText.text = "Go To The Next Floor";
                break;
            case QuestState.DefeatTheWarlockGeneral:
                questProgressText.text = "DEFEAT THE WARLOCK GENERAL";
                break;
            case QuestState.AdvanceTothenextfloor:
                questProgressText.text = "Advance to the Next Floor";
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
