using UnityEngine;
using TMPro;

public class QuestManagerTutorial : MonoBehaviour
{
    public int runesToCollect = 6;
    private int runesCollected = 0;

    public TextMeshProUGUI questNameText;

    void Start()
    {
        if (questNameText == null)
        {
            Debug.LogError("TextMeshProUGUI component not assigned to the QuestManager. Assign it in the Inspector.");
        }

        UpdateQuestNameText();
    }

    // Called when a collider enters the trigger zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Rune"))
        {
            CollectRune(other.gameObject);
        }
    }

    private void CollectRune(GameObject rune)
    {
        // Deactivate the rune (customize this based on your game logic)
        rune.SetActive(false);

        runesCollected++;

        if (runesCollected >= runesToCollect)
        {
            CompleteQuest();
        }

        UpdateQuestNameText();
    }

    private void CompleteQuest()
    {
        Debug.Log("Quest Completed! You collected all the runes.");
        // Trigger other events, rewards, etc. here
    }

    private void UpdateQuestNameText()
    {
        questNameText.text = "Collect all the runes: " + runesCollected + "/" + runesToCollect;
    }
}
