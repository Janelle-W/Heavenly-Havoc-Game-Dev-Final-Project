using UnityEngine;

public class UnderworldSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject[] underworldPrefabs; 
    public float spawnInterval = 3f; 
    public float minY = -4f; 
    public float maxY = 4f;  
    public float minX = -10f; 
    public float maxX = 10f;  
    public float underworldLifetime = 6f; 

    private void Start()
    {
        InvokeRepeating(nameof(SpawnClam), spawnInterval, spawnInterval);
    }

    private void SpawnClam()
    {
        if (underworldPrefabs.Length == 0)
        {
            Debug.LogError("UnderworldSpawner: No underworld prefabs assigned!");
            return;
        }

        GameObject underworldPrefab = underworldPrefabs[Random.Range(0, underworldPrefabs.Length)];

        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);

        GameObject spawnedUnderworld = Instantiate(underworldPrefab, spawnPosition, Quaternion.identity);

        Destroy(spawnedUnderworld, underworldLifetime);

        Debug.Log($"Clam spawned at: {spawnPosition}");
    }
}