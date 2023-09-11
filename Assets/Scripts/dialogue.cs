using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;

    private bool isDialogueActive = false;
    private bool isTyping = false;

    private float originalTimeScale; // Store the original time scale.

    private void Start()
    {
        originalTimeScale = Time.timeScale; // Store the original time scale at the start.
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (isDialogueActive)
            {
                NextLine();
            }
            else
            {
                ToggleDialogue();
            }
        }
    }

    public void ToggleDialogue()
    {
        isDialogueActive = !isDialogueActive;
        if (isDialogueActive)
        {
            dialogueBox.SetActive(true);
            StartCoroutine(Typing());
            Time.timeScale = 0; // Pause the game when dialogue starts.
        }
        else
        {
            ZeroText();
            Time.timeScale = originalTimeScale; // Resume the game when dialogue ends.
        }
    }

    public void ZeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialogueBox.SetActive(false);
    }

    IEnumerator Typing()
    {
        isTyping = true;
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(wordSpeed); // Use WaitForSecondsRealtime to pause time scale-independent.
        }
        isTyping = false;
    }

    public void NextLine()
    {
        if (!isTyping) // Only proceed if the text is not currently typing.
        {
            if (index < dialogue.Length - 1)
            {
                index++;
                dialogueText.text = "";
                StartCoroutine(Typing());
            }
            else
            {
                ZeroText();
                Time.timeScale = originalTimeScale; // Resume the game when dialogue ends.
            }
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
