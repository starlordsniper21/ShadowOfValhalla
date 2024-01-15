using UnityEngine;

public class UndyingPowerUpScript : MonoBehaviour
{
    public UndyingPowerUpType undyingPowerUpType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MovePlayer movePlayer = other.GetComponent<MovePlayer>();
            if (movePlayer != null)
            {
                movePlayer.ActivateInvulnerability(5f);
                Destroy(gameObject);
            }
            else
            {
                
                Debug.LogWarning("MovePlayer component not found on player object.");
            }
        }
    }
}
