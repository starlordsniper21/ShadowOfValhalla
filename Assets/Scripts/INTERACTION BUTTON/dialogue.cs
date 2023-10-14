using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject DialogueBox;
    public Text DialogueText;
    public Text CharacterNameTextA;
    public Text CharacterNameTextB;
    public string[] characterNamesA;
    public string[] characterNamesB;
    public string[] characterDialogues;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;

    private bool isDialogueActive = false;
    private bool isTyping = false;

    private float originalTimeScale;
    private Button interactionButton;
    public Button nextButton;
    public Canvas backgroundCanvas;

    private void Start()
    {
        originalTimeScale = Time.timeScale;

        interactionButton = GameObject.Find("interaction button").GetComponent<Button>();

        if (interactionButton != null)
        {
            interactionButton.onClick.AddListener(OnMobileButtonClick);
        }

        if (nextButton != null)
        {
            nextButton.onClick.AddListener(NextLine);
            nextButton.gameObject.SetActive(false);
        }
    }

    private void OnMobileButtonClick()
    {
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
            backgroundCanvas.enabled = false;
            StartCoroutine(Typing());
            Time.timeScale = 0;
        }
        else
        {
            ZeroText();
            Time.timeScale = originalTimeScale;
            ShowBackgroundCanvas();
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

        SetCharacterNameText(characterNamesA[index], characterNamesB[index]);

        string currentDialogue = characterDialogues[index];

        foreach (char letter in currentDialogue.ToCharArray())
        {
            DialogueText.text += letter;
            yield return new WaitForSecondsRealtime(wordSpeed);
        }
        isTyping = false;

        if (nextButton != null)
        {
            nextButton.gameObject.SetActive(true);
        }
    }

    public void NextLine()
    {
        if (!isTyping)
        {
            if (index < characterDialogues.Length - 1)
            {
                index++;
                DialogueText.text = "";
                StartCoroutine(Typing());
            }
            else
            {
                ZeroText();
                Time.timeScale = originalTimeScale;
                ShowBackgroundCanvas();
                ToggleDialogue();
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

    public void ShowBackgroundCanvas()
    {
        backgroundCanvas.enabled = true;
    }

    private void SetCharacterNameText(string nameA, string nameB)
    {
        CharacterNameTextA.text = nameA;
        CharacterNameTextB.text = nameB;
    }
}
