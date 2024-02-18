using UnityEngine;

public class QuestTrigger7_1 : MonoBehaviour
{
    private QuestManager7 questManager7;

    private void Start()
    {
        questManager7 = FindObjectOfType<QuestManager7>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // trigger keep exploring dungeon
            questManager7.InitiateFindCanuteQuest();

            // Disable the trigger so it doesn't initiate the quest repeatedly.
            gameObject.SetActive(false);
        }
    }
}
