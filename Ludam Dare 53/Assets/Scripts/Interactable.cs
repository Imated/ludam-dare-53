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
    private bool _canClick = true;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovering = true;
        AudioManager.instance.PlayHoverSfx();
        _image.sprite = highlightedSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovering = false;
        _image.sprite = normalSprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && _canClick)
        {
            _image.sprite = pressedSprite;
            AudioManager.instance.PlayClickSfx();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left && hovering && _canClick)
        {
            _image.sprite = normalSprite;
            onClicked?.Invoke();
            _canClick = false;
            Invoke(nameof(CanClick), 1f);
        }
    }

    private void CanClick()
    {
        _canClick = true;
    }
}
