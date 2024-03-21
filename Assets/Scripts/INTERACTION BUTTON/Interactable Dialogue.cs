using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InteractableDialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public string[] dialogues;
    public string[] characterNameArrayA;
    public string[] characterNameArrayB;
    public Text characterNameTextA;
    public Text characterNameTextB;
    public Button nextButton;
    public Button skipButton; // Added skip button
    public Canvas backgroundCanvas;
    public Button dialogueButton; // Add a reference to the UI button

    private int currentDialogueIndex = 0;
    private bool dialogueActive = false;
    private bool playerInRange = false;

    private void Start()
    {
        dialogueBox.SetActive(false);
        nextButton.onClick.AddListener(ShowNextDialogue);

        // Initialize skip button
        if (skipButton != null)
        {
            skipButton.onClick.AddListener(SkipDialogue);
        }

        // Add listener to the dialogue button
        if (dialogueButton != null)
        {
            dialogueButton.onClick.AddListener(ToggleDialogue);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    public void ToggleDialogue()
    {
        if (playerInRange) // Check if the player is in range
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
                dialogueBox.SetActive(false);
                Time.timeScale = 1;
                ShowBackgroundCanvas();
            }
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

    private void SkipDialogue()
    {
        ZeroText();
        Time.timeScale = 1;
        ShowBackgroundCanvas();
    }
}
