using UnityEngine;

public class RagePowerUp : MonoBehaviour
{
    [SerializeField] private float duration = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerAttack playerAttack = collision.GetComponent<PlayerAttack>();
            if (playerAttack != null)
            {
               // playerAttack.ActivateRage(duration);
            }
            Destroy(gameObject);
        }
    }
}
