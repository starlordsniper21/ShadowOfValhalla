using UnityEngine;

public class QuestTriggerchapter1_2 : MonoBehaviour
{
    private QuestManager questManager;
    //enter akumajo castle
    private void Start()
    {
        questManager = FindObjectOfType<QuestManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            questManager.DefeatTheGuards();


            gameObject.SetActive(false);
        }
    }
}
