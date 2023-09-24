using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private QuestManager questManager;

    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnDestroy()
    {
        // Call this when the enemy is defeated.
        questManager.EnemyKilled();
    }
}
