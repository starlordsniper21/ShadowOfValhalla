using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestManager5 : MonoBehaviour
{
    public int batstokill1 = 5;
    public int batskilled1 = 0;
    public int batstokill2 = 5;
    public int batskilled2 = 0;
    public int batstokill3 = 5;
    public int batskilled3 = 0;
    public int DefeatBoss = 1;
    public int bossdefeated = 0;
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
    public GameObject objectToShow11;
    public GameObject objectToDestroy1; // Object to destroy after FollowTheEastPathway
    public GameObject objectToDestroy2; // Object to destroy after FollowThePathway
    public GameObject objectToShowAfterWarlock1; // Object to show after DEFEATEVILWARLOCK
    public GameObject objectToShowAfterWarlock2; // Object to show after DEFEATEVILWARLOCK
    public TextMeshProUGUI questProgressText;

    private enum QuestState { TravelThroughTheForest, DefeatTheBats1, ContinueThroughTheForest, DefeatBats2, ExamineTheBody, FindTheTravelersCamp, TalkToTheCampLeader, FollowTheEastPathway, DefeatBats3, FollowThePathway, DefeatEvilWarlock, HeadNorth }
    private QuestState questState = QuestState.TravelThroughTheForest;

    private void Start()
    {
        UpdateQuestProgressText();
        HideAllObjects();
    }

    private void HideAllObjects()
    {
        if (firstquest != null)
            firstquest.SetActive(true);
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
        if (objectToShow7 != null)
            objectToShow7.SetActive(false);
        if (objectToShow8 != null)
            objectToShow8.SetActive(false);
        if (objectToShow9 != null)
            objectToShow9.SetActive(false);
        if (objectToShow10 != null)
            objectToShow10.SetActive(false);
        if (objectToShow11 != null)
            objectToShow11.SetActive(false);
        if (objectToShowAfterWarlock1 != null)
            objectToShowAfterWarlock1.SetActive(false);
        if (objectToShowAfterWarlock2 != null)
            objectToShowAfterWarlock2.SetActive(false);
    }

    public void InitiateTravelThroughTheForestQuest()
    {
        if (questState == QuestState.TravelThroughTheForest)
        {
            ChangeQuestState(QuestState.DefeatTheBats1);
        }
    }

    public void DefeatTheBats1()
    {
        if (questState == QuestState.DefeatTheBats1)
        {
            batskilled1++;

            if (batskilled1 >= batstokill1)
            {
                ChangeQuestState(QuestState.ContinueThroughTheForest);
            }

            UpdateQuestProgressText();
        }
    }

    public void ContinueThroughTheForest()
    {
        if (questState == QuestState.ContinueThroughTheForest)
        {
            ChangeQuestState(QuestState.DefeatBats2);
        }
    }

    public void DefeatBats2()
    {
        if (questState == QuestState.DefeatBats2)
        {
            batskilled2++;

            if (batskilled2 >= batstokill2)
            {
                ChangeQuestState(QuestState.ExamineTheBody);
            }

            UpdateQuestProgressText();
        }
    }

    public void ExamineTheBody()
    {
        if (questState == QuestState.ExamineTheBody)
        {
            ChangeQuestState(QuestState.FindTheTravelersCamp);
        }
    }

    public void FindTheTravelersCamp()
    {
        if (questState == QuestState.FindTheTravelersCamp)
        {
            ChangeQuestState(QuestState.TalkToTheCampLeader);
        }
    }

    public void TalkToTheCampLeader()
    {
        if (questState == QuestState.TalkToTheCampLeader)
        {
            ChangeQuestState(QuestState.FollowTheEastPathway);
        }
    }

    public void FollowTheEastPathway()
    {
        if (questState == QuestState.FollowTheEastPathway)
        {
            ChangeQuestState(QuestState.DefeatBats3);
        }
    }

    public void DefeatBats3()
    {
        if (questState == QuestState.DefeatBats3)
        {
            batskilled3++;

            if (batskilled3 >= batstokill3)
            {
                ChangeQuestState(QuestState.FollowThePathway);
            }

            UpdateQuestProgressText();
        }
    }

    public void FollowThePathway()
    {
        if (questState == QuestState.FollowThePathway)
        {
            ChangeQuestState(QuestState.DefeatEvilWarlock);
        }
    }

    public void DefeatEvilWarlock()
    {
        if (questState == QuestState.DefeatEvilWarlock)
        {
            bossdefeated++;

            if (bossdefeated >= DefeatBoss)
            {
                ChangeQuestState(QuestState.HeadNorth);
            }

            UpdateQuestProgressText();
        }
    }

    public void HeadNorth()
    {
        if (questState == QuestState.HeadNorth)
        {
            // Implement functionality for heading north
            // You can add your logic here
        }
    }

    void UpdateQuestProgressText()
    {
        switch (questState)
        {
            case QuestState.TravelThroughTheForest:
                questProgressText.text = "Travel Through the Forest";
                break;
            case QuestState.DefeatTheBats1:
                questProgressText.text = "Clear the swarm of Bats: " + batskilled1 + " / " + batstokill1;
                break;
            case QuestState.ContinueThroughTheForest:
                questProgressText.text = "Continue Through the Forest";
                break;
            case QuestState.DefeatBats2:
                questProgressText.text = "Clear the swarm of Bats: " + batskilled2 + " / " + batstokill2;
                break;
            case QuestState.ExamineTheBody:
                questProgressText.text = "Examine the body";
                break;
            case QuestState.FindTheTravelersCamp:
                questProgressText.text = "Find the Traveler's Camp";
                break;
            case QuestState.TalkToTheCampLeader:
                questProgressText.text = "Talk To the camp leader";
                break;
            case QuestState.FollowTheEastPathway:
                questProgressText.text = "Follow the East Pathway";
                break;
            case QuestState.DefeatBats3:
                questProgressText.text = "Clear the swarm of Bats: " + batskilled3 + " / " + batstokill3;
                break;
            case QuestState.FollowThePathway:
                questProgressText.text = "Follow the pathway";
                break;
            case QuestState.DefeatEvilWarlock:
                questProgressText.text = "Defeat Evil Warlock ";
                break;
            case QuestState.HeadNorth:
                questProgressText.text = "Head NORTH";
                break;
        }
    }

    void ChangeQuestState(QuestState newState)
    {
        questState = newState;
        UpdateQuestProgressText();

        // Deactivate firstquest if it's not needed anymore
        if (firstquest != null)
            firstquest.SetActive(false);

        // Destroy objectToDestroy1 after FollowTheEastPathway quest
        if (questState == QuestState.FollowTheEastPathway && objectToDestroy1 != null)
            Destroy(objectToDestroy1);

        // Destroy objectToDestroy2 after FollowThePathway quest
        if (questState == QuestState.FollowThePathway && objectToDestroy2 != null)
            Destroy(objectToDestroy2);

        // Activate objectsToShowAfterWarlock1 and objectToShowAfterWarlock2 after defeating the evil warlock
        if (questState == QuestState.HeadNorth)
        {
            if (objectToShowAfterWarlock1 != null)
                objectToShowAfterWarlock1.SetActive(true);
            if (objectToShowAfterWarlock2 != null)
                objectToShowAfterWarlock2.SetActive(true);
        }

        switch (questState)
        {
            case QuestState.TravelThroughTheForest:
                if (firstquest != null)
                    firstquest.SetActive(true);
                break;
            case QuestState.DefeatTheBats1:
                if (objectToShow1 != null)
                    objectToShow1.SetActive(true);
                break;
            case QuestState.ContinueThroughTheForest:
                if (objectToShow2 != null)
                    objectToShow2.SetActive(true);
                break;
            case QuestState.DefeatBats2:
                if (objectToShow3 != null)
                    objectToShow3.SetActive(true);
                break;
            case QuestState.ExamineTheBody:
                if (objectToShow4 != null)
                    objectToShow4.SetActive(true);
                break;
            case QuestState.FindTheTravelersCamp:
                if (objectToShow5 != null)
                    objectToShow5.SetActive(true);
                break;
            case QuestState.TalkToTheCampLeader:
                if (objectToShow6 != null)
                    objectToShow6.SetActive(true);
                break;
            case QuestState.FollowTheEastPathway:
                if (objectToShow7 != null)
                    objectToShow7.SetActive(true);
                break;
            case QuestState.DefeatBats3:
                if (objectToShow8 != null)
                    objectToShow8.SetActive(true);
                break;
            case QuestState.FollowThePathway:
                if (objectToShow9 != null)
                    objectToShow9.SetActive(true);
                break;
            case QuestState.DefeatEvilWarlock:
                if (objectToShow10 != null)
                    objectToShow10.SetActive(true);
                break;
            case QuestState.HeadNorth:
                if (objectToShow11 != null)
                    objectToShow11.SetActive(true);
                break;
        }
    }
}
