using UnityEngine;
using DG.Tweening;

public class Shield : MonoBehaviour
{    
    private Player player;
    private RainDestroyer rainDestroyer;
    public Animator animator;
    private Shield_Animation shieldAnimation;
    private Sequence sq;


    private void Awake()
    {
        player = FindFirstObjectByType<Player>();
        rainDestroyer = FindFirstObjectByType<RainDestroyer>();
        shieldAnimation = FindFirstObjectByType<Shield_Animation>();
        //sq = GetComponent<Sequence>();
        //animator.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //클래식 모드 점수 집계
        {
            if (collision.gameObject.CompareTag("Rain"))            
            {
                if (player.isDead == false)
                {
                    if (rainDestroyer.isInDoubleScoreState == false &&
                        player.isInLiskState == false &&
                        player.isInSamuraiState == false)
                    {
                        rainDestroyer.ScoreCount += 1;
                    }

                    if (rainDestroyer.isInDoubleScoreState == true)
                    {
                        rainDestroyer.ScoreCount += 2;
                    }

                    if (player.isInLiskState == true)
                    {
                        rainDestroyer.ScoreCount += 5;
                    }
                }
                sq = DOTween.Sequence()
                    .Append(shieldAnimation.Rtransform.DOScaleY(0.9f, 0.1f)
                    .SetEase(Ease.OutCubic))
                    .Append(shieldAnimation.Rtransform.DOScaleY(1, 0.1f));
                sq = DOTween.Sequence()
                    .Append(shieldAnimation.Rtransform.DOScaleX(1.05f, 0.1f)
                    .SetEase(Ease.OutCubic))
                    .Append(shieldAnimation.Rtransform.DOScaleX(1, 0.1f));

                Destroy(collision.gameObject);

                ScoreIndicator GetScore = FindFirstObjectByType<ScoreIndicator>();
                GetScore.UpdateCountGUI();
            }
        }

        //하드 모드 점수 집계
        {
            if (collision.gameObject.CompareTag("Rain_Hard")||
                collision.gameObject.CompareTag("Rain2_Hard"))
            {
                if (player.isDead == false)
                {
                    if (rainDestroyer.isInDoubleScoreState == false &&
                        player.isInLiskState == false &&
                        player.isInSamuraiState == false)
                    {
                        rainDestroyer.ScoreCount_Hard += 1;
                    }

                    if (rainDestroyer.isInDoubleScoreState == true)
                    {
                        rainDestroyer.ScoreCount_Hard += 2;
                    }

                    if (player.isInLiskState == true)
                    {
                        rainDestroyer.ScoreCount_Hard += 5;
                    }
                }
                sq = DOTween.Sequence()
                    .Append(shieldAnimation.Rtransform.DOScaleY(0.9f, 0.1f)
                    .SetEase(Ease.OutCubic))
                    .Append(shieldAnimation.Rtransform.DOScaleY(1, 0.1f));
                sq = DOTween.Sequence()
                    .Append(shieldAnimation.Rtransform.DOScaleX(1.05f, 0.1f)
                    .SetEase(Ease.OutCubic))
                    .Append(shieldAnimation.Rtransform.DOScaleX(1, 0.1f));

                Destroy(collision.gameObject);

                ScoreIndicator GetScore = FindFirstObjectByType<ScoreIndicator>();
                GetScore.UpdateCountGUI_Hard();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //클래식 모드 점수 집계
        {
            if (collision.gameObject.CompareTag("Rain4"))                           
            {
                if (player.isDead == false)
                {
                    if (rainDestroyer.isInDoubleScoreState == false &&
                        player.isInLiskState == false &&
                        player.isInSamuraiState == false)
                    {
                        rainDestroyer.ScoreCount += 1;
                    }

                    if (rainDestroyer.isInDoubleScoreState == true)
                    {
                        rainDestroyer.ScoreCount += 2;
                    }

                    if (player.isInLiskState == true)
                    {
                        rainDestroyer.ScoreCount += 5;
                    }
                }

                sq = DOTween.Sequence()
                     .Append(shieldAnimation.Rtransform.DOScaleY(0.4f, 0.1f)
                     .SetEase(Ease.OutCubic))
                     .Append(shieldAnimation.Rtransform.DOScaleY(1, 0.1f));
                sq = DOTween.Sequence()
                    .Append(shieldAnimation.Rtransform.DOScaleX(1.2f, 0.1f)
                    .SetEase(Ease.OutCubic))
                    .Append(shieldAnimation.Rtransform.DOScaleX(1, 0.1f));

                Destroy(collision.gameObject);


                ScoreIndicator GetScore = FindFirstObjectByType<ScoreIndicator>();
                GetScore.UpdateCountGUI();
            }
            if (collision.gameObject.CompareTag("Rain3"))
            {
                if (player.isDead == false)
                {
                    if (rainDestroyer.isInDoubleScoreState == false &&
                        player.isInLiskState == false &&
                        player.isInSamuraiState == false)
                    {
                        rainDestroyer.ScoreCount += 1;
                    }

                    if (rainDestroyer.isInDoubleScoreState == true)
                    {
                        rainDestroyer.ScoreCount += 2;
                    }

                    if (player.isInLiskState == true)
                    {
                        rainDestroyer.ScoreCount += 5;
                    }
                }

                sq = DOTween.Sequence()
                     .Append(shieldAnimation.Rtransform.DOScaleY(0.4f, 0.1f)
                     .SetEase(Ease.OutCubic))
                     .Append(shieldAnimation.Rtransform.DOScaleY(1, 0.1f));
                sq = DOTween.Sequence()
                    .Append(shieldAnimation.Rtransform.DOScaleX(1.2f, 0.1f)
                    .SetEase(Ease.OutCubic))
                    .Append(shieldAnimation.Rtransform.DOScaleX(1, 0.1f));
                
                ScoreIndicator GetScore = FindFirstObjectByType<ScoreIndicator>();
                GetScore.UpdateCountGUI();
            }
        }

        //하드 모드 점수 집계
        {
            if (collision.gameObject.CompareTag("Rain3_Hard") ||
            collision.gameObject.CompareTag("Rain4_Hard"))
            {
                if (player.isDead == false)
                {
                    if (rainDestroyer.isInDoubleScoreState == false &&
                        player.isInLiskState == false &&
                        player.isInSamuraiState == false)
                    {
                        rainDestroyer.ScoreCount_Hard += 1;
                    }

                    if (rainDestroyer.isInDoubleScoreState == true)
                    {
                        rainDestroyer.ScoreCount_Hard += 2;
                    }

                    if (player.isInLiskState == true)
                    {
                        rainDestroyer.ScoreCount_Hard += 5;
                    }


                }

                sq = DOTween.Sequence()
                     .Append(shieldAnimation.Rtransform.DOScaleY(0.4f, 0.1f)
                     .SetEase(Ease.OutCubic))
                     .Append(shieldAnimation.Rtransform.DOScaleY(1, 0.1f));
                sq = DOTween.Sequence()
                    .Append(shieldAnimation.Rtransform.DOScaleX(1.2f, 0.1f)
                    .SetEase(Ease.OutCubic))
                    .Append(shieldAnimation.Rtransform.DOScaleX(1, 0.1f));
                //Debug.Log("충돌");


                ScoreIndicator GetScore = FindFirstObjectByType<ScoreIndicator>();
                GetScore.UpdateCountGUI_Hard();
            }
        }
        
    }
}
