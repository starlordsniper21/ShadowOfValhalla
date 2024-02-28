using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestManager7boss : MonoBehaviour
{
    public int CANUTEKilled = 0;
    public int CANUTEToKill = 1;
    public int CANUTEKilled2 = 0;
    public int CanuteToKill2 = 1;
    public GameObject firstquest;
    public GameObject objectToShow1;
    public GameObject objectToShow2;
    public GameObject objectToShow3;
    public GameObject objectToShow4;
    public GameObject objectToShow5;

    public GameObject objectToDestroy;
    public GameObject objectToDestroy2;


    public TextMeshProUGUI questProgressText;

    private enum QuestState
    {
        ConfrontCanute,
        DefeatCanute,
        ApproachCanute,
        DefeatCanuteGodForm,
        ApproachCanuteAgain,
        FinishCanute,
        GameOver,
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
        if (objectToShow4 != null) objectToShow4.SetActive(false);
        if (objectToShow5 != null) objectToShow5.SetActive(false);
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
                ChangeQuestState(QuestState.ApproachCanute);
            }

            UpdateQuestProgressText();
        }
    }

    public void ApproachCanute()
    {
        if (questState == QuestState.ApproachCanute)
        {
            ChangeQuestState(QuestState.DefeatCanuteGodForm);
        }
    }

    public void DefeatCanuteGodForm()
    {
        if (questState == QuestState.DefeatCanuteGodForm)
        {
            CANUTEKilled2++;

            if (CANUTEKilled2 >= CanuteToKill2)
            {
                ChangeQuestState(QuestState.FinishCanute);
            }
            UpdateQuestProgressText();
        }
    }

    public void FinishCanute()
    {
        // Add actions to perform when Canute is defeated
    }

    void UpdateQuestProgressText()
    {
        switch (questState)
        {
            case QuestState.ConfrontCanute:
                questProgressText.text = "Confront Canute ";
                break;
            case QuestState.DefeatCanute:
                questProgressText.text = "DEFEAT CANUTE!";
                break;
            case QuestState.ApproachCanute:
                questProgressText.text = "Approach Canute";
                break;
            case QuestState.DefeatCanuteGodForm:
                questProgressText.text = "DEFEAT CANUTE GOD FORM!";
                break;
            case QuestState.FinishCanute:
                questProgressText.text = "Finish off Canute";
                break;
        }
    }

    void ChangeQuestState(QuestState newState)
    {
        // Check if the new state is "ApproachCanute", if so, destroy the objectToDestroy
        questState = newState;
        UpdateQuestProgressText();

        if (newState == QuestState.ApproachCanute)
        {
            // Add actions to perform when approaching Canute
        }

        switch (questState)
        {
            case QuestState.ConfrontCanute:
                if (objectToShow1 != null)
                    objectToShow1.SetActive(true);
                break;
            case QuestState.DefeatCanute:
                if (objectToShow2 != null)
                    objectToShow2.SetActive(true);
                break;
            case QuestState.ApproachCanute:
                if (objectToShow3 != null)
                    objectToShow3.SetActive(true);
                break;
            case QuestState.DefeatCanuteGodForm:
                if (objectToShow4 != null)
                    objectToShow4.SetActive(true);
                break;
                case QuestState.FinishCanute:
                if (objectToShow5 != null)
                    objectToShow5.SetActive(true);
                break;



        }
    }
}
