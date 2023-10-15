using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    private QuestManager questManager;
    //investigate village
    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          
            questManager.InitiateInvestigateVillageQuest();
            
            gameObject.SetActive(false);
        }
    }
}
