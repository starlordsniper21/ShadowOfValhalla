using UnityEngine;
using UnityEngine.UI;

public class ButtonSwapper : MonoBehaviour
{
    public Button swordButton;
    public Button bowButton;
    public Button swapButton;
    public Button backToSwapButton;

    private bool isSwordActive = true;

    void Start()
    {
        InitializeButtonsVisibility();
    }

    void InitializeButtonsVisibility()
    {
        swordButton.gameObject.SetActive(isSwordActive);
        bowButton.gameObject.SetActive(!isSwordActive);
        swapButton.gameObject.SetActive(true);
        backToSwapButton.gameObject.SetActive(false);
    }

    public void SwapButtons()
    {
        isSwordActive = !isSwordActive;
        swordButton.gameObject.SetActive(isSwordActive);
        bowButton.gameObject.SetActive(!isSwordActive);
        swapButton.gameObject.SetActive(false);
        backToSwapButton.gameObject.SetActive(true);
    }

    public void BackToSwap()
    {
        isSwordActive = !isSwordActive;
        swordButton.gameObject.SetActive(isSwordActive);
        bowButton.gameObject.SetActive(!isSwordActive);
        swapButton.gameObject.SetActive(true);
        backToSwapButton.gameObject.SetActive(false);
    }
}
