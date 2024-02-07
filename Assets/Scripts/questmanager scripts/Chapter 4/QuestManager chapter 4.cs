using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestManager4 : MonoBehaviour
{
    public int BanditsToKill = 5;
    public int currentBanditsKilled = 0;
    public GameObject objectToShow1; // Object to show after the 1st quest is completed.
    public GameObject objectToShow2; // Object to show after the 2nd quest is completed.
    public GameObject objectToShow3; // Object to show after the 3rd quest is completed.
    public GameObject objectToShow4; // Object to show after the 4th quest is completed.
    public GameObject objectToShow5; // Object to show after the 5th quest is completed.
    public GameObject objectToShow6; // Object to show after the 6th quest is completed.
    public GameObject objectToDestroy; // Object to destroy when the "BringStaffToGorm" quest is completed.
    public TextMeshProUGUI questProgressText; // Reference to TextMeshPro Text element.

    private enum QuestState { EnterVillage, SpeakWithElder, FindGorm, HelpGordFindStaff, BringStaffToGorm, GoToNorthEast, DefeatTheBandits, HelpGord }
    private QuestState questState = QuestState.EnterVillage;

    private void Start()
    {
        // Initialize your quest system here.
        UpdateQuestProgressText();
        // Hide all objects initially
        HideAllObjects();
    }

    private void HideAllObjects()
    {
        if (objectToShow1 != null)
            objectToShow1.SetActive(false);
        if (objectToShow2 != null)
            objectToShow2.SetActive(false);
        if (objectToShow3 != null)
            objectToShow3.SetActive(false);
        if (objectToShow4 != null)
            objectToShow4.SetActive(false);
        if (objectToShow5 != null)
            objectToShow5.SetActive(false);
        if (objectToShow6 != null)
            objectToShow6.SetActive(false);
    }

    public void InitiateEnterVillageQuest()
    {
        if (questState == QuestState.EnterVillage)
        {
            ChangeQuestState(QuestState.SpeakWithElder); // Transition to the next quest.
        }
    }

    public void SpeakWithElder()
    {
        if (questState == QuestState.SpeakWithElder)
        {
            ChangeQuestState(QuestState.FindGorm);
        }
    }

    public void FindGorm()
    {
        if (questState == QuestState.FindGorm)
        {
            ChangeQuestState(QuestState.HelpGordFindStaff);
        }
    }

    public void HelpGordFindStaff()
    {
        if (questState == QuestState.HelpGordFindStaff)
        {
            ChangeQuestState(QuestState.BringStaffToGorm);
        }
    }

    public void BringStaffToGorm()
    {
        if (questState == QuestState.BringStaffToGorm)
        {
            if (objectToDestroy != null)
                Destroy(objectToDestroy);
            ChangeQuestState(QuestState.GoToNorthEast);
        }
    }

    public void GoToNorthEast()
    {
        if (questState == QuestState.GoToNorthEast)
        {
            ChangeQuestState(QuestState.DefeatTheBandits);
        }
    }

    public void DefeatTheBandits()
    {
        if (questState == QuestState.DefeatTheBandits)
        {
            currentBanditsKilled++;

            if (currentBanditsKilled >= BanditsToKill)
            {
                ChangeQuestState(QuestState.HelpGord);
            }

            UpdateQuestProgressText();
        }
    }

    public void HelpGord()
    {
        if (questState == QuestState.HelpGord)
        {
            // Implement functionality for helping Gord
            // For example, loading the next level or showing a completion message
            // You can add your logic here
        }
    }

    void UpdateQuestProgressText()
    {
        switch (questState)
        {
            case QuestState.EnterVillage:
                questProgressText.text = "Enter the Village of Danesti";
                break;
            case QuestState.SpeakWithElder:
                questProgressText.text = "Go to the north of town to speak with the town's Elder";
                break;
            case QuestState.FindGorm:
                questProgressText.text = "Find and Talk to Gorm in the southeast part of the village";
                break;
            case QuestState.HelpGordFindStaff:
                questProgressText.text = "Help Gord Find His Staff in the village";
                break;
            case QuestState.BringStaffToGorm:
                questProgressText.text = "Bring the Staff to Gorm";
                break;
            case QuestState.GoToNorthEast:
                questProgressText.text = "Go to the Northeast of the village";
                break;
            case QuestState.DefeatTheBandits:
                questProgressText.text = "Defeat the Bandits " + currentBanditsKilled + " / " + BanditsToKill; ;
                break;
            case QuestState.HelpGord:
                questProgressText.text = "Help Gord";
                break;
        }
    }

    void ChangeQuestState(QuestState newState)
    {
        questState = newState;
        UpdateQuestProgressText();
        // Activate corresponding objects as quests are completed
        switch (questState)
        {
            case QuestState.SpeakWithElder:
                if (objectToShow1 != null)
                    objectToShow1.SetActive(true);
                break;
            case QuestState.FindGorm:
                if (objectToShow2 != null)
                    objectToShow2.SetActive(true);
                break;
            case QuestState.HelpGordFindStaff:
                if (objectToShow3 != null)
                    objectToShow3.SetActive(true);
                break;
            case QuestState.BringStaffToGorm:
                if (objectToShow4 != null)
                    objectToShow4.SetActive(true);
                break;
            case QuestState.GoToNorthEast:
                if (objectToShow5 != null)
                    objectToShow5.SetActive(true);
                break;
            case QuestState.DefeatTheBandits:
                if (objectToShow6 != null)
                    objectToShow6.SetActive(true);
                break;
        }
    }

    // Implement additional methods for loading the next level, handling checkpoints, etc.
}
