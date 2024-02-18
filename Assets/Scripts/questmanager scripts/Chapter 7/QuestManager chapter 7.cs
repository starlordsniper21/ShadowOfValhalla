using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestManager7 : MonoBehaviour
{
    public int eastgeneralkilled = 0;
    public int eastgeneraltokill = 1;
    public int westgeneralkilled = 0;
    public int westgeneraltokill= 1;
    public int northgeneralskilled = 0;
    public int northgeneralstokill = 2;
    public GameObject firstquest;
    public GameObject objectToShow1;
    public GameObject objectToShow2;
    public GameObject objectToShow3;
    public GameObject objectToShow4;
    public GameObject objectToShow5;
    public GameObject objectToShow6;
    public GameObject objectToShow7;
    public GameObject objectToShow8;
    public GameObject objectToShow9;
    public GameObject objectToShow10;
    public GameObject objectToDestroy;
    public GameObject objectToDestroy2;
    public GameObject objectToDestroy3;
    public GameObject objectToDestroy4;
    public GameObject objectToDestroy5;


    public TextMeshProUGUI questProgressText;

    private enum QuestState
    {
        FindCanute,
        GoToEastSide,
        DefeatEastSideGeneral,
        GoToWestSide,
        DefeatWestSideGeneral,
        GoToNorthSide,
        DefeatTwinGeneral,
        ConfrontCanute
    }

    private QuestState questState = QuestState.FindCanute;

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
        if (objectToShow6 != null) objectToShow6.SetActive(false);
        if (objectToShow7 != null) objectToShow7.SetActive(false);
        if (objectToShow8 != null) objectToShow8.SetActive(false);
        if (objectToShow9 != null) objectToShow9.SetActive(false);
        if (objectToShow10 != null) objectToShow10.SetActive(false);
    }

    public void InitiateFindCanuteQuest()
    {
        if (questState == QuestState.FindCanute)
        {
            ChangeQuestState(QuestState.GoToEastSide);
        }
    }

    public void GoToEastSide()
    {
        if (questState == QuestState.GoToEastSide)
        {
            ChangeQuestState(QuestState.DefeatEastSideGeneral);
        }
    }

    public void DefeatEastSideGeneral()
    {
        if (questState == QuestState.DefeatEastSideGeneral)
        {
            eastgeneralkilled++;

            if (eastgeneralkilled >=eastgeneraltokill)
            {
                ChangeQuestState(QuestState.GoToWestSide);
            }

            UpdateQuestProgressText();
        }
    }

    public void GoToWestSide()
    {
        if (questState == QuestState.GoToWestSide)
        {

            ChangeQuestState(QuestState.DefeatWestSideGeneral);
        }
    }

    public void DefeatWestSideGeneral()
    {
        if (questState == QuestState.DefeatWestSideGeneral)
        {
            {
                westgeneralkilled++;

                if (westgeneralkilled >= westgeneraltokill)
                {
                    ChangeQuestState(QuestState.GoToNorthSide);
                }

                UpdateQuestProgressText();
            }
        }
    }

    public void GoToNorthSide()
    {
        if (questState == QuestState.GoToNorthSide)
        {

            ChangeQuestState(QuestState.DefeatTwinGeneral);
        }
    }

    public void DefeatTwinGeneral()
    {
        if (questState == QuestState.DefeatTwinGeneral)

            northgeneralskilled++;

        if (northgeneralskilled >= northgeneralstokill)
        {
            ChangeQuestState(QuestState.ConfrontCanute);
        }

        UpdateQuestProgressText();
    }

    public void ConfrontCanute()
    {
    }



  

    void UpdateQuestProgressText()
    {
        switch (questState)
        {
            case QuestState.FindCanute:
                questProgressText.text = "Find Canute";
                break;
            case QuestState.GoToEastSide:
                questProgressText.text = "Go to the East Side of the Fortress";
                break;
            case QuestState.DefeatEastSideGeneral:
                questProgressText.text = "Defeat the East Side General" + eastgeneralkilled + " / " + eastgeneraltokill; ;
                break;
            case QuestState.GoToWestSide:
                questProgressText.text = "Go to the West Side of the Fortress";
                break;
            case QuestState.DefeatWestSideGeneral:
                questProgressText.text = "Defeat the West Side General" + westgeneralkilled + "/" + westgeneraltokill;
                break;
            case QuestState.GoToNorthSide:
                questProgressText.text = "Go to the North Side of the Fortress";
                break;
            case QuestState.DefeatTwinGeneral:
                questProgressText.text = "Defeat the Twin General" + northgeneralskilled + "/" + northgeneralstokill;
                break;
            case QuestState.ConfrontCanute:
                questProgressText.text = "Confront Canute";
                break;
            
        }
    }

    void ChangeQuestState(QuestState newState)
    {
        // Check if the new state is "FindCanute", if so, destroy the objectToDestroy
        if (newState == QuestState.FindCanute)
        {
            Destroy(objectToDestroy);
        }
        questState = newState;
        UpdateQuestProgressText();

        // Deactivate firstquest if it's not needed anymore
        // Activate objects based on current quest state
        switch (questState)
        {
            case QuestState.FindCanute:
                if (firstquest != null)
                    firstquest.SetActive(true);
                break;
            case QuestState.GoToEastSide:
                if (objectToShow1 != null)
                    objectToShow1.SetActive(true);
                break;
            case QuestState.DefeatEastSideGeneral:
                if (objectToShow2 != null)
                    objectToShow2.SetActive(true);
                break;
            case QuestState.GoToWestSide:
                if (objectToShow3 != null)
                    objectToShow3.SetActive(true);
                break;
            case QuestState.DefeatWestSideGeneral:
                if (objectToShow4 != null)
                    objectToShow4.SetActive(true);
                break;
            case QuestState.GoToNorthSide:
                if (objectToShow5 != null)
                    objectToShow5.SetActive(true);
                break;
            case QuestState.DefeatTwinGeneral:
                if (objectToShow6 != null)
                    objectToShow6.SetActive(true);
                break;
            case QuestState.ConfrontCanute:
                if (objectToShow7 != null)
                    objectToShow7.SetActive(true);
                break;
          
        }
    }

}
