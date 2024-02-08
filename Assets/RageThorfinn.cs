using System.Collections;
using UnityEngine;

public class PowerUpDoubleDamage : MonoBehaviour
{
    [SerializeField] private float damageMultiplier = 5f;
    private float duration = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAttack playerAttack = other.GetComponent<PlayerAttack>();
            if (playerAttack != null)
            {
                playerAttack.ApplyDamageMultiplier(damageMultiplier);
                StartCoroutine(CountdownDuration(playerAttack));
                Destroy(gameObject);
            }
        }
    }

    private IEnumerator CountdownDuration(PlayerAttack playerAttack)
    {
        for (float remainingTime = duration; remainingTime > 0; remainingTime -= 1f)
        {
            Debug.Log("Power-up duration: " + Mathf.RoundToInt(remainingTime) + " seconds remaining");
            yield return new WaitForSeconds(1f);
        }

        playerAttack.ResetDamageMultiplier();
    }

}
