using UnityEngine;

public class QuestTrigger1boss: MonoBehaviour
{
    private QuestManager1boss questManager1boss;
    //investigate village
    private void Start()
    {
        questManager1boss = FindObjectOfType<QuestManager1boss>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          
            questManager1boss.InitiateConfrontCanuteQuest();
            
            gameObject.SetActive(false);
        }
    }
}
