using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Reference to the player's Health component.
    public Health playerHealth;

    // Reference to the red fill image.
    public Image healthBarFill;

    void Update()
{
    if (playerHealth == null)
    {
        print("Player Health is null");
        return;
    }

    if (healthBarFill == null)
    {
        print("Health Bar Fill is null");
        return;
    }

    float healthPercent =
        (float)playerHealth.GetCurrentHealth() / playerHealth.maxHealth;

    healthBarFill.fillAmount = healthPercent;
}
}