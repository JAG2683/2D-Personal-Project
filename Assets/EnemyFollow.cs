using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    // Stores a reference to the player's Transform.
    private Transform player;

    // Stores a reference to this enemy's Rigidbody2D.
    private Rigidbody2D rb;

    // Controls how fast the enemy moves.
    public float moveSpeed = 2f;

    void Start()
    {
        // Find the GameObject tagged "Player"
        // and store its Transform.
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the Rigidbody2D attached to this enemy.
        rb = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is used for physics-related movement.
    // Since we're moving a Rigidbody2D, this is better than Update.
    void FixedUpdate()
    {
        // Make sure a player was found.
        if (player != null)
        {
            // Get the direction from the enemy to the player.
            Vector3 direction = player.position - transform.position;

            // Only move if the player is more than 0.5 units away.
            if (direction.magnitude > 0.5f)
            {
                // Make the direction length equal to 1.
                // This keeps movement speed consistent.
                direction = direction.normalized;

                // Move the enemy by setting its velocity.
                // direction = where to move
                // moveSpeed = how fast to move
                rb.linearVelocity = direction * moveSpeed;
            }
            else
            {
                // Stop moving when we're close enough to the player.
                rb.linearVelocity = Vector2.zero;
            }
        }
    }
}