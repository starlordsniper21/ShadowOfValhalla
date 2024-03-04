using UnityEngine;

public class InvulnerabilityPowerUp : MonoBehaviour
{
    [SerializeField] private float invulnerabilityDuration = 10.0f;
    public AudioClip activateSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            if (activateSound != null)
            {
                AudioSource.PlayClipAtPoint(activateSound, transform.position);
            }

            collision.GetComponent<Health>().ActivateInvulnerability(invulnerabilityDuration);
            Destroy(gameObject, 0.5f);
        }
    }
}
