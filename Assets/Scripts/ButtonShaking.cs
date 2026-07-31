using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonShaking : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler
{
    private RectTransform rectTransform;
    private Tween tween;
    private Sequence swingSequence;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

        swingSequence = DOTween.Sequence()
            .Append(rectTransform.DOLocalRotate(new Vector3(0f, 0f, 8f),0.4f).SetEase(Ease.InCubic))
            .Append(rectTransform.DOLocalRotate(new Vector3(0f, 0f, -8f),0.4f).SetEase(Ease.InOutSine))
            .Append(rectTransform.DOLocalRotate(new Vector3(0f, 0f, 0f), 0.4f).SetEase(Ease.InOutSine))
            .SetLoops(-1)
            .SetUpdate(true);

        //rectTransform.localRotation = Quaternion.Euler(0f, 0f, -15f);

        
        //tween=rectTransform.DOLocalRotate(new Vector3(0f, 0f, 15f), 0.5f, RotateMode.LocalAxisAdd)
        //    .SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);

        //Debug.Log("on");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        swingSequence.Kill();
        transform.rotation = Quaternion.identity;
        //transform.DORotate(new Vector3(0f, 0f, 0f),0f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        swingSequence.Kill();
        transform.rotation = Quaternion.identity;
    }

        
}
