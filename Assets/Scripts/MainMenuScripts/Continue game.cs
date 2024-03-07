using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    public SceneController sceneController;
    public TimeManager timeManager;

    private Button continueButton;
    private Button newGameButton;
    private GameObject panel;
    private Button startCutsceneButton;

    private void Start()
    {
        continueButton = GetComponent<Button>();
        if (continueButton == null)
        {
            Debug.LogError("continue button not found");
            return;
        }

        continueButton.onClick.AddListener(OnContinueButtonClick);

        newGameButton = transform.parent.Find("NewGameButton")?.GetComponent<Button>();
        if (newGameButton == null)
        {
            Debug.LogError("NewGameButton not found");
            return;
        }

        newGameButton.onClick.AddListener(OnNewGameButtonClick);

        panel = transform.parent.Find("NewGamePanel")?.gameObject;
        if (panel == null)
        {
            Debug.LogError("NewGamePanel not found");
            return;
        }

        startCutsceneButton = panel.transform.Find("YES")?.GetComponent<Button>();
        if (startCutsceneButton == null)
        {
            Debug.LogError("No yes button");
            return;
        }

        startCutsceneButton.onClick.AddListener(OnStartCutsceneButtonClick);

        panel.SetActive(false);

        if (!PlayerPrefs.HasKey("LastSceneIndex"))
        {
            continueButton.gameObject.SetActive(false);
            Debug.LogWarning("No scene saved.");
        }
        else
        {
            continueButton.gameObject.SetActive(true);
        }
    }

    public void OnContinueButtonClick()
    {
        // Set destroyOnLoad flag to false before loading last scene
        sceneController.SetDestroyOnLoad(false);
        timeManager.SetDestroyOnLoad(false);

        // Load last scene
        sceneController.LoadLastScene();
    }

    public void OnNewGameButtonClick()
    {
        // Set destroyOnLoad flag to false before loading new game scene
        sceneController.SetDestroyOnLoad(false);
        timeManager.SetDestroyOnLoad(false);

        // Load new game scene
        sceneController.LoadScene("NewGameScene");
    }

    public void OnStartCutsceneButtonClick()
    {
        sceneController.LoadFirstCutscene();

        PlayerPrefs.DeleteAll();

        panel.SetActive(false);
    }
}