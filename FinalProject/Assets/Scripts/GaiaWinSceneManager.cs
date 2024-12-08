using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WinSceneManager : MonoBehaviour
{
    [Header("Slide Settings")]
    public RectTransform slideImage; 
    public float slideDuration = 1.0f; 
    public float pauseDuration = 2.0f; 

    [Header("Next Scene")]
    public string mainMenuSceneName = "MainMenu"; 

    private void Start()
    {
        StartCoroutine(SlideSequence());
    }

    private IEnumerator SlideSequence()
    {
        Debug.Log("Sliding in...");
        yield return StartCoroutine(Slide(Vector2.left * Screen.width, Vector2.zero));

        Debug.Log("Pausing...");
        yield return new WaitForSeconds(pauseDuration);

        Debug.Log("Sliding out to the right...");
        yield return StartCoroutine(Slide(Vector2.zero, Vector2.right * Screen.width));

        Debug.Log("Transitioning to Main Menu...");
        SceneManager.LoadScene(mainMenuSceneName);
    }

    private IEnumerator Slide(Vector2 startPosition, Vector2 endPosition)
    {
        float elapsedTime = 0f;

        slideImage.anchoredPosition = startPosition;

        while (elapsedTime < slideDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / slideDuration);
            slideImage.anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        slideImage.anchoredPosition = endPosition;
    }
}
