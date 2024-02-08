using UnityEngine;

public class DeadEyePowerUp : MonoBehaviour
{
    public float timeScaleFactor = 0.5f;
    public float duration = 5f;
    public Color deadEyeColor = Color.gray;
    private MovePlayer movePlayer;
    private Camera mainCamera;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            movePlayer = other.GetComponent<MovePlayer>();
            mainCamera = Camera.main;
            ActivatePowerUp();
        }
    }

    private void ActivatePowerUp()
    {
        Destroy(gameObject);
        mainCamera.backgroundColor = deadEyeColor;
        Time.timeScale = timeScaleFactor;
        Invoke("DeactivatePowerUp", duration);
    }

    private void DeactivatePowerUp()
    {
        mainCamera.backgroundColor = Color.black;
        Time.timeScale = 1f;
    }
}
