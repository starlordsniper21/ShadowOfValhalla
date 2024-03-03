using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    private Button continueButton;
    private Button newGameButton;
    private GameObject panel;
    private Button startCutsceneButton;

    private void Start()
    {
        // Halos sumabog na utak ko sa paggawa nito boss michael hahahahaha
        continueButton = GetComponent<Button>();
        if (continueButton == null)
        {
            Debug.LogError("continue button noscript");
            return;
        }

        continueButton.onClick.AddListener(OnContinueButtonClick);

        newGameButton = transform.parent.Find("NewGameButton")?.GetComponent<Button>();
        if (newGameButton == null)
        {
            Debug.LogError("NewGameButtonnotfound");
            return;
        }

        newGameButton.onClick.AddListener(OnNewGameButtonClick);

        panel = transform.parent.Find("NewGamePanel")?.gameObject;
        if (panel == null)
        {
            Debug.LogError("no Newgamepanel");
            return;
        }

        startCutsceneButton = panel.transform.Find("YES")?.GetComponent<Button>();
        if (startCutsceneButton == null)
        {
            Debug.LogError("Noyesbutton");
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
        SceneController.instance.LoadLastScene();
    }

    public void OnNewGameButtonClick()
    {
        
        panel.SetActive(true);
    }

    public void OnStartCutsceneButtonClick()
    {
        SceneController.instance.LoadFirstCutscene();

        PlayerPrefs.DeleteAll();

        panel.SetActive(false);
    }
}
