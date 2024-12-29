using UnityEngine;

public class HealthBoostSpawner : MonoBehaviour
{
    public GameObject healthBoostPrefab; // Prefab of the health boost
    public Vector3 mapSize = new Vector3(50f, 0f, 50f); // Size of the map
    public float spawnInterval = 5f; // Time interval between spawns
    public float checkRadius = 0.5f; // Radius to check for LevelArt colliders

    private void Start()
    {
        // Start spawning health boosts at regular intervals
        InvokeRepeating(nameof(SpawnHealthBoost), spawnInterval, spawnInterval);
    }

    private void SpawnHealthBoost()
    {
        Vector3 spawnPosition;

        // Keep generating a random position until it's valid
        do
        {
            // Generate a random position within the map boundaries
            float x = Random.Range(-mapSize.x / 2, mapSize.x / 2);
            float z = Random.Range(-mapSize.z / 2, mapSize.z / 2);
            spawnPosition = new Vector3(x, 0f, z);

        } 
        while (IsInsideLevelArt(spawnPosition)); // Repeat if the position is inside LevelArt

        // Instantiate the health boost at the valid position
        Instantiate(healthBoostPrefab, spawnPosition, Quaternion.identity);
    }

    private bool IsInsideLevelArt(Vector3 position)
    {
        // Check for colliders in the specified radius
        Collider[] colliders = Physics.OverlapSphere(position, checkRadius);

        foreach (Collider collider in colliders)
        {
            // If any collider has the "LevelArt" tag, return true
            if (collider.CompareTag("LevelArt"))
            {
                return true;
            }
        }

        // No LevelArt colliders found at this position
        return false;
    }
}
