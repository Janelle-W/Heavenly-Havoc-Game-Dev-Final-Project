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
            Debug.Log("Hurdle movement initialized.");
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
            Debug.Log("Projectile marked for destruction.");

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }
    }
}
