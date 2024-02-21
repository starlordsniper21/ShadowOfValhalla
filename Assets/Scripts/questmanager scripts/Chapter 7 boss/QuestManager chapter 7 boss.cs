using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestManager7boss : MonoBehaviour
{
    public int CANUTEKilled = 0;
    public int CANUTEToKill = 1;
    public GameObject firstquest;
    public GameObject objectToShow1;
    public GameObject objectToShow2;
    public GameObject objectToDestroy;
    public GameObject objectToDestroy2;
    public GameObject objectToShow3;

    public TextMeshProUGUI questProgressText;

    private enum QuestState
    {
        ConfrontCanute,
        DefeatCanute, 
        FinishCanute,
        gameover,
    }

    private QuestState questState = QuestState.ConfrontCanute;

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
    }

    public void InitiateConfrontCanuteQuest()
    {
        if (questState == QuestState.ConfrontCanute)
        {
            ChangeQuestState(QuestState.DefeatCanute);
        }
    }

    public void DefeatCanute()
    {
        if (questState == QuestState.DefeatCanute)
        {
            CANUTEKilled++;

            if (CANUTEKilled >= CANUTEToKill)
            {
                ChangeQuestState(QuestState.FinishCanute);
            }

            UpdateQuestProgressText();
        }
    }

    public void FinishCanute()
    {
        if (questState == QuestState.FinishCanute)
        {
            ChangeQuestState(QuestState.gameover);
        }
    }

    public void gameover()
    {

    }    


    void UpdateQuestProgressText()
    {
        switch (questState)
        {
            case QuestState.ConfrontCanute:
                questProgressText.text = "Confront Canute ";
                break;
            case QuestState.DefeatCanute:
                questProgressText.text = "DEFEAT CANUTE!" +CANUTEKilled + "/" + CANUTEToKill;
                break;
            case QuestState.FinishCanute:
                questProgressText.text = " FINISH OFF CANUTE";
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
        if (newState == QuestState.ConfrontCanute)
        {
        }

        switch (questState)
        {
            case QuestState.ConfrontCanute:
                if (objectToShow1!= null)
                    objectToShow1.SetActive(true);
                break;
            case QuestState.DefeatCanute:
                if(objectToShow2!= null)
                    objectToShow2.SetActive(true);
                break;

            case QuestState.FinishCanute:
                if (objectToShow3 != null)
                    objectToShow3.SetActive(true);
                break;
        }
    }
}
