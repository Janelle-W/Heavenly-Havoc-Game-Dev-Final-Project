/*using UnityEngine;

public class HorizontalProjectileMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] public float speed = 10f;
    [SerializeField] private Vector3 direction = Vector3.left; 

    [Header("Destruction")]
    [SerializeField] private float destroyBelowX = -10f; 
    [SerializeField] private float destroyDelay = 0.1f;

    [Header("Debug")]
    [SerializeField] private bool enableLogging = true;
    [SerializeField] private int logInterval = 60;

    private bool isDestroyed = false;

    private void Update()
    {
        if (isDestroyed) return;

        MoveProjectile();
        LogPosition();
        CheckForDestruction();
    }

    public void MoveProjectile()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void LogPosition()
    {
        if (enableLogging && Time.frameCount % logInterval == 0)
        {
            Debug.Log($"Projectile position: {transform.position}, Tag: {gameObject.tag}");
        }
    }

    private void CheckForDestruction()
    {
        if (transform.position.x < destroyBelowX)
        {
            if (enableLogging)
            {
                Debug.Log("Destroying projectile off-screen");
            }
            DestroyProjectile();
        }
    }


    public void DestroyProjectile()
{
    if (!isDestroyed)
    {
        isDestroyed = true;
        Debug.Log("Projectile marked for destruction");

        HurdleSpawner spawner = FindObjectOfType<HurdleSpawner>();
        if (spawner != null)
        {
            spawner.HurdleDestroyed();
        }
        else
        {
            Debug.LogWarning("No HurdleSpawner found when destroying projectile!");
        }

        Destroy(gameObject, destroyDelay);
    }
}



}*/


using UnityEngine;

public class HorizontalProjectileMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private Vector2 direction = Vector2.left; 

    [Header("Destruction")]
    [SerializeField] private float destroyBelowX = -10f; 
    [SerializeField] private float destroyDelay = 0.1f;

    private Rigidbody2D rb;
    private bool isDestroyed = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is missing from the hurdle!");
        }
        else
        {
            rb.velocity = direction.normalized * speed;
        }
    }

    private void Update()
    {
        if (isDestroyed) return;

        if (transform.position.x < destroyBelowX)
        {
            DestroyProjectile();
        }
    }

    public void DestroyProjectile()
    {
        if (!isDestroyed)
        {
            isDestroyed = true;
            Debug.Log("Projectile marked for destruction");

            HurdleSpawner spawner = FindObjectOfType<HurdleSpawner>();
            if (spawner != null)
            {
                spawner.HurdleDestroyed();
            }
            else
            {
                Debug.LogWarning("No HurdleSpawner found when destroying projectile!");
            }

            Destroy(gameObject, destroyDelay);
        }
    }
}
