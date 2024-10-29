using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Divinities : MonoBehaviour
{
    [Header("Scene Management")]
    [SerializeField] private string mainMenuSceneName = "MainMenu";
    [SerializeField] private string optionsSceneName = "OptionsScene";
    [SerializeField] private string nikeIntroSceneName = "LvlNikeIntro";

    [SerializeField] private string gaiaIntroSceneName = "LvlGaiaIntro";

    [SerializeField] private string medeaIntroSceneName = "LvlMedeaIntro";

    [Header("UI References")]

    [SerializeField] private GameObject nikeButton;

    [SerializeField] private GameObject gaiaButton;

    [SerializeField] private GameObject medeaButton;

    [SerializeField] private GameObject mainMenuButton;

    [SerializeField] private GameObject optionsButton;


    public void OpenLvlNike()
    {
        SceneManager.LoadScene(nikeIntroSceneName); 
    }

    public void OpenLvlGaia()
    {
        //SceneManager.LoadScene(gaiaIntroSceneName);
        Debug.Log("Attempting to load scene: " + gaiaIntroSceneName);
        SceneManager.LoadScene(gaiaIntroSceneName); 
    }

    public void OpenLvlMedea()
    {
        SceneManager.LoadScene(medeaIntroSceneName); 
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName); 
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene(optionsSceneName); 
    }


    private void Start()
    {

        if (nikeButton != null)
        {
            Debug.Log("Options button is assigned"); 
        }

        if (mainMenuButton != null)
        {
            Debug.Log("MainMenu button is assigned"); 
        }

        if (optionsButton != null)
        {
            Debug.Log("Options button is assigned"); 
        }

    }
}
