using UnityEngine;

public class QuestTrigger7_2boss : MonoBehaviour
{
    private QuestManager7boss questManager7boss;

    private void Start()
    {
        questManager7boss = FindObjectOfType<QuestManager7boss>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // trigger keep exploring dungeon
            questManager7boss.FinishCanute();

            // Disable the trigger so it doesn't initiate the quest repeatedly.
            gameObject.SetActive(false);
        }
    }
}
