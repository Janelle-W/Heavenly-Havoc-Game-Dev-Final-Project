using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyHealthManager : MonoBehaviour
{
    [Header("Health Settings")]
    public Slider healthBar; 
    public TextMeshProUGUI lowHealthMessage; 
    public float healthDepletionRate = 1f; 
    public float criticalHealthLevel = 20f;
    public float healthRefillAmount = 30f; 

    [Header("Health Flower")]
    public GameObject healthFlower; 

    private Image sliderFillImage; 

    private void Start()
    {
        if (lowHealthMessage != null)
        {
            lowHealthMessage.gameObject.SetActive(false); 
        }

        if (healthBar != null)
        {
            healthBar.value = healthBar.maxValue; 
            sliderFillImage = healthBar.fillRect.GetComponent<Image>();
        }
    }

    private void Update()
    {
        if (healthBar.value > 0)
        {
            healthBar.value -= healthDepletionRate * Time.deltaTime;
        }

        UpdateSliderColor();

        if (healthBar.value <= criticalHealthLevel && healthBar.value > 0)
        {
            lowHealthMessage.gameObject.SetActive(true);
        }
        else
        {
            lowHealthMessage.gameObject.SetActive(false);
        }

        if (healthBar.value <= 0 && !lowHealthMessage.gameObject.activeSelf)
        {
            Debug.Log("Player has run out of health! Game over.");
            FindObjectOfType<GameManager>().GameOver(); 
        }
    }

    private void UpdateSliderColor()
    {
        if (sliderFillImage != null)
        {
            float healthPercentage = healthBar.value / healthBar.maxValue;
            
            sliderFillImage.color = Color.Lerp(Color.red, Color.green, healthPercentage);
        }
    }

    public void RefillHealth()
    {
        healthBar.value = Mathf.Min(healthBar.value + healthRefillAmount, healthBar.maxValue);
        Debug.Log("Health refilled!");
    }
}
