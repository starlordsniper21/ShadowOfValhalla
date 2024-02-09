using UnityEngine;

public class QuestTrigger5_3 : MonoBehaviour
{
    private QuestManager5 questManager5;

    private void Start()
    {
        questManager5 = FindObjectOfType<QuestManager5>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // trigger keep exploring dungeon
            questManager5.ExamineTheBody();

            // Disable the trigger so it doesn't initiate the quest repeatedly.
            gameObject.SetActive(false);
        }
    }
}
