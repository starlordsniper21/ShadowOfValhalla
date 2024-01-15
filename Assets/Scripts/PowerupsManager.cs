using System.Collections;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    public static PowerUpsManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ApplyPowerUp(UndyingPowerUpType type, GameObject player)
    {
        switch (type)
        {
            case UndyingPowerUpType.Invulnerability:
                StartCoroutine(InvulnerabilityPowerUp(player));
                break;
            

            default:
                Debug.LogWarning("Unknown undying power-up type: " + type);
                break;
        }
    }

    private IEnumerator InvulnerabilityPowerUp(GameObject player)
    {
        MovePlayer movePlayer = player.GetComponent<MovePlayer>();

        if (movePlayer != null)
        {
            movePlayer.ActivateInvulnerability(5f); 
            yield return new WaitForSeconds(5f); 
            
        }
    }
}

public enum UndyingPowerUpType
{
    Invulnerability,
    // Add more undying power-up types here
}
