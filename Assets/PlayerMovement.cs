using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float x;
    private float y;
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {   
    rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        rb.linearVelocity = new Vector2(x, y) * speed;
    }
}