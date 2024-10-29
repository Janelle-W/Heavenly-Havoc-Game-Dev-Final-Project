using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ImageSlider imageSlider;  
    public RectTransform[] introImages; 
    public string[] levelScenes;  
    public float pauseDuration = 2.0f;  
    private int currentLevel = 0; 

    private void Start()
    {
        StartCoroutine(StartLevelSequence());
    }

    private IEnumerator StartLevelSequence()
    {
        if (currentLevel < introImages.Length && currentLevel < levelScenes.Length)
        {
           
            imageSlider.imageRect = introImages[currentLevel];

            if (imageSlider.imageRect == null)
            {
                Debug.LogError($"Intro image for level {currentLevel} is not assigned!");
                yield break; 
            }

            yield return StartCoroutine(imageSlider.SlideIn());

            yield return new WaitForSeconds(pauseDuration);

            yield return StartCoroutine(imageSlider.SlideOut());

            if (!string.IsNullOrEmpty(levelScenes[currentLevel]))
            {
                SceneManager.LoadScene(levelScenes[currentLevel]);
            }
            else
            {
                Debug.LogError($"Scene name for level {currentLevel} is not assigned!");
            }
        }
        else
        {
            Debug.LogError("Current level exceeds the number of assigned intro images or level scenes!");
        }
    }

    public void LoadNextLevel()
    {
        currentLevel++;
        StartCoroutine(StartLevelSequence());  
    }
}
