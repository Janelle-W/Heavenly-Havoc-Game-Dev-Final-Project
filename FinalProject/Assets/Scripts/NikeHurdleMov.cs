using UnityEngine;

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
            if (enableLogging)
            {
                Debug.Log("Projectile marked for destruction");
            }
            Destroy(gameObject, destroyDelay);
        }
    }
}
