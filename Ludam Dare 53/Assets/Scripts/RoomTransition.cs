using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RoomTransition : MonoBehaviour
{
    [SerializeField] private float transitionTimeUp;
    [SerializeField] private float transitionTimeDown;
    [SerializeField] private float yPositionUp;
    [SerializeField] private float yPositionDown;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void RoomFadeOut()
    {
        rectTransform.transform.localPosition = gameObject.transform.localPosition;
        rectTransform.DOAnchorPosY(yPositionDown, transitionTimeDown).SetEase(Ease.OutQuint).OnComplete(() => rectTransform.DOAnchorPosY(yPositionUp, transitionTimeUp).SetEase(Ease.InOutQuad));
    }
}
