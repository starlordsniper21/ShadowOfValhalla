using UnityEngine;

public class QuestTrigger1 : MonoBehaviour
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
            // Trigger the "Go to Main Hall" quest.
            questManager2.InitiateExploreCastleQuest();

            // Disable the trigger so it doesn't initiate the quest repeatedly.
            gameObject.SetActive(false);
        }
    }
}
