/*using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        musicSlider.value = savedMusicVolume;
        sfxSlider.value = savedSFXVolume;

        AudioManager.instance.SetMusicVolume(savedMusicVolume);
        AudioManager.instance.SetSFXVolume(savedSFXVolume);

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMusicVolume(float volume)
    {
        AudioManager.instance.SetMusicVolume(volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        AudioManager.instance.SetSFXVolume(volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }
}*/
/*
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [Header("Sliders")]
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        // Load saved volume settings
        float savedMasterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f); // Default to max volume
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        // Set slider values
        masterVolumeSlider.value = savedMasterVolume;
        musicSlider.value = savedMusicVolume;
        sfxSlider.value = savedSFXVolume;

        // Apply saved values to the AudioManager
        AudioManager.instance.SetMasterVolume(savedMasterVolume);
        AudioManager.instance.SetMusicVolume(savedMusicVolume);
        AudioManager.instance.SetSFXVolume(savedSFXVolume);

        // Add listeners to sliders
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMasterVolume(float volume)
    {
        AudioManager.instance.SetMasterVolume(volume);
        PlayerPrefs.SetFloat("MasterVolume", volume); // Save value
    }

    public void SetMusicVolume(float volume)
    {
        AudioManager.instance.SetMusicVolume(volume);
        PlayerPrefs.SetFloat("MusicVolume", volume); // Save value
    }

    public void SetSFXVolume(float volume)
    {
        AudioManager.instance.SetSFXVolume(volume);
        PlayerPrefs.SetFloat("SFXVolume", volume); // Save value
    }
}

*/
/*
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal; // For URP Volume and effects


public class VolumeController : MonoBehaviour
{
    [Header("Post-Processing")]
    [SerializeField] private Volume postProcessVolume; // Reference your Volume
    private ColorAdjustments colorAdjustments;

    private void Start()
    {
        // Get the Color Adjustments component
        if (postProcessVolume.profile.TryGet<ColorAdjustments>(out colorAdjustments))
        {
            Debug.Log("Color Adjustments loaded successfully.");
        }
        else
        {
            Debug.LogError("Color Adjustments not found in the Post-Process Volume.");
        }
    }

    public void SetBrightness(float value)
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.postExposure.value = value;
        }
    }

    public void SetContrast(float value)
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.contrast.value = value;
        }
    }

    public void SetSaturation(float value)
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.saturation.value = value;
        }
    }
}
*/
/*
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class VolumeController : MonoBehaviour
{
    [Header("Post-Processing")]
    [SerializeField] private Volume postProcessVolume; // Drag PostProcessingVolume GameObject here
    private ColorAdjustments colorAdjustments;

    private void Start()
    {
        if (postProcessVolume != null && postProcessVolume.profile != null)
        {
            if (postProcessVolume.profile.TryGet(out colorAdjustments))
            {
                Debug.Log("Color Adjustments loaded successfully.");
            }
            else
            {
                Debug.LogWarning("Color Adjustments not found in the Post-Processing Volume Profile. Ensure the override is added.");
            }
        }
        else
        {
            Debug.LogError("Post-Processing Volume or Profile is missing!");
        }
    }

    public void SetBrightness(float value)
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.postExposure.value = value;
        }
    }

    public void SetContrast(float value)
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.contrast.value = value;
        }
    }

    public void SetSaturation(float value)
    {
        if (colorAdjustments != null)
        {
            colorAdjustments.saturation.value = value;
        }
    }
}
*/
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [Header("Audio Sliders")]
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Start()
    {
        float savedMasterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        if (masterVolumeSlider != null) masterVolumeSlider.value = savedMasterVolume;
        if (musicSlider != null) musicSlider.value = savedMusicVolume;
        if (sfxSlider != null) sfxSlider.value = savedSFXVolume;

        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetMasterVolume(savedMasterVolume);
            AudioManager.instance.SetMusicVolume(savedMusicVolume);
            AudioManager.instance.SetSFXVolume(savedSFXVolume);
        }

        if (masterVolumeSlider != null) masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        if (musicSlider != null) musicSlider.onValueChanged.AddListener(SetMusicVolume);
        if (sfxSlider != null) sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMasterVolume(float volume)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetMasterVolume(volume);
            PlayerPrefs.SetFloat("MasterVolume", volume);
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetMusicVolume(volume);
            PlayerPrefs.SetFloat("MusicVolume", volume);
        }
    }

    public void SetSFXVolume(float volume)
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.SetSFXVolume(volume);
            PlayerPrefs.SetFloat("SFXVolume", volume);
        }
    }
}
