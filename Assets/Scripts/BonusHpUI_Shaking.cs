using System.Collections;
using DG.Tweening;
using UnityEngine;

public class BonusHpUI_Shaking : MonoBehaviour
{
    private Vector3 OriginalPos;

    private void Awake()
    {
        OriginalPos = transform.position;
    }

    private void Start()
    {
        if(gameObject.activeInHierarchy==true)
        {
            InvokeRepeating("StartShkaing", 0f, 0.1f);
        }        
    }

    private void StartShkaing()
    {
        ShakeUI(0.1f,0.01f);
    }

    private void ShakeUI(float duration,float movementValue)
    {
        if (!gameObject.activeInHierarchy)
            return;

            StartCoroutine(shakingUI(duration, movementValue));                
    }

    private IEnumerator shakingUI(float duration, float movementValue)
    {
        float endTime = 0f;

        while (endTime < duration)
        {
            float offsetX = Random.Range(-1.0f, 1.0f) * movementValue;
            float offsetY = Random.Range(-1.0f, 1.0f) * movementValue;

            transform.position = OriginalPos + new Vector3(offsetX, offsetY, OriginalPos.z);

            endTime += Time.deltaTime;
            yield return null;
        }
        transform.position = OriginalPos;        
    }
}
