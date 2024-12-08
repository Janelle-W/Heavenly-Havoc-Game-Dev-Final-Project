using UnityEngine;

public class BadFishMovement : MonoBehaviour
{
    public float speed = 2f; 
    public AudioClip hitSound; 
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing on BadFish prefab!");
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 1f)
        {
            Destroy(gameObject);
            Debug.Log("Bad fish destroyed after moving offscreen.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player touched the bad fish! Game Over.");

            if (audioSource != null && hitSound != null)
            {
                audioSource.PlayOneShot(hitSound);
            }

            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
