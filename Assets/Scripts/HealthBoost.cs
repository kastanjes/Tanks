using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    public int healthAmount = 20; // Amount of health to restore

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TankHealth playerHealth = other.GetComponent<TankHealth>();
            if (playerHealth != null)
            {
                playerHealth.RestoreHealth(healthAmount); // Add health to the player
            }

            // Destroy the health boost after it is collected
            Destroy(gameObject);
        }
    }
}
