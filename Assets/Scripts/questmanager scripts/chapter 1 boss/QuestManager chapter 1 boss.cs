using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestManager1boss : MonoBehaviour
{
    public int BOSSKILLED = 0;
    public int BossToKill = 1;
    public GameObject firstquest;
    public GameObject objectToShow1;
    public GameObject objectToShow2;
    public GameObject objectToDestroy;
    public GameObject objectToDestroy2;
    public GameObject objectToShow3;
    public GameObject objectToShow4;

    public TextMeshProUGUI questProgressText;

    private enum QuestState
    {
       GoInSidetheCastle,
       DefeatBoss,
       EnterCastle,
    }

    private QuestState questState = QuestState.GoInSidetheCastle;

    private void Start()
    {
        UpdateQuestProgressText();
        HideAllObjects();
    }

    private void HideAllObjects()
    {
        // Deactivate all objects
        if (firstquest != null) firstquest.SetActive(false);
        if (objectToShow1 != null) objectToShow1.SetActive(false);
        if (objectToShow2 != null) objectToShow2.SetActive(false);
        if (objectToShow3 != null) objectToShow3.SetActive(false);
        if (objectToShow4 != null) objectToShow4.SetActive(false);
    }

    public void InitiateConfrontCanuteQuest()
    {
        if (questState == QuestState.GoInSidetheCastle)
        {
            ChangeQuestState(QuestState.DefeatBoss);
        }
    }

    public void DefeatCanute()
    {
        if (questState == QuestState.DefeatBoss)
        {
            BOSSKILLED++;

            if (BOSSKILLED >= BossToKill)
            {
                ChangeQuestState(QuestState.EnterCastle);
            }

            UpdateQuestProgressText();
        }
    }

    public void FinishCanute()
    {

    }


    void UpdateQuestProgressText()
    {
        switch (questState)
        {
            case QuestState.GoInSidetheCastle:
                questProgressText.text = "Go Inside The Castle";
                break;
            case QuestState.DefeatBoss:
                questProgressText.text = "DEFEAT GENERAL" + BOSSKILLED + "/" + BossToKill;
                break;
            case QuestState.EnterCastle:
                questProgressText.text = "Enter the Castle";
                break;
        }
    }

    void ChangeQuestState(QuestState newState)
    {
        // Check if the new state is "FindCanute", if so, destroy the objectToDestroy
        questState = newState;
        UpdateQuestProgressText();

        {
        }
        if (newState == QuestState.GoInSidetheCastle)
        {
        }

        switch (questState)
        {
            case QuestState.GoInSidetheCastle:
                if (objectToShow1 != null)
                    objectToShow1.SetActive(true);
                break;
            case QuestState.DefeatBoss:
                if (objectToShow2 != null)
                    objectToShow2.SetActive(true);
                break;

            case QuestState.EnterCastle:
                if (objectToShow3 != null)
                    objectToShow3.SetActive(true);
                if (objectToShow4 != null)
                    objectToShow4.SetActive(true);
                break;
        }
    }
}
