using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Scene Management")]
    [SerializeField] private string gameSceneName = "GameScene";
    [SerializeField] private string optionsSceneName = "OptionsScene";

    [SerializeField] private string nikeIntroSceneName = "LvlNikeIntro";

    [Header("UI References")]
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject quitButton;

    [SerializeField] private GameObject optionsButton;

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

    private void Start()
    {
        if (startButton != null)
        {
            Debug.Log("Start button is assigned");
        }

        if (quitButton != null)
        {
            Debug.Log("Quit button is assigned");
        }

        if (optionsButton != null)
        {
            Debug.Log("Options button is assigned"); 
        }
    }
}
