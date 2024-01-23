using UnityEngine;

public class SpellCaster : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform firePoint;
    public Animator animator;
    private Vector2 playerDirection = Vector2.right;
    public ManaSystem manaSystem;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetButtonDown("Spell"))
        {
            CastSpell();
        }
    }

    public void MobileSpellButtonClicked()
    {
        CastSpell();
        animator.SetTrigger("spell");
    }

    void CastSpell()
    {
        Debug.Log("Casting Spell");

        if (fireballPrefab != null && firePoint != null)
        {

            if (manaSystem.CanCastSpell())
            {

                GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);

                Vector2 spellDirection = playerDirection;
                if (playerDirection.x < 0)
                {
                    spellDirection = new Vector2(-spellDirection.x, spellDirection.y);
                }

                Power fireballScript = fireball.GetComponent<Power>();
                if (fireballScript != null)
                {
                    fireballScript.Setup(spellDirection);
                    manaSystem.UseMana();
                    Debug.Log("Spell cast successful. Mana used.");
                }
                else
                {
                    Debug.LogWarning("Fireball prefab is missing Power component.");
                }
            }
            else
            {
                Debug.LogWarning("Not enough mana to cast the spell!");
            }
        }
        else
        {
            Debug.LogWarning("Spell prefab or firePoint not assigned in the inspector.");
        }
    }

    public void SetPlayerDirection(Vector2 direction)
    {
        playerDirection = direction.normalized;
    }
}
