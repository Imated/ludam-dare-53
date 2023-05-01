using System;
using DG.Tweening;
using UnityEngine;

public class MoveEffect : MonoBehaviour
{
    [SerializeField] private float positionMultiplier = 1.05f;
    [SerializeField] private float duration = 0.75f;

    private void Awake()
    {
        transform.GetComponent<RectTransform>()
            .DOAnchorPosX(transform.GetComponent<RectTransform>().anchoredPosition.x * positionMultiplier, duration)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
