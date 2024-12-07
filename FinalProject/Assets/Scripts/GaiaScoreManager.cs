using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GaiaScoreManager : MonoBehaviour
{
    public static GaiaScoreManager instance;

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public Color addColor = Color.white; 
    public Color deductColor = Color.red; 
    public float colorChangeDuration = 0.5f; 

    [Header("Score")]
    private int score = 0;
    public int winScore = 100;
    public string winSceneName = "WinScene"; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreDisplay();

        if (amount > 0)
        {
            StartCoroutine(ChangeScoreTextColor(addColor));
        }
        else if (amount < 0)
        {
            StartCoroutine(ChangeScoreTextColor(deductColor));
        }

        if (score >= winScore)
        {
            Debug.Log("Player wins! Transitioning to the win scene.");
            SceneManager.LoadScene(winSceneName);
        }

        Debug.Log($"Score updated: {score}");
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreDisplay();
        Debug.Log("Score reset to zero.");
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
        else
        {
            Debug.LogError("ScoreText is not assigned!");
        }
    }

    private System.Collections.IEnumerator ChangeScoreTextColor(Color targetColor)
    {
        if (scoreText != null)
        {
            
            scoreText.color = targetColor;

            
            yield return new WaitForSeconds(colorChangeDuration);

            
            scoreText.color = addColor;
        }
    }
}