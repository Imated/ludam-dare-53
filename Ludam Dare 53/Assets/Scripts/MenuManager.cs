using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private float transitionDuration;
    [SerializeField] private Image fadeImage;

    private void Awake()
    {
        fadeImage.DOFade(0f, 0f);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(fadeImage.gameObject);
    }

    public void PlayGame()
    {
        fadeImage.DOFade(1f, transitionDuration).OnComplete(() =>
        {
            SceneManager.LoadScene(1);
            fadeImage.DOFade(0f, transitionDuration);
        });
    }
}
