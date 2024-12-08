using UnityEngine;

public class StrikeSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject strikePrefab; 
    public float spawnInterval = 2f; 
    public float minX = -8f; 
    public float maxX = 8f;  
    public float spawnY = 10f; 

    private void Start()
    {
        InvokeRepeating(nameof(SpawnStrike), spawnInterval, spawnInterval);
    }

    private void SpawnStrike()
    {
        float randomX = Random.Range(minX, maxX);

        Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

        GameObject strike = Instantiate(strikePrefab, spawnPosition, Quaternion.identity);

        Debug.Log($"Zeus strike spawned at: {spawnPosition}");
    }
}

