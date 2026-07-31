using DG.Tweening;
using UnityEngine;

public class hpUI_Idle : MonoBehaviour
{
    private Player player;
    
    private Vector2 randomInterval;
    private Vector2 startPos;
    private Vector2 targetPos;

    private SpriteRenderer spriteRenderer;
    private Sequence seq;

    private float timer;
    private float interval;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        randomInterval = new Vector2(5f, 10f);
        interval = Random.Range(randomInterval.x, randomInterval.y);       

        startPos = transform.position;
        targetPos = startPos + new Vector2(0f, 0.1f);

        //InvokeRepeating("Jump", 0f, interval);
        //transform.DOMoveY(targetPos.y, 0.2f)
        //    .SetLoops(2, LoopType.Yoyo)
        //    .SetEase(Ease.InOutSine);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer>=interval) //간격 돌때마다 랜덤 다시 뽑기
        {
            interval = Random.Range(randomInterval.x, randomInterval.y);
            timer = 0f;
            Jump();
        }
    }

    private void Jump()
    {
        if(spriteRenderer.color.r==1) //활성화 시에만 작동
        {
            transform.DOMoveY(targetPos.y, 0.2f)
            .SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.InBounce);

            seq = DOTween.Sequence()
                .Append(transform.DOScaleY((0.7f), (0.4f/3)).SetEase(Ease.InCubic))
                .Append(transform.DOScaleY((1.2f), (0.4f / 3)).SetEase(Ease.InCubic))
                .Append(transform.DOScaleY((1.0f), (0.4f / 3)).SetEase(Ease.InCubic));
                
        }        
    }    
}
