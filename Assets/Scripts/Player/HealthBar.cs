using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currentHealthbar;

    private void Update()
    {
        if (playerHealth != null)
        {

            float fillAmount = playerHealth.currentHealth / playerHealth.startingHealth;

          
            fillAmount = Mathf.Clamp01(fillAmount);

           
            currentHealthbar.fillAmount = fillAmount;
        }
        else
        {
            Debug.LogWarning("Player health reference not set in HealthBar.");
        }
    }
}
