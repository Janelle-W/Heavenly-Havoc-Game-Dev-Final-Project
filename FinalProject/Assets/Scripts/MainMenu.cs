/*using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Scene Management")]
    [SerializeField] private string gameSceneName = "GameScene";
    [SerializeField] private string optionsSceneName = "OptionsScene";
    [SerializeField] private string nikeIntroSceneName = "LvlNikeIntro";

    public void StartGame()
    {
        SceneManager.LoadScene(nikeIntroSceneName);
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene(optionsSceneName); 
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Scene Management")]
    [SerializeField] private string gameSceneName = "GameScene";
    [SerializeField] private string optionsSceneName = "OptionsScene";
    [SerializeField] private string nikeIntroSceneName = "LvlNikeIntro";

    private void Start()
    {
        // Debugging to confirm AudioManager is active
        if (AudioManager.instance != null)
        {
            Debug.Log("AudioManager is active in MainMenu.");
            // Play MainMenu music (if not already playing)
            AudioManager.instance.PlaySceneMusic(AudioManager.instance.mainMenuMusic);
        }
        else
        {
            Debug.LogError("AudioManager is missing in MainMenu!");
        }
    }

    public void StartGame()
    {
        Debug.Log("Loading NikeIntro scene...");
        SceneManager.LoadScene(nikeIntroSceneName);
    }

    public void OpenOptions()
    {
        Debug.Log("Loading Options scene...");
        SceneManager.LoadScene(optionsSceneName); 
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
