using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    [Header("Resolution Dropdown")]
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    [Header("Fullscreen Toggle")]
    [SerializeField] private Toggle fullscreenToggle; // Optional

    [Header("VSync Toggle")]
    [SerializeField] private Toggle vsyncToggle; // Optional

    private Resolution[] resolutions;

    private void Start()
    {
        // Ensure resolution dropdown is assigned
        if (resolutionDropdown == null)
        {
            Debug.LogError("ResolutionDropdown (TMP_Dropdown) is not assigned in the Inspector!");
            return;
        }

        // Get system resolutions
        resolutions = Screen.resolutions;

        if (resolutions.Length == 0)
        {
            Debug.LogError("No resolutions available on this system!");
            return;
        }

        // Clear and populate TMP_Dropdown options
        resolutionDropdown.ClearOptions();
        var options = new System.Collections.Generic.List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string resolutionOption = $"{resolutions[i].width} x {resolutions[i].height}";
            options.Add(resolutionOption);

            // Check if this is the current resolution
            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Listen for TMP_Dropdown changes
        resolutionDropdown.onValueChanged.AddListener(SetResolution);

        // Handle fullscreen toggle (optional)
        if (fullscreenToggle != null)
        {
            fullscreenToggle.isOn = Screen.fullScreen;
            fullscreenToggle.onValueChanged.AddListener(SetFullscreen);
        }

        // Handle VSync toggle (optional)
        if (vsyncToggle != null)
        {
            vsyncToggle.isOn = QualitySettings.vSyncCount > 0;
            vsyncToggle.onValueChanged.AddListener(SetVSync);
        }
    }

    private void SetResolution(int resolutionIndex)
    {
        Resolution selectedResolution = resolutions[resolutionIndex];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreen);
        Debug.Log($"Resolution set to: {selectedResolution.width}x{selectedResolution.height}");
    }

    private void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        Debug.Log($"Fullscreen mode: {isFullscreen}");
    }

    private void SetVSync(bool isEnabled)
    {
        QualitySettings.vSyncCount = isEnabled ? 1 : 0;
        Debug.Log($"VSync enabled: {isEnabled}");
    }
}
