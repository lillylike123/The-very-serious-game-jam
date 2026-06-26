using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Sources")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("Clips")]
    public AudioClip gameBGM;
    public AudioClip buttonSound;
    private bool soundEnabled = true;

    void Start()
    {
        bool music =
            PlayerPrefs.GetInt("Music", 1) == 1;

        bool sound =
            PlayerPrefs.GetInt("Sound", 1) == 1;

        SetMusic(music);
        SetSound(sound);
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        bgmSource.clip = gameBGM;
        bgmSource.loop = true;
        bgmSource.Play();
    }

    public void PlayButtonSound()
    {
        if (!soundEnabled)
            return;

        sfxSource.PlayOneShot(buttonSound);
    }

    public void SetMusic(bool enabled)
    {
        PlayerPrefs.SetInt("Music", enabled ? 1 : 0);
        PlayerPrefs.Save();

        if (enabled)
            bgmSource.UnPause();
        else
            bgmSource.Pause();
    }

    public void SetSound(bool enabled)
    {
        soundEnabled = enabled;
    }

}


