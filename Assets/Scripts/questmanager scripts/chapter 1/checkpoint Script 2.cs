using UnityEngine;

public class QuestTriggerchapter1_1 : MonoBehaviour
{
    private QuestManager questManager;
    //travel to  akumajo castle
    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           
            questManager.EntertheakumajoCastle();
          
            gameObject.SetActive(false);
        }
    }
}
