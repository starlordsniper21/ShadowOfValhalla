using UnityEngine;

public class QuestTrigger4_1 : MonoBehaviour
{
    private QuestManager4 questManager4;

    private void Start()
    {
        questManager4 = FindObjectOfType<QuestManager4>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // trigger keep exploring dungeon
            questManager4.InitiateEnterVillageQuest();

            // Disable the trigger so it doesn't initiate the quest repeatedly.
            gameObject.SetActive(false);
        }
    }
}
