using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public string[] dialogues;
    public string[] characterNameArrayA;
    public string[] characterNameArrayB;
    public Text characterNameTextA;
    public Text characterNameTextB;
    public Button nextButton;
    public Canvas backgroundCanvas;

    private int currentDialogueIndex = 0;
    private bool dialogueActive = false;

    private void Start()
    {
        dialogueBox.SetActive(false);
        nextButton.onClick.AddListener(ShowNextDialogue);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !dialogueActive)
        {
            ToggleDialogue();
        }
    }

    public void ToggleDialogue()
    {
        dialogueActive = !dialogueActive;
        if (dialogueActive)
        {
            dialogueBox.SetActive(true);
            backgroundCanvas.enabled = false;
            ShowNextDialogue();
            Time.timeScale = 0;
        }
        else
        {
            ZeroText();
            Time.timeScale = 1;
            ShowBackgroundCanvas();
            Destroy(gameObject); // Destroy the object when dialogue finishes.
        }
    }

    private void ZeroText()
    {
        dialogueText.text = "";
        currentDialogueIndex = 0;
        dialogueBox.SetActive(false);
    }

    private void ShowNextDialogue()
    {
        if (currentDialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[currentDialogueIndex];
            SetCharacterNames(characterNameArrayA[currentDialogueIndex], characterNameArrayB[currentDialogueIndex]);
            currentDialogueIndex++;
        }
        else
        {
            ZeroText();
            Time.timeScale = 1;
            ShowBackgroundCanvas();
            Destroy(gameObject); // Destroy the object when dialogue finishes.
        }
    }

    private void ShowBackgroundCanvas()
    {
        backgroundCanvas.enabled = true;
    }

    private void SetCharacterNames(string nameA, string nameB)
    {
        characterNameTextA.text = nameA;
        characterNameTextB.text = nameB;
    }
}
