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
    public Image fadeImage; // Reference to the black image for fading.
    public string nextSceneName; // Name of the next scene to load.
    public float fadeDuration = 1.5f; // Duration of the fade effect.

    private int currentDialogueIndex = 0;
    private bool dialogueActive = false;

    private void Start()
    {
        dialogueBox.SetActive(false);
        fadeImage.enabled = false; // Hide the fade image at the start.
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
            ShowNextDialogue();
        }
        else
        {
            ZeroText();
            StartCoroutine(FadeToBlackAndLoadScene()); // Start the fade-out effect and load the scene.
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
            StartCoroutine(FadeToBlackAndLoadScene()); // Start the fade-out effect and load the scene.
        }
    }

    private IEnumerator FadeToBlackAndLoadScene()
    {
        fadeImage.enabled = true; // Show the fade image.

        float elapsedTime = 0f;
        Color startColor = fadeImage.color;
        Color targetColor = new Color(0f, 0f, 0f, 1f); // Fully opaque black.

        while (elapsedTime < fadeDuration)
        {
            fadeImage.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = targetColor; // Ensure the image is fully black.

        // Wait for a short duration before loading the next scene (you can adjust this duration as needed).
        yield return new WaitForSeconds(0.5f);

        // Load the next scene using the specified scene name.
        SceneManager.LoadScene(nextSceneName);
    }

    private void SetCharacterNames(string nameA, string nameB)
    {
        characterNameTextA.text = nameA;
        characterNameTextB.text = nameB;
    }
}
