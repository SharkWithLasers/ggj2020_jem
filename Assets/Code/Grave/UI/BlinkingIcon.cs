using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlinkingIcon : MonoBehaviour
{
    [SerializeField]
    private Color toggleColor;

    [SerializeField]
    private float toggleScaleRatio;

    [SerializeField]
    private float duration;
    // Start is called before the first frame update
    void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.DOColor(toggleColor, duration).SetLoops(-1, LoopType.Yoyo);

        var toggleScale = transform.localScale * toggleScaleRatio;
        transform.DOScale(toggleScale, duration).SetLoops(-1, LoopType.Yoyo);
    }

}
