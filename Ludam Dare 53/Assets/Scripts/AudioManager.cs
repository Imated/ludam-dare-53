using DG.Tweening;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [SerializeField] private AudioClip mainMenuClip;
    [SerializeField] private AudioClip gameplayClip;
    [SerializeField] private AudioClip hoverClip;
    [SerializeField] private AudioClip clickClip;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    private float _defaultVolume;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        musicSource.clip = mainMenuClip;
        _defaultVolume = musicSource.volume;
        musicSource.Play();
        instance = this;
    }

    public void PlayGame()
    {
        musicSource.DOFade(0f, 0.5f).OnComplete(() =>
        {
            musicSource.clip = gameplayClip;
            musicSource.Play();
            musicSource.DOFade(_defaultVolume, 0.5f);
        });
    }

    public void PlayHoverSfx()
    {
        sfxSource.clip = hoverClip;
        sfxSource.Play();
    }

    public void PlayClickSfx()
    {
        sfxSource.clip = clickClip;
        sfxSource.Play();
    }
}
