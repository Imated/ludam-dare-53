using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private float transitionDuration;
    [SerializeField] private Image fadeImage;

    public void PlayGame()
    {
        fadeImage.gameObject.SetActive(true);
        StartCoroutine(FadeTransition());
    }

    private IEnumerator FadeTransition()
    {
        for(int i = 0; i<100; i++)
        {
            var tempColor = fadeImage.color;
            tempColor.a += 0.01f;
            fadeImage.color = tempColor;
            yield return new WaitForSeconds(transitionDuration);
        }
        SceneManager.LoadScene(1);
    }
}
