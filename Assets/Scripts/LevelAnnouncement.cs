using System.Collections;
using UnityEngine;

public class LevelAnnouncement : MonoBehaviour
{
    private Animator animator;
    private RectTransform rectTransform;

    private Vector2 HiddenPosition;
    private Vector2 ViewPosition;

    [SerializeField]
    private float moveSpeed = 5.0f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rectTransform = GetComponent<RectTransform>();

        ViewPosition = rectTransform.anchoredPosition;
        HiddenPosition = ViewPosition + new Vector2(6f, 0f);

        rectTransform.anchoredPosition = HiddenPosition;
    }

    public void StartNotice(string triggerName)
    {
        if(animator!=null)
        {
            animator.SetTrigger(triggerName);
        }
        StopAllCoroutines();
        StartCoroutine(NoticeRoutine());
    }

    private IEnumerator NoticeRoutine()
    {
        while (Vector3.Distance(rectTransform.anchoredPosition, ViewPosition) > 0.1f)
        {
            rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, ViewPosition, Time.deltaTime * moveSpeed);
            yield return null;
        }
        rectTransform.anchoredPosition = ViewPosition; 

        
        yield return new WaitForSeconds(5f);

        
        while (Vector3.Distance(rectTransform.anchoredPosition, HiddenPosition) > 0.1f)
        {
            rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, HiddenPosition, Time.deltaTime * moveSpeed);
            yield return null;
        }
        rectTransform.anchoredPosition = HiddenPosition; 

        
        gameObject.SetActive(false);
    }

    public void Level2()
    {        
        animator.SetTrigger("250");
    }

    public void Level3()
    {
        animator.SetTrigger("400");
    }

    public void Level4()
    {
        animator.SetTrigger("700");
    }

    public void Level5()
    {
        animator.SetTrigger("1000");
    }
}
