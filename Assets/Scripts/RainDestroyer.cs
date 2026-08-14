using UnityEngine;

public class RainDestroyer : MonoBehaviour
{
    private Player player;

    public bool isInDoubleScoreState = false;
    public int ScoreCount = 0;
    public int ScoreCount_Hard = 0;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //클래식 모드 점수 집계
        {
            if (collision.gameObject.CompareTag("Rain")) //Rain1/Rain2 점수 집계
            {
                if (player.isDead == false)
                {
                    if (isInDoubleScoreState == false &&
                        player.isInLiskState == false &&
                        player.isInSamuraiState == false)
                    {
                        ScoreCount += 1;
                    }

                    if (isInDoubleScoreState == true)
                    {
                        ScoreCount += 2;
                    }

                    if (player.isInLiskState == true)
                    {
                        ScoreCount += 5;
                    }
                }

                Destroy(collision.gameObject);
                //Debug.Log(ScoreCount);

                ScoreIndicator GetScore = FindFirstObjectByType<ScoreIndicator>();
                GetScore.UpdateCountGUI();
            }


            if (collision.gameObject.CompareTag("Rain3")) //Rain3 점수 집게
            {
                //Debug.Log("col");
                if (player.isDead == false)
                {
                    if (isInDoubleScoreState == false &&
                        player.isInLiskState == false &&
                        player.isInSamuraiState == false)
                    {
                        ScoreCount += 1;
                    }

                    if (isInDoubleScoreState == true)
                    {
                        ScoreCount += 2;
                    }

                    if (player.isInLiskState == true)
                    {
                        ScoreCount += 5;
                    }
                }

                Physics2D.IgnoreLayerCollision(
                    LayerMask.NameToLayer("Rain3"),
                    LayerMask.NameToLayer("Ground"),
                    false);

                Destroy(collision.gameObject);
                //Debug.Log(ScoreCount);

                ScoreIndicator GetScore = FindFirstObjectByType<ScoreIndicator>();
                GetScore.UpdateCountGUI();
            }
        }

        //하드 모드 점수 집계
        {
            if (collision.gameObject.CompareTag("Rain_Hard")||
                collision.gameObject.CompareTag("Rain2_Hard")) //Rain_Hard/Rain2_Hard 점수 집계
            {
                if (player.isDead == false)
                {
                    if (isInDoubleScoreState == false &&
                        player.isInLiskState == false &&
                        player.isInSamuraiState == false)
                    {
                        ScoreCount_Hard += 1;
                    }

                    if (isInDoubleScoreState == true)
                    {
                        ScoreCount_Hard += 2;
                    }

                    if (player.isInLiskState == true)
                    {
                        ScoreCount_Hard += 5;
                    }
                }

                Destroy(collision.gameObject);
                //Debug.Log(ScoreCount);

                ScoreIndicator GetScore = FindFirstObjectByType<ScoreIndicator>();
                GetScore.UpdateCountGUI_Hard();
            }

            if (collision.gameObject.CompareTag("Rain3_Hard")) //Rain3_Hard 점수 집계                
            {
                if (player.isDead == false)
                {
                    if (isInDoubleScoreState == false &&
                        player.isInLiskState == false &&
                        player.isInSamuraiState == false)
                    {
                        ScoreCount_Hard += 1;
                    }

                    if (isInDoubleScoreState == true)
                    {
                        ScoreCount_Hard += 2;
                    }

                    if (player.isInLiskState == true)
                    {
                        ScoreCount_Hard += 5;
                    }
                }

                Physics2D.IgnoreLayerCollision(
                    LayerMask.NameToLayer("Rain3_Hard"),
                    LayerMask.NameToLayer("Ground"),
                    false);

                Destroy(collision.gameObject);
                //Debug.Log(ScoreCount);

                ScoreIndicator GetScore = FindFirstObjectByType<ScoreIndicator>();
                GetScore.UpdateCountGUI_Hard();
            }
        }       
    }//OnTriggerEnter2D    
}
