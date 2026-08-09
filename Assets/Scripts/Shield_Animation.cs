using UnityEngine;

public class Shield_Animation : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public RectTransform Rtransform;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        Rtransform = GetComponent<RectTransform>();
    }
}
