using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Tracks whether the player is currently inside the trigger.
    private bool playerInRange = false;

    // Stores a reference to the player's Health component.
    private Health playerHealth;

    // How often the enemy deals damage.
    public float damageInterval = 1f;

    // Counts down until the next attack.
    private float damageTimer = 0f;

    // Called when something enters the trigger.
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object that entered is the player.
        if (collision.gameObject.CompareTag("Player"))
        {
            // Remember that the player is inside the trigger.
            playerInRange = true;

            // Save a reference to the player's Health component.
            playerHealth = collision.gameObject.GetComponent<Health>();

            // Deal damage immediately on first contact.
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10);
            }

            // Reset the timer.
            damageTimer = damageInterval;
        }
    }

    // Called when something leaves the trigger.
    void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the object leaving is the player.
        if (collision.gameObject.CompareTag("Player"))
        {
            // The player is no longer in range.
            playerInRange = false;

            // Clear the stored reference.
            playerHealth = null;
        }
    }

    // Runs every frame.
    void Update()
    {
        // Only count down if the player is currently in range.
        if (playerInRange && playerHealth != null)
        {
            // Subtract the time that passed this frame.
            damageTimer -= Time.deltaTime;

            // Time to deal damage again.
            if (damageTimer <= 0)
            {
                playerHealth.TakeDamage(10);

                // Reset the timer for the next hit.
                damageTimer = damageInterval;
            }
        }
    }
}