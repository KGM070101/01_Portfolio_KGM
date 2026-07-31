using System.Collections;
using UnityEngine;

public class CameraShaking : MonoBehaviour
{
    private Vector3 OriginalPos;

    private void Awake()
    {
        OriginalPos = transform.position;
    }

    public void ShakeCamera(float duration, float movementValue)
    {
        StartCoroutine(shakingCamera(duration, movementValue));
    }

    private IEnumerator shakingCamera(float duration, float movementValue)
    {
        float endTime = 0f;

        while(endTime<duration)
        {
            float offsetX = Random.Range(-1.0f, 1.0f)*movementValue;
            float offsetY = Random.Range(-1.0f, 1.0f)*movementValue;

            transform.position = OriginalPos + new Vector3(offsetX, offsetY,OriginalPos.z);

            endTime += Time.deltaTime;
            yield return null;
        }
        transform.position = OriginalPos;
    }
}
