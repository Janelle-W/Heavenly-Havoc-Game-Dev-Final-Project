/*using UnityEngine;
using System.Collections.Generic;

public class HorizontalProjectileSpawner : MonoBehaviour
{
    [Header("Projectile Prefabs")]
    [SerializeField] private GameObject pointProjectilePrefab;
    [SerializeField] private GameObject obstacleProjectilePrefab;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 0.5f;
    [SerializeField] private float spawnYPosition = 0f; // Set this to the desired Y position
    [SerializeField] private float spawnXPosition = 8f; // Fixed horizontal spawn position

    [Header("Projectile Settings")]
    [SerializeField] private float projectileSpeed = 10f;

    [Header("Spawn Limits")]
    [SerializeField] private int maxProjectilesPerSpawn = 3;
    [SerializeField] private int maxActiveProjectiles = 9;

    [Header("Debug")]
    [SerializeField] private bool enableLogging = true;

    private float nextSpawnTime = 0f;
    private List<GameObject> activeProjectiles = new List<GameObject>();

    private void Update()
    {
        if (Time.time > nextSpawnTime && activeProjectiles.Count < maxActiveProjectiles)
        {
            nextSpawnTime = Time.time + spawnInterval;
            SpawnProjectiles();
        }

        CleanUpDestroyedProjectiles();
    }

    private void SpawnProjectiles()
    {
        int projectilesToSpawn = Random.Range(1, maxProjectilesPerSpawn + 1);
        
        for (int i = 0; i < projectilesToSpawn && activeProjectiles.Count < maxActiveProjectiles; i++)
        {
            SpawnSingleProjectile();
        }
    }

    private void SpawnSingleProjectile()
    {
        Vector3 spawnPosition = new Vector3(spawnXPosition, spawnYPosition, 0); // Fixed spawn position

        GameObject projectile = InstantiateProjectile(spawnPosition);
        SetupProjectileMovement(projectile);
        activeProjectiles.Add(projectile);

        if (enableLogging)
        {
            LogProjectileSpawn(projectile, spawnPosition);
        }
    }

    private GameObject InstantiateProjectile(Vector3 spawnPosition)
    {
        return Random.value < 0.5f
            ? Instantiate(pointProjectilePrefab, spawnPosition, Quaternion.identity)
            : Instantiate(obstacleProjectilePrefab, spawnPosition, Quaternion.identity);
    }

    private void SetupProjectileMovement(GameObject projectile)
    {
        HorizontalProjectileMovement movement = projectile.GetComponent<HorizontalProjectileMovement>();
        if (movement == null)
        {
            movement = projectile.AddComponent<HorizontalProjectileMovement>();
        }
        movement.speed = projectileSpeed; // Set the speed for the projectile
    }

    private void LogProjectileSpawn(GameObject projectile, Vector3 spawnPosition)
    {
        string projectileType = projectile.CompareTag("PointProjectile") ? "point" : "obstacle";
        Debug.Log($"Spawned {projectileType} projectile at {spawnPosition}");
        Debug.Log($"Spawned projectile tag: {projectile.tag}");
    }

    private void CleanUpDestroyedProjectiles()
    {
        activeProjectiles.RemoveAll(p => p == null);
    }
}

*/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HurdleSpawner : MonoBehaviour
{
    [Header("Hurdle Prefab")]
    [SerializeField] private GameObject hurdlePrefab;

    [Header("Spawn Settings")]
    [SerializeField] private float initialSpawnInterval = 2f; 
    [SerializeField] private float minimumSpawnInterval = 0.5f; 
    [SerializeField] private float spawnYPosition = 0f; 

    [Header("Difficulty Settings")]
    [SerializeField] private float difficultyIncreaseRate = 1f; 
    [SerializeField] private float spawnIntervalDecreaseAmount = 0.1f; 
    private float nextSpawnTime;
    private float currentSpawnInterval;
    private bool spawningHurdles = false;

    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval; 
    }

    private void Update()
    {
        if (spawningHurdles && Time.time > nextSpawnTime)
        {
            SpawnHurdle();
            nextSpawnTime = Time.time + currentSpawnInterval;
        }
    }

    public void StartSpawningHurdles()
    {
        spawningHurdles = true;
        StartCoroutine(IncreaseDifficulty());
    }

    private void SpawnHurdle()
    {
        Vector3 spawnPosition = new Vector3(10f, spawnYPosition, 0); 
        Instantiate(hurdlePrefab, spawnPosition, Quaternion.identity);
    }

    private IEnumerator IncreaseDifficulty()
    {
        while (spawningHurdles)
        {
            yield return new WaitForSeconds(difficultyIncreaseRate); 
            
            currentSpawnInterval = Mathf.Max(currentSpawnInterval - spawnIntervalDecreaseAmount, minimumSpawnInterval);
        }
    }

    public void StopSpawningHurdles()
    {
        spawningHurdles = false;
        StopCoroutine(IncreaseDifficulty());
    }
}
