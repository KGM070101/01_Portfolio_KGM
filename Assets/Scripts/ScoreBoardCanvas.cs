using DG.Tweening;
using UnityEngine;

public class ScoreBoardCanvas : MonoBehaviour
{
    public Transform TargetPos;
    private float DropDuration = 1.0f;
    private Vector3 StartPos;
    private void Start()
    {
        
    }

    public void DropPanel()
    {        
        StartPos = TargetPos.position + new Vector3(0f, 10f, 0f);
        transform.position = StartPos;

        transform.DOMoveY(TargetPos.position.y, DropDuration)
                                                             .SetEase(Ease.OutBounce)
                                                             .SetUpdate(true);
    }
    private void Update()
    {
        
    }
}
