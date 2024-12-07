using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    [Header("Scene Management")]
    [SerializeField] private string mainMenuSceneName = "MainMenu";
    [SerializeField] private string divineSceneName = "DivinitiesScene";

    private void Start()
    {
        Debug.Log("Options scene loaded.");
    }

    public void OpenMainMenu()
{
    SceneManager.LoadScene("MainMenu"); 
}


    public void OpenDivinitiesScene()
    {
        SceneManager.LoadScene(divineSceneName);
    }
}