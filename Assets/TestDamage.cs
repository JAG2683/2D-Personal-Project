using UnityEngine;

public class TestDamage : MonoBehaviour
{
    // Reference to the Health component on this GameObject.
    private Health ht;

    void Start()
    {
        // Find the Health component attached to this GameObject.
        ht = GetComponent<Health>();
    }

    void Update()
    {
        // When H is pressed, deal 10 damage.
        if (Input.GetKeyDown(KeyCode.H))
        {
            ht.TakeDamage(10);
        }
    }
}