/*using UnityEngine;
using TMPro; 
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelNike : MonoBehaviour
{
    [Header("Countdown UI")]
    public TMP_Text raceBeginsText;
    public TMP_Text countdownText;    
    public float countdownTime = 3.0f; 

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
    [SerializeField] private float countdownDuration = 3f;

    public Animator NikeAnimatorCont;
    public float playerSpeed = 5f;

    private bool isGameStarted = false;
    private bool hasLoggedGameStarted = false;
    private float stopwatchTime = 0f;
    private Vector3 originalPosition;

    private void Start()
    {
        if (nikeMusic != null)
        {
            AudioManager.instance.PlaySceneMusic(nikeMusic);
        }

        if (raceBeginsText == null || countdownText == null)
        {
            Debug.LogError("Race Begins or Countdown Text not assigned in Inspector!");
            return; 
        }

        if (player == null)
        {
            Debug.LogError("Player not assigned in Inspector!");
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
        for (int i = (int)countdownTime; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countdownText.text = "Go!";
        yield return new WaitForSeconds(1f);

        raceBeginsText.text = "";
        countdownText.text = "";

        NikeAnimatorCont.SetBool("isRunning", true);
        hurdleSpawner.StartSpawningHurdles();
        isGameStarted = true;
        stopwatchText.text = "Time: 0.0s";
        UpdateHurdlesLeftText(25);
    }

    private void Update()
    {
        if (isGameStarted)
        {
            if (!hasLoggedGameStarted)
            {
                hasLoggedGameStarted = true;
            }

            stopwatchTime += Time.deltaTime;
            if (stopwatchText != null)
                stopwatchText.text = $"Time: {stopwatchTime:F1}s";

            if (stopwatchTime > 65f)
            {
                EndGame(false); // Time exceeded, lose
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }

    private void Jump()
    {
        if (jumpSound != null)
        {
            AudioManager.instance.PlaySFX(jumpSound);
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

        while (elapsedTime < jumpDuration / 2)
        {
            float t = elapsedTime / (jumpDuration / 2);
            player.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        elapsedTime = 0f;
        while (elapsedTime < jumpDuration / 2)
        {
            float t = elapsedTime / (jumpDuration / 2);
            player.transform.position = Vector3.Lerp(targetPosition, originalPosition, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        player.transform.position = originalPosition;
    }

    public void UpdateHurdlesLeftText(int hurdlesLeft)
    {
        if (hurdlesLeftText != null)
        {
            hurdlesLeftText.text = $"Hurdles Left: {hurdlesLeft}";
        }

        if (hurdlesLeft <= 0 && isGameStarted)
        {
            EndGame(true); // Win
        }
    }

    private void EndGame(bool hasWon)
    {
        if (!isGameStarted)
            return;

        isGameStarted = false;
        NikeAnimatorCont.SetBool("isRunning", false);

        if (hasWon && stopwatchTime <= 65f)
        {
            AudioManager.instance.PlayWinSFX();
            SceneManager.LoadScene("WinScene");
        }
        else
        {
            AudioManager.instance.PlayLoseSFX();
            SceneManager.LoadScene("LoserScene");
        }
    }

    public void AddTime(float additionalTime)
{
    stopwatchTime += additionalTime;
    Debug.Log($"Added {additionalTime} seconds. New time: {stopwatchTime:F1}s");
    if (stopwatchText != null)
    {
        stopwatchText.text = $"Time: {stopwatchTime:F1}s";
    }
}


}*/

using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelNike : MonoBehaviour
{
    [Header("Countdown UI")]
    public TMP_Text raceBeginsText;  // Assign in Inspector
    public TMP_Text countdownText;  // Assign in Inspector
    public TMP_Text stopwatchText;  // Assign in Inspector
    public TMP_Text hurdlesLeftText; // Text to display remaining hurdles

    [Header("Player and Game Settings")]
    public GameObject player;       // Assign in Inspector

    [Header("Level Music")]
    public AudioClip nikeMusic;

    [Header("Jump Sound")]
    public AudioClip jumpSound;

    [Header("References")]
    [SerializeField] private HurdleSpawner hurdleSpawner;  // Assign in Inspector

    public Animator NikeAnimatorCont;

    private bool isGameStarted = false;
    private float stopwatchTime = 0f;

    private void Start()
    {
        Debug.Log("LevelNike script started.");

        if (stopwatchText == null)
        {
            // Try finding stopwatchText if not assigned
            stopwatchText = GameObject.Find("StopwatchText")?.GetComponent<TMP_Text>();
            if (stopwatchText != null)
            {
                Debug.Log("StopwatchText found and assigned at runtime.");
            }
            else
            {
                Debug.LogError("StopwatchText is not assigned! Check Inspector or object name.");
            }
        }

        if (nikeMusic != null)
        {
            AudioManager.instance.PlaySceneMusic(nikeMusic);
        }

        if (raceBeginsText == null || countdownText == null || player == null || hurdlesLeftText == null)
        {
            Debug.LogError("Critical references are missing! Check Inspector assignments.");
            return;
        }

        NikeAnimatorCont = player.GetComponent<Animator>();
        player.SetActive(true);

        raceBeginsText.text = "RACE BEGINS IN";
        StartCoroutine(StartCountdownAndGame());
    }

    private IEnumerator StartCountdownAndGame()
    {
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countdownText.text = "Go!";
        yield return new WaitForSeconds(1f);

        raceBeginsText.text = "";
        countdownText.text = "";

        NikeAnimatorCont.SetBool("isRunning", true);
        hurdleSpawner.StartSpawningHurdles();
        isGameStarted = true;
        stopwatchText.text = "Time: 0.0s";
        UpdateHurdlesLeftText(hurdleSpawner.MaxHurdles);  // Initialize hurdles left text
    }

    private void Update()
    {
        if (isGameStarted)
        {
            stopwatchTime += Time.deltaTime;
            UpdateStopwatchText();
        }
    }

    public void AddTime(float additionalTime)
    {
        stopwatchTime += additionalTime;
        Debug.Log($"Added {additionalTime} seconds. New time: {stopwatchTime:F1}s");
        UpdateStopwatchText();
    }

    private void UpdateStopwatchText()
    {
        if (stopwatchText == null)
        {
            Debug.LogError("stopwatchText is not assigned!");
        }
        else
        {
            stopwatchText.text = $"Time: {stopwatchTime:F1}s";
        }
    }

    public void UpdateHurdlesLeftText(int hurdlesLeft)
    {
        if (hurdlesLeftText != null)
        {
            hurdlesLeftText.text = $"Hurdles Left: {hurdlesLeft}";
        }

        if (hurdlesLeft <= 0 && isGameStarted)
        {
            NikeAnimatorCont.SetBool("isRunning", false); // Set animation to idle
            EndGame(true); // Win condition
        }
    }

    private void EndGame(bool hasWon)
    {
        if (!isGameStarted)
            return;

        isGameStarted = false;
        NikeAnimatorCont.SetBool("isRunning", false);

        if (hasWon)
        {
            SceneManager.LoadScene("WinScene");
        }
        else
        {
            SceneManager.LoadScene("LoserScene");
        }
    }
}
