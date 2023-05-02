using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RoomTransition : MonoBehaviour
{
    [SerializeField] private bool bounceOnAwake;
    [SerializeField] private float transitionTimeUp;
    [SerializeField] private float transitionTimeDown;
    [SerializeField] private float yPositionUp;
    [SerializeField] private float yPositionDown;
    
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        if(bounceOnAwake)
            RoomFadeOut();
    }

    public void RoomFadeOut()
    {
        _rectTransform.transform.localPosition = gameObject.transform.localPosition;
        _rectTransform.DOAnchorPosY(yPositionDown, transitionTimeDown).SetEase(Ease.OutQuint).OnComplete(() => _rectTransform.DOAnchorPosY(yPositionUp, transitionTimeUp).SetEase(Ease.InOutQuad));
    }
}