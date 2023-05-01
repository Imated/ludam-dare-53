using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [SerializeField] private AudioClip mainMenuClip;
    [SerializeField] private AudioClip gameplayClip;
    [SerializeField] private AudioClip hoverClip;
    [SerializeField] private AudioClip purchaseClip;
    [SerializeField] private AudioClip bedClip;
    [SerializeField] private AudioClip clickClip;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    private float _defaultVolume;
    private bool _isMute;
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        musicSource.clip = mainMenuClip;
        _defaultVolume = musicSource.volume;
        musicSource.Play();
        instance = this;
        SceneManager.sceneLoaded += (scene, mode) => { AudioListener.volume = _isMute ? 0 : 1; };
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
    
    public void PlayBedSfx()
    {
        sfxSource.clip = bedClip;
        sfxSource.Play();
    }
    
    public void PlayPurchaseSfx()
    {
        sfxSource.clip = purchaseClip;
        sfxSource.Play();
    }

    public void ToggleMute()
    {
        if (_isMute)
        {
            AudioListener.volume = 1;
            _isMute = false;
        }
        else
        {
            AudioListener.volume = 0;
            _isMute = true;
        }
    }
}
