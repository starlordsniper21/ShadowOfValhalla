using UnityEngine;

public class VikingAttackArea : MonoBehaviour
{
    public float attackDamage = 10f;
    public Rigidbody2D playerRigidbody;
    public MovePlayer movePlayer;

    [SerializeField] private float armorDamage;
    [SerializeField] private float healthDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && movePlayer != null)
        {
            movePlayer.KBCounter = movePlayer.KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
                movePlayer.KnockFromRight = true;
            else
                movePlayer.KnockFromRight = false;
            Armor armorComponent = collision.GetComponent<Armor>();
            if (armorComponent != null && armorComponent.currentArmor > 0)
            {
                armorComponent.TakeDamage(armorDamage);
                Debug.Log("Armor Damage: " + armorDamage);
            }
            else
            {
                Health healthComponent = collision.GetComponent<Health>();
                if (healthComponent != null)
                {
                    healthComponent.TakeDamage(healthDamage);
                    Debug.Log("Health Damage: " + healthDamage);
                }
            }
            gameObject.SetActive(false);
        }
    }
}
