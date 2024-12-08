using UnityEngine;

public class EnergyHealth : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<EnergyHealthManager>().RefillHealth();
            Debug.Log("Player interacted with the health flower!");

        }
    }

    private void Update()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null && !sr.enabled)
        {
            Debug.LogError("Health flower's SpriteRenderer was disabled! Re-enabling.");
            sr.enabled = true;
        }
    }
}