using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingController : MonoBehaviour
{
    [Header("Post-Processing Volume")]
    [SerializeField] private Volume postProcessVolume;


    [Header("UI Sliders")]
    [SerializeField] private Slider brightnessSlider;
    [SerializeField] private Slider contrastSlider;
    [SerializeField] private Slider colorationSlider;

    private ColorAdjustments colorAdjustments;

    private void Start()
    {
        // Get the Color Adjustments settings
        if (postProcessVolume.profile.TryGet(out colorAdjustments))
        {
            Debug.Log("Color Adjustments loaded successfully.");
        }
        else
        {
            Debug.LogError("Color Adjustments not found in the Post-Processing Profile. Ensure the effect is added.");
        }

        // Initialize slider values
        if (colorAdjustments != null)
        {
            brightnessSlider.value = colorAdjustments.postExposure.value;
            contrastSlider.value = colorAdjustments.contrast.value;
            colorationSlider.value = colorAdjustments.saturation.value;

            // Add listeners to sliders
            brightnessSlider.onValueChanged.AddListener(SetBrightness);
            contrastSlider.onValueChanged.AddListener(SetContrast);
            colorationSlider.onValueChanged.AddListener(SetColoration);
        }
    }

    private void SetBrightness(float value)
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.postExposure.value = value;
            Debug.Log($"Brightness set to: {value}");
        }
    }

    private void SetContrast(float value)
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.contrast.value = value;
            Debug.Log($"Contrast set to: {value}");
        }
    }

    private void SetColoration(float value)
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.saturation.value = value;
            Debug.Log($"Coloration set to: {value}");
        }
    }
}

