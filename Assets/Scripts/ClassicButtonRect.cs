using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClassicButtonRect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] GameObject button;

    private SFX_Manager sfx;

    private Sequence swingSequence;
    private Vector2 OriginalScale;
    

    private void Awake()
    {
        //rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        sfx = FindFirstObjectByType<SFX_Manager>();
        OriginalScale = button.transform.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

        swingSequence = DOTween.Sequence()
            .Append(button.transform.DOLocalRotate
            (new Vector3(0f, 0f, 8f), 0.4f).SetEase(Ease.InCubic))
            .Append(button.transform.DOLocalRotate
            (new Vector3(0f, 0f, -8f), 0.4f).SetEase(Ease.InOutSine))
            .Append(button.transform.DOLocalRotate
            (new Vector3(0f, 0f, 0f), 0.4f).SetEase(Ease.InOutSine))
            .SetLoops(-1)
            .SetUpdate(true);

        sfx.Button_Hover();
        button.transform.localScale = OriginalScale * 1.1f;

        //rectTransform.localRotation = Quaternion.Euler(0f, 0f, -15f);


        //tween=rectTransform.DOLocalRotate(new Vector3(0f, 0f, 15f), 0.5f, RotateMode.LocalAxisAdd)
        //    .SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);

        //Debug.Log("on");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        swingSequence.Kill();
        button.transform.rotation = Quaternion.identity;

        button.transform.localScale = OriginalScale;
        //transform.DORotate(new Vector3(0f, 0f, 0f),0f);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        swingSequence.Kill();
        button.transform.rotation = Quaternion.identity;

        //sfx.Button_Down();
        button.transform.localScale = OriginalScale;
    }
}
