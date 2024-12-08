using UnityEngine;

public class Titan : MonoBehaviour
{
    [Header("Titan Settings")]
    public bool hasTitan = false; 
    public int titanPoints = 10; 
    public int penaltyPoints = 5; 

    [Header("Audio")]
    public AudioClip titanSound; 
    public AudioClip monsterSound; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (hasTitan)
            {
                GaiaScoreManager.instance.IncreaseScore(titanPoints);
                Debug.Log($"Titan collected! +{titanPoints} points.");
                
                AudioManager.instance.PlaySFX(titanSound);
            }
            else
            {
                GaiaScoreManager.instance.IncreaseScore(-penaltyPoints);
                Debug.Log($"Underworld monster touched! -{penaltyPoints} points.");

                AudioManager.instance.PlaySFX(monsterSound);
            }

            Destroy(gameObject); 
        }
    }
}
