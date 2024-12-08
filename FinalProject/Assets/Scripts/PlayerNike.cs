using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LevelNike levelNike; 

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
