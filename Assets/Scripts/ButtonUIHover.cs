using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonUIHover : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler   
{
    private SFX_Manager SFX;

    private RectTransform rectTransform;
    private Vector2 OriginalScale;
    private void Start()
    {
        SFX = FindFirstObjectByType<SFX_Manager>();
        rectTransform = GetComponent<RectTransform>();
        OriginalScale = rectTransform.localScale;
    }

    private void Update()
    {                
         //rectTransform.localScale = OriginalScale;        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("마우스 올라감");
        rectTransform.localScale = OriginalScale * 1.1f;
        SFX.Button_Hover();

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("마우스 내려감");
        rectTransform.localScale = OriginalScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log("마우스 클릭");
        rectTransform.localScale = OriginalScale;
    }

}
