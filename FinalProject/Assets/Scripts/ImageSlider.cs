using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageSlider : MonoBehaviour
{
    public RectTransform imageRect;  
    public float slideDuration = 2.0f;  

    public Vector2 startPosition;  
    public Vector2 endPosition;   

    public IEnumerator SlideIn()
    {
        float elapsedTime = 0f;
        imageRect.anchoredPosition = startPosition;

        while (elapsedTime < slideDuration)
        {
            imageRect.anchoredPosition = Vector2.Lerp(startPosition, endPosition, elapsedTime / slideDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        imageRect.anchoredPosition = endPosition;  
    }

    public IEnumerator SlideOut()
    {
        float elapsedTime = 0f;

        Vector2 slideOutPosition = new Vector2(
            endPosition.x < 0 ? -1000 : 1500, 
            endPosition.y
        );

        while (elapsedTime < slideDuration)
        {
            imageRect.anchoredPosition = Vector2.Lerp(endPosition, slideOutPosition, elapsedTime / slideDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        imageRect.anchoredPosition = slideOutPosition;  
    }
}
