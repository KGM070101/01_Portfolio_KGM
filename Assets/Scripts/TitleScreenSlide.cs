using DG.Tweening;
using UnityEngine;

public class TitleScreenSlide : MonoBehaviour
{
    public Transform TargetPos;
    private float slideDuration = 0.3f;
    private Vector3 startPos;

    private void Start()
    {
        startPos = TargetPos.position + new Vector3(19.2f, 0f, 0f);
        transform.position = startPos;
    }

    public void SlideScreen()
    {
        transform.DOMoveX(TargetPos.position.x, slideDuration)
            .SetUpdate(true)
            .SetEase(Ease.InSine);
    }

    public void BackScreen()
    {
        transform.DOMoveX(startPos.x, slideDuration)
            .SetUpdate(true)
            .SetEase(Ease.InSine);
    }
}
