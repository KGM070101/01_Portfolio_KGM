using DG.Tweening;
using UnityEngine;

public class Shield_Animation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public RectTransform Rtransform;
    public DOTween DOTween;
    public Sequence Seq;

    private Color invisible = Color.white;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Rtransform = GetComponent<RectTransform>();
    }

    public void Blink()
    {
        Seq = DOTween.Sequence().
            Append(spriteRenderer.DOFade(0.5f, 0.25f)).
            Append(spriteRenderer.DOFade(1.0f, 0.25f)).
            Append(spriteRenderer.DOFade(0.5f, 0.25f)).
            Append(spriteRenderer.DOFade(1.0f, 0.25f)).
            Append(spriteRenderer.DOFade(0.5f, 0.25f)).
            Append(spriteRenderer.DOFade(1.0f, 0.20f));
    }

}
