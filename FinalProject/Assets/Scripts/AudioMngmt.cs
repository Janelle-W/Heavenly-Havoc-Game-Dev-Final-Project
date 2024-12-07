using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource; // Main source for background music
    [SerializeField] private AudioSource sfxSource;   // Main source for sound effects

    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer audioMixer;  // Reference to the AudioMixer

    [Header("Music Clips")]
    [SerializeField] public AudioClip mainMenuMusic;
    [SerializeField] private AudioClip optionsMenuMusic;
    [SerializeField] private AudioClip nikeLevelMusic;

    [Header("Scene SFX")]
    [SerializeField] private AudioClip winSFX;
    [SerializeField] private AudioClip loseSFX;

    private void Awake()
{
    if (instance == null)
    {
        instance = this;
        DontDestroyOnLoad(gameObject); // Persist AudioManager across scenes
        InitializeAudioSources();     // Ensure AudioSources are initialized
        Debug.Log("AudioManager initialized and marked as persistent.");
    }
    else if (instance != this)
    {
        Debug.LogWarning("Duplicate AudioManager found and destroyed.");
        Destroy(gameObject); // Destroy any duplicates
    }
}



    private void InitializeAudioSources()
{
    if (musicSource == null)
    {
        Debug.LogWarning("MusicSource is null. Adding new AudioSource for music.");
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
    }

    if (sfxSource == null)
    {
        Debug.LogWarning("SFXSource is null. Adding new AudioSource for SFX.");
        sfxSource = gameObject.AddComponent<AudioSource>();
    }
}


    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene-loaded events
    }

    private void OnDestroy()
{
    Debug.Log($"AudioManager instance is being destroyed! Scene: {SceneManager.GetActiveScene().name}");
}


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"Scene loaded: {scene.name}");
        PlayMusicForScene(scene.name);
    }

    public void PlaySceneMusic(AudioClip clip)
{
    if (clip == null)
    {
        Debug.LogWarning("Clip is null. No music will be played.");
        return;
    }

    if (musicSource == null)
    {
        Debug.LogError("MusicSource is null. Reinitializing AudioSources.");
        InitializeAudioSources();
    }

    // Check if the same clip is already playing
    if (musicSource.clip == clip && musicSource.isPlaying)
    {
        Debug.Log("The same music is already playing. No need to restart.");
        return; // Prevent restarting the same music
    }

    musicSource.Stop();
    musicSource.clip = clip;
    musicSource.Play();
    Debug.Log($"Playing new music: {clip.name}");
}


    public void PlaySFX(AudioClip clip)
    {
        if (sfxSource != null && clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("SFXSource or Clip is null.");
        }
    }

    public void PlayWinSFX()
    {
        PlaySFX(winSFX);
    }

    public void PlayLoseSFX()
    {
        PlaySFX(loseSFX);
    }

    private void PlayMusicForScene(string sceneName)
{
    AudioClip clipToPlay = null;

    switch (sceneName)
    {
        case "MainMenu":
            clipToPlay = mainMenuMusic;
            break;
        case "OptionsScene":
            clipToPlay = optionsMenuMusic;
            break;
        case "NikeScene":
            clipToPlay = nikeLevelMusic;
            break;
        default:
            Debug.LogWarning($"No music assigned for scene: {sceneName}");
            return;
    }

    PlaySceneMusic(clipToPlay);
}


    public void SetMasterVolume(float volume)
    {
        if (audioMixer != null)
        {
            audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        }
        else
        {
            Debug.LogWarning("Audio Mixer not assigned!");
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (audioMixer != null)
        {
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        }
        else
        {
            Debug.LogWarning("Audio Mixer not assigned!");
        }
    }

    public void SetSFXVolume(float volume)
    {
        if (audioMixer != null)
        {
            audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        }
        else
        {
            Debug.LogWarning("Audio Mixer not assigned!");
        }
    }
}
