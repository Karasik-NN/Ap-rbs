using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Background Music")]
    public AudioSource musicSource;
    public AudioClip backgroundMusic;

    [Header("Armor Sounds")]
    public AudioSource sfxSource;
    public AudioClip equipSound;
    public AudioClip unequipSound;

    [Header("UI Sounds")]
    public AudioClip clickSound;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlayEquip()
    {
        if (equipSound != null) sfxSource.PlayOneShot(equipSound);
    }
    public void PlayUnequip()
    {
        if (unequipSound != null) sfxSource.PlayOneShot(unequipSound);
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null) sfxSource.PlayOneShot(clip);
    }
    public void PlayClick()
    {
    if (clickSound != null) 
        sfxSource.PlayOneShot(clickSound);
}
}