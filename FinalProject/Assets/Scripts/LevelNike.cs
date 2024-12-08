using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelNike : MonoBehaviour
{
    [Header("Countdown UI")]
    public TMP_Text raceBeginsText;
    public TMP_Text countdownText;
    public TMP_Text stopwatchText;
    public TMP_Text hurdlesLeftText;

    [Header("Player and Game Settings")]
    public GameObject player;

    [Header("Level Music")]
    public AudioClip nikeMusic;

    [Header("Jump Sound")]
    public AudioClip jumpSound;

    [Header("References")]
    [SerializeField] private HurdleSpawner hurdleSpawner;

    public Animator NikeAnimatorCont;

    private bool isGameStarted = false;
    private float stopwatchTime = 0f;
    private Vector3 originalPosition;

    private void Start()
    {
        Debug.Log("LevelNike script started.");

        // Assign references if not set in the Inspector
        if (stopwatchText == null)
        {
            stopwatchText = GameObject.Find("StopwatchText")?.GetComponent<TMP_Text>();
            if (stopwatchText != null)
            {
                Debug.Log("StopwatchText assigned at runtime.");
            }
            else
            {
                Debug.LogError("StopwatchText is not assigned! Check object name.");
            }
        }

        if (nikeMusic != null)
        {
            AudioManager.instance.PlaySceneMusic(nikeMusic);
            Debug.Log("Playing Nike music.");
        }

        if (raceBeginsText == null || countdownText == null || player == null || hurdlesLeftText == null)
        {
            Debug.LogError("Critical references are missing! Check Inspector assignments.");
            return;
        }

        NikeAnimatorCont = player.GetComponent<Animator>();
        if (NikeAnimatorCont == null)
        {
            Debug.LogError("Animator component missing from player.");
        }
        player.SetActive(true);

        originalPosition = player.transform.position;
        raceBeginsText.text = "RACE BEGINS IN";


        StartCoroutine(StartCountdownAndGame());
    }

    private IEnumerator StartCountdownAndGame()
    {
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            Debug.Log($"Countdown: {i}");
            yield return new WaitForSeconds(1f);
        }

        countdownText.text = "Go!";
        Debug.Log("Race started!");
        yield return new WaitForSeconds(1f);

        raceBeginsText.text = "";
        countdownText.text = "";

        if (NikeAnimatorCont != null)
        {
            NikeAnimatorCont.SetBool("isRunning", true);
            Debug.Log("Player is running.");
        }

        if (hurdleSpawner != null)
        {
            hurdleSpawner.StartSpawningHurdles();
        }
        else
        {
            Debug.LogError("HurdleSpawner reference is missing!");
        }

        isGameStarted = true;
        UpdateHurdlesLeftText(hurdleSpawner.MaxHurdles); 
        UpdateStopwatchText(); 
    }

    private void Update()
    {
        if (isGameStarted)
        {
            stopwatchTime += Time.deltaTime;
            UpdateStopwatchText();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Space key pressed.");
                Jump();
            }
        }
    }

    private void Jump()
    {
        if (jumpSound != null)
        {
            AudioManager.instance.PlaySFX(jumpSound);
            Debug.Log("Jump sound played.");
        }
        else
        {
            Debug.LogWarning("Jump sound not assigned.");
        }
        StartCoroutine(JumpCoroutine());
    }

    private IEnumerator JumpCoroutine()
    {
        float jumpHeight = 2f; 
        float jumpDuration = 0.7f; 
        float elapsedTime = 0f;

        Vector3 startPosition = player.transform.position;
        Vector3 targetPosition = startPosition + new Vector3(0, jumpHeight, 0);

        // Jump Up
        while (elapsedTime < jumpDuration / 2)
        {
            float t = elapsedTime / (jumpDuration / 2);
            player.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0f;

        // Jump Down
        while (elapsedTime < jumpDuration / 2)
        {
            float t = elapsedTime / (jumpDuration / 2);
            player.transform.position = Vector3.Lerp(targetPosition, originalPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        player.transform.position = originalPosition;
        Debug.Log("Player landed.");
    }

    public void AddTime(float additionalTime)
{
    stopwatchTime += additionalTime;
    Debug.Log($"Added {additionalTime} seconds. New time: {stopwatchTime:F1}s");

    if (stopwatchText != null)
    {
        stopwatchText.text = $"Time: {stopwatchTime:F1}s";
        Debug.Log("Stopwatch UI updated.");
    }
    else
    {
        Debug.LogError("StopwatchText is not assigned in the UI.");
    }
}


    private void UpdateStopwatchText()
    {
        if (stopwatchText != null)
        {
            stopwatchText.text = $"Time: {stopwatchTime:F1}s";
        }
        else
        {
            Debug.LogError("stopwatchText is not assigned!");
        }
    }

    public void UpdateHurdlesLeftText(int hurdlesLeft)
    {
        if (hurdlesLeftText != null)
        {
            hurdlesLeftText.text = $"Hurdles Left: {hurdlesLeft}";
            Debug.Log($"Hurdles Left Updated: {hurdlesLeft}");
        }
        else
        {
            Debug.LogError("hurdlesLeftText is not assigned!");
        }

        CheckHurdlesLeft(hurdlesLeft); 
    }

    public void CheckHurdlesLeft(int hurdlesLeft)
{
    if (hurdlesLeft <= 0 && isGameStarted)
    {
        Debug.Log("All hurdles cleared! Transitioning to NikeWin scene.");
        isGameStarted = false; 

        if (NikeAnimatorCont != null)
        {
            NikeAnimatorCont.SetBool("isRunning", false);
        }

        StartCoroutine(TransitionToWinScene());
    }
}



    private IEnumerator TransitionToWinScene()
{
    yield return new WaitForSeconds(1f); 
    SceneManager.LoadScene("NikeWin");
}

}
