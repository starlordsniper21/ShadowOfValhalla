using UnityEngine;
using UnityEngine.UI;

public class ManaManager : MonoBehaviour
{
    [SerializeField] private ManaSystem playerMana;
    [SerializeField] private Image totalManaBar;
    [SerializeField] private Image currentManaBar;

    private void Start()
    {
        UpdateManaBar();
    }

    private void Update()
    {
        UpdateManaBar();
    }

    private void UpdateManaBar()
    {
        totalManaBar.fillAmount = (float)playerMana.maxMana / 20;
        currentManaBar.fillAmount = (float)playerMana.currentMana / 20;
    }
}
