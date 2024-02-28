using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    private Button continueButton;

    private void Start()
    {
        continueButton = GetComponent<Button>();
        if (continueButton != null)
        {
            continueButton.onClick.AddListener(OnContinueButtonClick);
        }
        else
        {
            Debug.LogError("ContinueButton script attached to an object without a Button component.");
        }
    }

    public void OnContinueButtonClick()
    {
        SceneController.instance.LoadLastScene();
    }
}
