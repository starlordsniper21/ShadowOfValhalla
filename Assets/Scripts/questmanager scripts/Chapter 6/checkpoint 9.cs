using UnityEngine;

public class QuestTrigger6_9 : MonoBehaviour
{
    private QuestManager6 questManager6;

    private void Start()
    {
        questManager6 = FindObjectOfType<QuestManager6>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // trigger keep exploring dungeon
            questManager6.GetOutOfTheDungeonAgain();

            // Disable the trigger so it doesn't initiate the quest repeatedly.
            gameObject.SetActive(false);
        }
    }
}
