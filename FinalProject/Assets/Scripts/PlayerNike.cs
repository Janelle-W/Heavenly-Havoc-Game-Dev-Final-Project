/*using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LevelNike levelNike; // Reference to LevelNike

    private void Start()
    {
        // If levelNike is not assigned in the Inspector, find it in the scene
        if (levelNike == null)
        {
            levelNike = FindObjectOfType<LevelNike>();
            if (levelNike == null)
            {
                Debug.LogError("LevelNike not found in the scene.");
            }
        }
    }

    // Changed from OnCollisionEnter2D to OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hurdle"))
        {
            Debug.Log("Player collided with a hurdle. Adding 3 seconds.");
            
            // Ensure levelNike is not null before calling AddTime
            if (levelNike != null)
            {
                levelNike.AddTime(3f); // Correct instance method call
            }
            else
            {
                Debug.LogError("LevelNike reference is missing in Player script.");
            }
        }
    }
}*/

using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LevelNike levelNike; // Reference to LevelNike

    private void Start()
    {
        if (levelNike == null)
        {
            levelNike = FindObjectOfType<LevelNike>();
            if (levelNike == null)
            {
                Debug.LogError("LevelNike not found in the scene.");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hurdle"))
        {
            Debug.Log("Player triggered a hurdle. Adding 3 seconds.");

            if (levelNike != null)
            {
                levelNike.AddTime(3f);
            }
        }
    }
}
