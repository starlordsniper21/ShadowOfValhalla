using UnityEngine;

public class QuestTrigger3_1 : MonoBehaviour
{
    private QuestManager3 questManager3;

    private void Start()
    {
        questManager3 = FindObjectOfType<QuestManager3>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // trigger keep exploring dungeon
            questManager3.InitiateExploreDungeonQuest();

            // Disable the trigger so it doesn't initiate the quest repeatedly.
            gameObject.SetActive(false);
        }
    }
}
