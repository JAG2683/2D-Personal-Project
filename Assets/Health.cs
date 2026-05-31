using UnityEngine;

public class Health : MonoBehaviour
{
    // Maximum health. Public so it can be changed in the Inspector.
    public int maxHealth = 100;

    // Current health. Private so only the Health class can modify it.
    private int currentHealth;

    // Tracks whether this object is dead.
    private bool isDead = false;

    // Tracks whether this object can currently take damage.
    private bool isInvincible = false;

    // Counts down how much invincibility time is left.
    private float invincibleTimer = 0f;

    void Start()
    {
        // When the game starts, current health begins at max health.
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Only count down the timer if invincibility is active.
        if (isInvincible)
        {
            // Subtract the amount of time that passed this frame.
            invincibleTimer -= Time.deltaTime;

            // If the timer reaches zero, invincibility ends.
            if (invincibleTimer <= 0)
            {
                isInvincible = false;
                invincibleTimer = 0;
            }
        }
    }

    // Allows other scripts to check if this object is dead.
    public bool GetIsDead()
    {
        return isDead;
    }

    // Allows other scripts to read the current health value.
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    // Called when something deals damage to this object.
    public void TakeDamage(int damage)
    {
        // Dead objects cannot take more damage.
        if (isDead)
        {
            return;
        }

        // Invincible objects cannot take damage.
        if (isInvincible)
        {
            return;
        }

        // Reduce health by the damage amount.
        currentHealth -= damage;

        // Become invincible for 1 second after taking damage.
        isInvincible = true;
        invincibleTimer = 1f;

        // If health reaches zero or below, clamp it to zero and mark dead.
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }
    }
}