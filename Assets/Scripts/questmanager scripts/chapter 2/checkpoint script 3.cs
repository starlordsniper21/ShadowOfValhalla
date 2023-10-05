using UnityEngine;

public class QuestTrigger3 : MonoBehaviour
{
    private QuestManager2 questManager2;

    private void Start()
    {
        questManager2 = FindObjectOfType<QuestManager2>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Trigger the "Find Another Way" quest.
            questManager2.InitiateFindAnotherWayQuest();

            // Disable the trigger so it doesn't initiate the quest repeatedly.
            gameObject.SetActive(false);
        }
    }
}
