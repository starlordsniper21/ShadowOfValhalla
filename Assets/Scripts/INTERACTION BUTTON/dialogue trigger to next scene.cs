using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueTriggertonextscene : MonoBehaviour
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
    public string nextSceneName; // Name of the next scene to load.
    public CanvasGroup fadeOutCanvas;

    private int currentDialogueIndex = 0;
    private bool dialogueActive = false;

    private void Start()
    {
        dialogueBox.SetActive(false);
        fadeOutCanvas.alpha = 0f; // Set initial alpha value to 0 (fully transparent).
        fadeOutCanvas.interactable = false;
        fadeOutCanvas.blocksRaycasts = false;
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
            StartCoroutine(FadeOutScene()); // Corrected method name.
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
            StartCoroutine(FadeOutScene());
        }
    }

    private IEnumerator FadeOutScene()
    {
        // Fade out the current scene.
        while (fadeOutCanvas.alpha < 1f)
        {
            fadeOutCanvas.alpha += Time.deltaTime;
            yield return null;
        }

        // Load the next scene using the specified scene name.
        SceneManager.LoadScene(nextSceneName);
    }

    private void SetCharacterNames(string nameA, string nameB)
    {
        characterNameTextA.text = nameA;
        characterNameTextB.text = nameB;
    }
}
