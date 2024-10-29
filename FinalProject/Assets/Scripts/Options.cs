using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    [Header("Scene Management")]
    [SerializeField] private string mainMenuSceneName = "MainMenu";
    [SerializeField] private string divineSceneName = "DivinitiesScene";

    [Header("UI References")]

    [SerializeField] private GameObject mainMenuButton;

    [SerializeField] private GameObject divineButton;


    public void OpenMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName); 
    }

    public void OpenDivinitiesScene()
    {
        SceneManager.LoadScene(divineSceneName); 
    }


    private void Start()
    {

        if (mainMenuButton != null)
        {
            Debug.Log("MainMenu button is assigned"); 
        }

        if (divineButton != null)
        {
            Debug.Log("Divine button is assigned"); 
        }
    }
}
