using UnityEngine;
using UnityEngine.UI;

public class ButtonSwapper : MonoBehaviour
{
    public Button swordButton;
    public Button bowButton;

    private bool isSwordActive = true;

    public void SwapButtons()
    {
        isSwordActive = !isSwordActive;
        swordButton.gameObject.SetActive(isSwordActive);
        bowButton.gameObject.SetActive(!isSwordActive);
    }
}
