using UnityEngine;

public class Underworld : MonoBehaviour
{
    [Header("Underworld Settings")]
    public bool isTitan = false; 
    public int titanPoints = 10; 
    public int penaltyPoints = 5; 

    [Header("Audio")]
    public AudioClip titanSound; 
    public AudioClip monsterSound; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.CompareTag("Player"))
        {
            if (isTitan)
            {
                ScoreManager.instance.IncreaseScore(titanPoints);
                Debug.Log($"Titan collected! +{titanPoints} points.");
                
                AudioManager.instance.PlaySFX(titanSound);
            }
            else
            {
                ScoreManager.instance.IncreaseScore(-penaltyPoints);
                Debug.Log($"Monster touched! -{penaltyPoints} points.");

                AudioManager.instance.PlaySFX(monsterSound);
            }

            Destroy(gameObject); 
        }*/
    }
}

