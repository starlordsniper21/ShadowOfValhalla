using UnityEngine;
using System.Collections;

public class DeadEyePowerUp : MonoBehaviour
{
    public float timeScaleFactor = 0.5f;
    public float duration = 5f;
    public Color deadEyeColor = Color.gray;
    public AudioClip activateSound; // Sound when power-up is activated
    private MovePlayer movePlayer;
    private Camera mainCamera;
    private Coroutine powerUpCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            movePlayer = collision.GetComponent<MovePlayer>();
            mainCamera = Camera.main;
            ActivatePowerUp();
        }
    }

    private void ActivatePowerUp()
    {
        mainCamera.backgroundColor = deadEyeColor;
        Time.timeScale = timeScaleFactor;
        if (activateSound != null)
        {
            AudioSource.PlayClipAtPoint(activateSound, transform.position);
        }
        powerUpCoroutine = StartCoroutine(DeactivateAfterDuration(duration));
    }

    private IEnumerator DeactivateAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        DeactivatePowerUp();
    }

    private void DeactivatePowerUp()
    {
        mainCamera.backgroundColor = Color.black;
        Time.timeScale = 1f;
        Destroy(gameObject);
        if (powerUpCoroutine != null)
            StopCoroutine(powerUpCoroutine);
    }
}
