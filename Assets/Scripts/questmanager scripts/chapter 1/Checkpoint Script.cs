using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    private QuestManager questManager;

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Trigger the "Investigate the Village" quest.
            questManager.InitiateInvestigateVillageQuest();
            // Disable the trigger so it doesn't initiate the quest repeatedly.
            gameObject.SetActive(false);
        }
    }
}
