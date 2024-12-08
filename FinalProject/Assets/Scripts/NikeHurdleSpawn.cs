using UnityEngine;
using System.Collections;

public class HurdleSpawner : MonoBehaviour
{
    [Header("Hurdle Prefab")]
    [SerializeField] private GameObject hurdlePrefab;

    [Header("Spawn Settings")]
    [SerializeField] private float initialSpawnInterval = 2f;
    [SerializeField] private float minimumSpawnInterval = 1f;
    [SerializeField] private float spawnYPosition = 0f;

    [Header("Difficulty Settings")]
    [SerializeField] private float difficultyIncreaseRate = 2f;
    [SerializeField] private float spawnIntervalDecreaseAmount = 0.05f;

    [Header("Hurdle Limit")]
    [SerializeField] private int maxHurdles = 5;

    private float nextSpawnTime;
    private float currentSpawnInterval;
    private bool spawningHurdles = false;
    private int hurdlesSpawned = 0;
    private int hurdlesDestroyed = 0;

    private Coroutine difficultyCoroutine;
    private LevelNike levelNike;

    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        levelNike = FindObjectOfType<LevelNike>();
        if (levelNike == null)
        {
            Debug.LogWarning("No LevelNike found in the scene. 'Hurdles Left' UI will not update.");
        }
    }

    private void Update()
    {
        if (spawningHurdles && Time.time >= nextSpawnTime)
        {
            if (hurdlesSpawned < maxHurdles)
            {
                SpawnHurdle();
                nextSpawnTime = Time.time + currentSpawnInterval;
            }
            else
            {
                StopSpawningHurdles();
            }
        }
    }

    public void StartSpawningHurdles()
    {
        if (!spawningHurdles)
        {
            spawningHurdles = true;
            difficultyCoroutine = StartCoroutine(IncreaseDifficulty());
            UpdateHurdlesLeftUI();
            nextSpawnTime = Time.time + currentSpawnInterval;
            Debug.Log("Started spawning hurdles.");
        }
    }

    private void SpawnHurdle()
    {
        GameObject hurdle = Instantiate(hurdlePrefab, new Vector3(10f, spawnYPosition, 0), Quaternion.identity);
        Rigidbody2D rb = hurdle.GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = hurdle.AddComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        hurdlesSpawned++;
        UpdateHurdlesLeftUI();
        Debug.Log($"Spawned hurdle #{hurdlesSpawned}.");
    }

    public void HurdleDestroyed()
{
    hurdlesDestroyed++;
    int hurdlesLeft = Mathf.Max(maxHurdles - hurdlesDestroyed, 0);
    Debug.Log($"Hurdle destroyed. Total destroyed: {hurdlesDestroyed}. Hurdles left: {hurdlesLeft}.");

    if (levelNike != null)
    {
        levelNike.UpdateHurdlesLeftText(hurdlesLeft);
    }
    else
    {
        Debug.LogWarning("LevelNike reference is missing. Unable to update hurdles left.");
    }
}


    private void UpdateHurdlesLeftUI()
    {
        int hurdlesLeft = Mathf.Max(maxHurdles - hurdlesDestroyed, 0);
        if (levelNike != null)
            levelNike.UpdateHurdlesLeftText(hurdlesLeft);
    }

    private IEnumerator IncreaseDifficulty()
    {
        while (spawningHurdles)
        {
            yield return new WaitForSeconds(difficultyIncreaseRate);
            currentSpawnInterval = Mathf.Max(currentSpawnInterval - spawnIntervalDecreaseAmount, minimumSpawnInterval);
            Debug.Log($"Difficulty increased: new spawn interval = {currentSpawnInterval:F2}s");
        }
    }

    public void StopSpawningHurdles()
    {
        spawningHurdles = false;
        if (difficultyCoroutine != null)
        {
            StopCoroutine(difficultyCoroutine);
        }
        Debug.Log("Stopped spawning hurdles after spawning " + hurdlesSpawned + " hurdles.");
    }

    public int HurdlesDestroyed => hurdlesDestroyed;
    public int MaxHurdles => maxHurdles;
}
