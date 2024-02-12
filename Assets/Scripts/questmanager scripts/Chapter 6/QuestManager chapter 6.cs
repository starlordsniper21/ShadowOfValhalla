using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestManager6 : MonoBehaviour
{
    public int guardskilled = 0;
    public int guardstokill = 3;
    public int DefeatWarlock = 1;
    public int DefeatedWarlock = 0;
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
        FindAnotherWayInsideTheFortress,
        ExploreTheFortressDungeon,
        KillTheGuards,
        FindAtros,
        ExamineTheCells,
        FindRoomFullOfBlackPowder,
        FindLeverToOpenRoom,
        TalkToAtros,
        GetOutOfTheDungeon,
        DefeatEnemyWarlock,
        GetOutOfTheDungeonAgain
    }

    private QuestState questState = QuestState.FindAnotherWayInsideTheFortress;

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

    public void InitiateFindAnotherWayInsideTheFortressQuest()
    {
        if (questState == QuestState.FindAnotherWayInsideTheFortress)
        {
            ChangeQuestState(QuestState.ExploreTheFortressDungeon);
        }
    }

    public void ExploreTheFortressDungeon()
    {
        if (questState == QuestState.ExploreTheFortressDungeon)
        {
            ChangeQuestState(QuestState.KillTheGuards);
        }
    }

    public void KillTheGuards()
    {
        if (questState == QuestState.KillTheGuards)
        {
            guardskilled++;

            if (guardskilled >= guardstokill)
            {
                ChangeQuestState(QuestState.FindAtros);
            }

            UpdateQuestProgressText();
        }
    }

    public void FindAtros()
    {
        if (questState == QuestState.FindAtros)
        {

            ChangeQuestState(QuestState.ExamineTheCells);
        }
    }

    public void ExamineTheCells()
    {
        if (questState == QuestState.ExamineTheCells)
        {
            ChangeQuestState(QuestState.FindRoomFullOfBlackPowder);
        }
    }

    public void FindRoomFullOfBlackPowder()
    {
        if (questState == QuestState.FindRoomFullOfBlackPowder)
        {
            ChangeQuestState(QuestState.FindLeverToOpenRoom);
        }
    }

    public void FindLeverToOpenRoom()
    {
        if (questState == QuestState.FindLeverToOpenRoom)
        {
            ChangeQuestState(QuestState.TalkToAtros);
        }
    }

    public void TalkToAtros()
    {
        if (questState == QuestState.TalkToAtros)
        {
            ChangeQuestState(QuestState.GetOutOfTheDungeon);
        }
    }

    public void GetOutOfTheDungeon()
    {
        if (questState == QuestState.GetOutOfTheDungeon)
        {
            ChangeQuestState(QuestState.DefeatEnemyWarlock);
        }
    }

    public void DefeatEnemyWarlock()
    {
        if (questState == QuestState.DefeatEnemyWarlock)
        {
            DefeatedWarlock++;

            if (DefeatedWarlock >= DefeatWarlock)
            {
                ChangeQuestState(QuestState.GetOutOfTheDungeonAgain);
            }

            UpdateQuestProgressText();
        }
    }

    public void GetOutOfTheDungeonAgain()
    {
        if (questState == QuestState.GetOutOfTheDungeonAgain)
        {

        }
    }

    void UpdateQuestProgressText()
    {
        switch (questState)
        {
            case QuestState.FindAnotherWayInsideTheFortress:
                questProgressText.text = "Find another way inside the Fortress";
                break;
            case QuestState.ExploreTheFortressDungeon:
                questProgressText.text = "Explore the fortress Dungeon";
                break;
            case QuestState.KillTheGuards:
                questProgressText.text = "Kill The Guards" + guardskilled + " / " + guardstokill; ;
                break;
            case QuestState.FindAtros:
                questProgressText.text = "Find Atros";
                break;
            case QuestState.ExamineTheCells:
                questProgressText.text = "Examine the Cells";
                break;
            case QuestState.FindRoomFullOfBlackPowder:
                questProgressText.text = "Find the Room Full of black powder";
                break;
            case QuestState.FindLeverToOpenRoom:
                questProgressText.text = "Find the Lever that opens the Room";
                break;
            case QuestState.TalkToAtros:
                questProgressText.text = "Talk To Atros";
                break;
            case QuestState.GetOutOfTheDungeon:
                questProgressText.text = "Get out of the Dungeon";
                break;
            case QuestState.DefeatEnemyWarlock:
                questProgressText.text = "Defeat Enemy Warlock" + DefeatedWarlock + " / " + DefeatWarlock;
                break;
            case QuestState.GetOutOfTheDungeonAgain:
                questProgressText.text = "GET OUT OF THE DUNGEON!!";
                break;
        }
    }

    void ChangeQuestState(QuestState newState)
    {
        // Check if the new state is "FindAtros", if so, destroy the objectToDestroy
        if (newState == QuestState.FindAtros)
        {
            Destroy(objectToDestroy);
        }
        if (newState == QuestState.ExamineTheCells)
        {
            Destroy(objectToDestroy2);
        }

        if (newState == QuestState.TalkToAtros)
        {
            Destroy(objectToDestroy3);
        }
        questState = newState;
        UpdateQuestProgressText();

        if (newState == QuestState.GetOutOfTheDungeonAgain)
        {
            Destroy(objectToDestroy5);
        }
        questState = newState;
        UpdateQuestProgressText();

        // Deactivate firstquest if it's not needed anymore
        // Activate objects based on current quest state
        switch (questState)
        {
            case QuestState.FindAnotherWayInsideTheFortress:
                if (firstquest != null)
                    firstquest.SetActive(true);
                break;
            case QuestState.ExploreTheFortressDungeon:
                if (objectToShow1 != null)
                    objectToShow1.SetActive(true);
                break;
            case QuestState.KillTheGuards:
                if (objectToShow2 != null)
                    objectToShow2.SetActive(true);
                break;
            case QuestState.FindAtros:
                if (objectToShow3 != null)
                    objectToShow3.SetActive(true);
                break;
            case QuestState.ExamineTheCells:
                if (objectToShow4 != null)
                    objectToShow4.SetActive(true);
                break;
            case QuestState.FindRoomFullOfBlackPowder:
                if (objectToShow5 != null)
                    objectToShow5.SetActive(true);
                break;
            case QuestState.FindLeverToOpenRoom:
                if (objectToShow6 != null)
                    objectToShow6.SetActive(true);
                break;
            case QuestState.TalkToAtros:
                if (objectToShow7 != null)
                    objectToShow7.SetActive(true);
                break;
            case QuestState.GetOutOfTheDungeon:
                if (objectToShow8 != null)
                    objectToShow8.SetActive(true);
                break;
            case QuestState.DefeatEnemyWarlock:
                if (objectToShow9 != null)
                    objectToShow9.SetActive(true);
                break;
            case QuestState.GetOutOfTheDungeonAgain:
                if (objectToShow10 != null)
                    objectToShow10.SetActive(true);
                break;
        }
    }

}