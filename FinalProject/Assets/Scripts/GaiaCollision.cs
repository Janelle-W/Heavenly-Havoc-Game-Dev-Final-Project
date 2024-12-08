using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GaiaCollision : MonoBehaviour
{
    [Header("Collision Tags")]
    [SerializeField] private string pointProjectileTag = "PointProjectile";
    [SerializeField] private string obstacleProjectileTag = "ObstacleProjectile";

    [Header("Scene Management")]
    [SerializeField] private int mainMenuSceneIndex = 0;
    [SerializeField] private float returnToMenuDelay = 0.5f;

    [Header("Score")]
    [SerializeField] private int pointValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(pointProjectileTag))
        {
            HandlePointProjectileCollision();
        }
        else if (collision.gameObject.CompareTag(obstacleProjectileTag))
        {
            HandleObstacleProjectileCollision();
        }

        Destroy(collision.gameObject);
    }

    private void HandlePointProjectileCollision()
    {
        if (GaiaScoreManager.instance != null)
        {
            GaiaScoreManager.instance.IncreaseScore(pointValue);
        }
        else
        {
            Debug.LogWarning("ScoreManager instance is null!");
        }

        if (AudioManager.instance != null)
        {
            //AudioManager.instance.PlayPointCollectSound();
        }
        else
        {
            Debug.LogWarning("AudioManager instance is null!");
        }

        Debug.Log("Point collected!");
    }

    private void HandleObstacleProjectileCollision()
    {
        Debug.Log("Hit obstacle projectile. Returning to main menu.");
        StartCoroutine(ReturnToMainMenu());
    }

    private IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(returnToMenuDelay);
        SceneManager.LoadScene(mainMenuSceneIndex);
    }
}