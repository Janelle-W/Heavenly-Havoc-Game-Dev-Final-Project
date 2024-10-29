using UnityEngine;
using TMPro; 
using System.Collections;

public class LevelNike : MonoBehaviour
{
    [Header("Countdown UI")]
    public TMP_Text raceBeginsText; 
    public TMP_Text countdownText;    
    public float countdownTime = 3.0f; 

    public TMP_Text stopwatchText; 

    [Header("Player and Game Settings")]
    public GameObject player; 

    [Header("Level Music")]
    public AudioClip nikeMusic;


    [Header("References")]
    [SerializeField] private HurdleSpawner hurdleSpawner; 
    [SerializeField] private float countdownDuration = 3f;

    public Animator NikeAnimatorCont;
    public float playerSpeed = 5f;

    private bool isGameStarted = false;

    private float stopwatchTime = 0f;
    private Vector3 originalPosition; 

    private void Start()
    {
        if (nikeMusic != null) // Check if the audio clip is assigned
    {
        AudioManager.instance.PlaySceneMusic(nikeMusic);
    }
    else
    {
        Debug.LogWarning("Nike music clip is not assigned!");
    }
        
        if (raceBeginsText == null || countdownText == null)
        {
            Debug.LogError("Race Begins Text or Countdown Text is not assigned in the Inspector!");
            return; 
        }

        NikeAnimatorCont = player.GetComponent<Animator>();
        player.SetActive(true);  

        
        originalPosition = player.transform.position;

        
        raceBeginsText.text = "RACE BEGINS IN";
        StartCoroutine(StartCountdownAndGame());  
    }

    private IEnumerator StartCountdownAndGame()
    {
        Debug.Log("Countdown started!");

        
        for (int i = (int)countdownTime; i > 0; i--)
        {
            countdownText.text = i.ToString();  
            Debug.Log($"Countdown: {i}"); 
            yield return new WaitForSeconds(1f); 
        }

        
        countdownText.text = "Go!";
        Debug.Log("Countdown finished, displaying 'Go'");
        yield return new WaitForSeconds(1f); 
        
        raceBeginsText.text = "";
        countdownText.text = ""; 

        NikeAnimatorCont.SetBool("isRunning", true);
        hurdleSpawner.StartSpawningHurdles();
        Debug.Log("Setting isRunning to true, starting running animation"); 
        isGameStarted = true; 
        stopwatchText.text = "Time: 0.0s"; 
    }

    private bool hasLoggedGameStarted = false; 
    /*private void Update()
    {
        if (isGameStarted)
        {
            // Log the game has started only once
            if (!hasLoggedGameStarted)
            {
                Debug.Log("Game has started!");
                hasLoggedGameStarted = true; // Set the flag to true
            }

            stopwatchTime += Time.deltaTime;
            stopwatchText.text = $"Time: {stopwatchTime:F1}s";

            // Jump movement
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        StartCoroutine(JumpCoroutine());
    }*/

    private void Update()
{
    if (isGameStarted)
    {
        
        if (!hasLoggedGameStarted)
        {
            Debug.Log("Game has started!");
            hasLoggedGameStarted = true; 
        }

        stopwatchTime += Time.deltaTime;
        stopwatchText.text = $"Time: {stopwatchTime:F1}s";
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump key pressed");  
            Jump();
        }
    }
}

private void Jump()
{
    Debug.Log("Jumping"); 
    StartCoroutine(JumpCoroutine());
}


    private IEnumerator JumpCoroutine()
    {
        float jumpHeight = 1f; 
        float jumpDuration = 0.5f; 
        float elapsedTime = 0f;

        Vector3 startPosition = player.transform.position; 
        Vector3 targetPosition = startPosition + new Vector3(0, jumpHeight, 0); 

        
        while (elapsedTime < jumpDuration / 2)
        {
            player.transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / (jumpDuration / 2)));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        
        elapsedTime = 0f;
        while (elapsedTime < jumpDuration / 2)
        {
            player.transform.position = Vector3.Lerp(targetPosition, originalPosition, (elapsedTime / (jumpDuration / 2)));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

       
        player.transform.position = originalPosition;
    }
}




