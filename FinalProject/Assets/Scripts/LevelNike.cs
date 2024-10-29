/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelNikeManager : MonoBehaviour
{
    [Header("Countdown UI")]
    public Text countdownText;  // Reference to the UI Text for countdown
    public float countdownTime = 3.0f;  // Countdown time from 3 to "Go!"

    [Header("Player and Game Settings")]
    public GameObject player;  // Reference to player object for movement
    public float playerSpeed = 5f;

    private bool isGameStarted = false;

    private void Start()
    {
        player.SetActive(false);  // Disable player movement initially
        StartCoroutine(StartCountdownAndGame());
    }

    private IEnumerator StartCountdownAndGame()
    {
        // Countdown from 3 to 1
        for (int i = (int)countdownTime; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        // Show "Go!" before enabling gameplay
        countdownText.text = "Go!";
        yield return new WaitForSeconds(1f);

        countdownText.text = "";  // Clear the text
        isGameStarted = true;     // Mark game as started
        player.SetActive(true);   // Enable player movement
    }

    private void Update()
    {
        if (isGameStarted)
        {
            // Add player movement code here; for example, simple forward movement
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Jump or any other player action
                Debug.Log("Player Jumped!");
            }

            // Simple forward movement (e.g., sidescroller setup)
            player.transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }
    }
}*/

/*using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class LevelNike : MonoBehaviour
{
    [Header("Countdown UI")]
    public TMP_Text countdownText;  // Reference to the UI Text for countdown
    public float countdownTime = 3.0f;  // Countdown time from 3 to "Go!"

    [Header("Player and Game Settings")]
    public GameObject player;  // Reference to player object for movement
    public float playerSpeed = 5f;

    private bool isGameStarted = false;

    private void Start()
    {
        // Ensure the countdown text is assigned
        if (countdownText == null)
        {
            Debug.LogError("Countdown Text is not assigned in the Inspector!");
            return; // Exit if countdownText is null
        }

        player.SetActive(false);  // Disable player movement initially
        StartCoroutine(StartCountdownAndGame());  // Start the countdown coroutine
    }

    private IEnumerator StartCountdownAndGame()
    {
        Debug.Log("Countdown started!"); // Log for debugging

        // Countdown from 3 to 1
        for (int i = (int)countdownTime; i > 0; i--)
        {
            countdownText.text = i.ToString();  // Set the countdown text
            Debug.Log($"Countdown: {i}"); // Log current countdown value
            yield return new WaitForSeconds(1f);  // Wait for 1 second
        }

        // Show "Go!" before enabling gameplay
        countdownText.text = "Go!";
        Debug.Log("Countdown finished, displaying 'Go'");
        yield return new WaitForSeconds(1f); // Pause for a moment to show "Go!"
        countdownText.text = ""; // Clear the text after the countdown

        isGameStarted = true; // Mark game as started
        player.SetActive(true); // Enable player movement
    }

    private void Update()
    {
        if (isGameStarted)
        {
            // Add player movement code here; for example, simple forward movement
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Jump or any other player action
                Debug.Log("Player Jumped!");
            }

            // Simple forward movement (e.g., sidescroller setup)
            player.transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }
    }
}*/

/*using UnityEngine;
using TMPro; // Include the TextMeshPro namespace
using System.Collections;

public class LevelNike : MonoBehaviour
{
    [Header("Countdown UI")]
    public TMP_Text raceBeginsText;  // Reference to the TMP Text for "RACE BEGINS IN"
    public TMP_Text countdownText;    // Reference to the TMP Text for countdown
    public float countdownTime = 3.0f; // Countdown time from 3 to "Go!"

    [Header("Player and Game Settings")]
    public GameObject player; // Reference to player object for movement

    [Header("References")]
    [SerializeField] private HurdleSpawner hurdleSpawner; // Reference to your hurdle spawner
    [SerializeField] private float countdownDuration = 3f;

    //public Animator playerAnimator;
    public Animator NikeAnimatorCont;
    public float playerSpeed = 5f;

    private bool isGameStarted = false;

    private void Start()
    {
        // Ensure the countdown text is assigned
        if (raceBeginsText == null || countdownText == null)
        {
            Debug.LogError("Race Begins Text or Countdown Text is not assigned in the Inspector!");
            return; // Exit if any text is null
        }

        //playerAnimator 
        NikeAnimatorCont = player.GetComponent<Animator>();

        // Enable the player to be visible during the countdown
        player.SetActive(true);  // Ensure the player is active and visible

        // Set the race begins text
        raceBeginsText.text = "RACE BEGINS IN";
        StartCoroutine(StartCountdownAndGame());  // Start the countdown coroutine
    }

    private IEnumerator StartCountdownAndGame()
    {
        Debug.Log("Countdown started!"); // Log for debugging

        // Countdown from 3 to 1
        for (int i = (int)countdownTime; i > 0; i--)
        {
            countdownText.text = i.ToString();  // Set the countdown text
            Debug.Log($"Countdown: {i}"); // Log current countdown value
            yield return new WaitForSeconds(1f); // Wait for 1 second
        }

        // Show "Go!" before enabling gameplay
        countdownText.text = "Go!";
        Debug.Log("Countdown finished, displaying 'Go'");
        yield return new WaitForSeconds(1f); // Pause for a moment to show "Go!"
        
        raceBeginsText.text = "";
        countdownText.text = ""; // Clear the text after the countdown

        //playerAnimator
        NikeAnimatorCont.SetBool("isRunning", true);
        hurdleSpawner.StartSpawningHurdles();
        Debug.Log("Setting isRunning to true, starting running animation"); // Log to confirm animation transition
        isGameStarted = true; // Mark game as started
    }

    private bool hasLoggedGameStarted = false; // New flag to track logging

private void Update()
{
    if (isGameStarted)
    {
        // Log the game has started only once
        if (!hasLoggedGameStarted)
        {
            Debug.Log("Game has started!");
            hasLoggedGameStarted = true; // Set the flag to true
        }

        // Player movement code
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Player Jumped!");
        }

        // Simple forward movement
        //player.transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
    }
}

}*/

/*using UnityEngine;
using TMPro;
using System.Collections;

public class LevelNike : MonoBehaviour
{
    [Header("Countdown UI")]
    public TMP_Text raceBeginsText;  // Reference to the TMP Text for "RACE BEGINS IN"
    public TMP_Text countdownText;    // Reference to the TMP Text for countdown
    public TMP_Text stopwatchText;    // Reference to a new TMP Text for stopwatch
    public float countdownTime = 3.0f; // Countdown time from 3 to "Go!"

    [Header("Player and Game Settings")]
    public GameObject player; // Reference to player object for movement

    [Header("References")]
    [SerializeField] private HurdleSpawner hurdleSpawner; // Reference to your hurdle spawner
    [SerializeField] private float countdownDuration = 3f;

    public Animator NikeAnimatorCont;
    public float playerSpeed = 5f;

    private bool isGameStarted = false;
    private float stopwatchTime = 0f;  // Variable to track the stopwatch time

    private void Start()
    {
        if (raceBeginsText == null || countdownText == null || stopwatchText == null)
        {
            Debug.LogError("UI elements are not assigned in the Inspector!");
            return;
        }

        NikeAnimatorCont = player.GetComponent<Animator>();
        player.SetActive(true);

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
        isGameStarted = true;

        stopwatchText.text = "Time: 0.0s";  // Initialize stopwatch display
        Debug.Log("Game has started!");
    }

    private bool hasLoggedGameStarted = false;

    private void Update()
    {
        if (isGameStarted)
        {
            if (!hasLoggedGameStarted)
            {
                Debug.Log("Game has started!");
                hasLoggedGameStarted = true;
            }

            // Update stopwatch time
            stopwatchTime += Time.deltaTime;
            stopwatchText.text = $"Time: {stopwatchTime:F1}s"; // Display stopwatch to one decimal point

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Player Jumped!");
            }
        }
    }
}

*/


using UnityEngine;
using TMPro; // Include the TextMeshPro namespace
using System.Collections;

public class LevelNike : MonoBehaviour
{
    [Header("Countdown UI")]
    public TMP_Text raceBeginsText;  // Reference to the TMP Text for "RACE BEGINS IN"
    public TMP_Text countdownText;    // Reference to the TMP Text for countdown
    public float countdownTime = 3.0f; // Countdown time from 3 to "Go!"

    [Header("Player and Game Settings")]
    public GameObject player; // Reference to player object for movement

    [Header("References")]
    [SerializeField] private HurdleSpawner hurdleSpawner; // Reference to your hurdle spawner
    [SerializeField] private float countdownDuration = 3f;

    public Animator NikeAnimatorCont;
    public float playerSpeed = 5f;

    private bool isGameStarted = false;
    private Vector3 originalPosition; // To store the original position of the player

    private void Start()
    {
        // Ensure the countdown text is assigned
        if (raceBeginsText == null || countdownText == null)
        {
            Debug.LogError("Race Begins Text or Countdown Text is not assigned in the Inspector!");
            return; // Exit if any text is null
        }

        NikeAnimatorCont = player.GetComponent<Animator>();
        player.SetActive(true);  // Ensure the player is active and visible

        // Store the original position of the player
        originalPosition = player.transform.position;

        // Set the race begins text
        raceBeginsText.text = "RACE BEGINS IN";
        StartCoroutine(StartCountdownAndGame());  // Start the countdown coroutine
    }

    private IEnumerator StartCountdownAndGame()
    {
        Debug.Log("Countdown started!");

        // Countdown from 3 to 1
        for (int i = (int)countdownTime; i > 0; i--)
        {
            countdownText.text = i.ToString();  // Set the countdown text
            Debug.Log($"Countdown: {i}"); // Log current countdown value
            yield return new WaitForSeconds(1f); // Wait for 1 second
        }

        // Show "Go!" before enabling gameplay
        countdownText.text = "Go!";
        Debug.Log("Countdown finished, displaying 'Go'");
        yield return new WaitForSeconds(1f); // Pause for a moment to show "Go!"
        
        raceBeginsText.text = "";
        countdownText.text = ""; // Clear the text after the countdown

        NikeAnimatorCont.SetBool("isRunning", true);
        hurdleSpawner.StartSpawningHurdles();
        Debug.Log("Setting isRunning to true, starting running animation"); // Log to confirm animation transition
        isGameStarted = true; // Mark game as started
    }

    private bool hasLoggedGameStarted = false; // New flag to track logging

    private void Update()
    {
        if (isGameStarted)
        {
            // Log the game has started only once
            if (!hasLoggedGameStarted)
            {
                Debug.Log("Game has started!");
                hasLoggedGameStarted = true; // Set the flag to true
            }

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
    }

    private IEnumerator JumpCoroutine()
    {
        float jumpHeight = 1f; // How high the character jumps
        float jumpDuration = 0.5f; // Duration of the jump
        float elapsedTime = 0f;

        Vector3 startPosition = player.transform.position; // Starting position
        Vector3 targetPosition = startPosition + new Vector3(0, jumpHeight, 0); // Target position

        // Jump up
        while (elapsedTime < jumpDuration / 2)
        {
            player.transform.position = Vector3.Lerp(startPosition, targetPosition, (elapsedTime / (jumpDuration / 2)));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Return down
        elapsedTime = 0f; // Reset elapsed time
        while (elapsedTime < jumpDuration / 2)
        {
            player.transform.position = Vector3.Lerp(targetPosition, originalPosition, (elapsedTime / (jumpDuration / 2)));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the player ends up at the original position
        player.transform.position = originalPosition;
    }
}
