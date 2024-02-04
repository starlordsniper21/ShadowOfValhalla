using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 2f;
    [SerializeField] private float duration = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MovePlayer playerMovement = collision.GetComponent<MovePlayer>();
            if (playerMovement != null)
            {
                playerMovement.ActivateSpeedPowerUp(speedMultiplier, duration);
            }
            Destroy(gameObject);
        }
    }
}
