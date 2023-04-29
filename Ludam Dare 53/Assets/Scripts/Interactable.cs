using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Interactable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite highlightedSprite;
    [Space]
    public UnityEvent onClicked;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.sprite = highlightedSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.sprite = normalSprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _image.sprite = normalSprite;
        onClicked?.Invoke();
    }
}
