using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currentHealthbar;
    [SerializeField] private Text healthText; // Reference to the Text component.

    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 20;
    }

    private void Update()
    {
        currentHealthbar.fillAmount = playerHealth.currentHealth / 20;

        // Update the Text component with the player's current health.
        healthText.text = playerHealth.currentHealth + "/20".ToString();
    }
}