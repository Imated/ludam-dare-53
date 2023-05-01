using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Interactable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite highlightedSprite;
    [SerializeField] private Sprite pressedSprite;
    [Space]
    public UnityEvent onClicked;

    private bool hovering = false;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
        _image.sprite = highlightedSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
        _image.sprite = normalSprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            _image.sprite = pressedSprite;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            _image.sprite = highlightedSprite;
            onClicked?.Invoke();
        }
    }
}
