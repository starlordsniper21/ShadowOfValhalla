using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject DialogueBox;
    public Text DialogueText;
    public string[] dialogue;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;

    private bool isDialogueActive = false;
    private bool isTyping = false;

    private float originalTimeScale; // Store the original time scale.
    private Button interactionButton;
    public Button nextButton; // Reference to the "Next" button

    private void Start()
    {
        originalTimeScale = Time.timeScale; // Store the original time scale at the start.

        // Find the mobile interaction button in the scene
        interactionButton = GameObject.Find("interaction button").GetComponent<Button>();

        // Register a callback for the button click event
        if (interactionButton != null)
        {
            interactionButton.onClick.AddListener(OnMobileButtonClick);
        }

        // Register a callback for the "Next" button click event
        if (nextButton != null)
        {
            nextButton.onClick.AddListener(NextLine);
            nextButton.gameObject.SetActive(false); // Hide the "Next" button initially.
        }
    }

    private void OnMobileButtonClick()
    {
        // Check for mobile button press
        if (playerIsClose && !isDialogueActive)
        {
            StartDialogue();
        }
    }

    public void ToggleDialogue()
    {
        isDialogueActive = !isDialogueActive;
        if (isDialogueActive)
        {
            DialogueBox.SetActive(true);
            StartCoroutine(Typing());
            Time.timeScale = 0; // Pause the game when dialogue starts.
            if (nextButton != null)
            {
                nextButton.gameObject.SetActive(false); // Hide the "Next" button initially.
            }
        }
        else
        {
            ZeroText();
            Time.timeScale = originalTimeScale; // Resume the game when dialogue ends.
        }
    }

    public void ZeroText()
    {
        DialogueText.text = "";
        index = 0;
        DialogueBox.SetActive(false);
    }

    IEnumerator Typing()
    {
        isTyping = true;
        foreach (char letter in dialogue[index].ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSecondsRealtime(wordSpeed); // Use WaitForSecondsRealtime to pause time scale-independent.
        }
        isTyping = false;

        if (nextButton != null)
        {
            nextButton.gameObject.SetActive(true); // Show the "Next" button after text is fully displayed.
        }
    }

    public void NextLine()
    {
        if (!isTyping)
        {
            if (index < dialogue.Length - 1)
            {
                index++;
                DialogueText.text = "";
                StartCoroutine(Typing());
            }
            else
            {
                ZeroText();
                Time.timeScale = originalTimeScale;
                if (nextButton != null)
                {
                    nextButton.gameObject.SetActive(false); // Hide the "Next" button when all dialogue is complete.
                }
            }
        }
    }

    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }

    public void StartDialogue()
    {
        if (!isDialogueActive)
        {
            ToggleDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ZeroText();
            playerIsClose = false;
        }
    }
}
