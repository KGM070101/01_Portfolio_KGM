using UnityEngine;

public class Shield : MonoBehaviour
{
    private Player player;
    private RainDestroyer rainDestroyer;
    public Animator animator;


    private void Awake()
    {
        player = FindFirstObjectByType<Player>();
        rainDestroyer = FindFirstObjectByType<RainDestroyer>();
        //animator.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Rain")||
            collision.gameObject.CompareTag("Rain_Hard")||
            collision.gameObject.CompareTag("Rain2_Hard"))
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

            Destroy(collision.gameObject);

            ScoreIndicator GetScore = FindFirstObjectByType<ScoreIndicator>();
            GetScore.UpdateCountGUI();
        }

        if (collision.gameObject.CompareTag("Rain3")||
            collision.gameObject.CompareTag("Rain3_Hard"))
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
            

            ScoreIndicator GetScore = FindFirstObjectByType<ScoreIndicator>();
            GetScore.UpdateCountGUI();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rain4")||
            collision.gameObject.CompareTag("Rain4_Hard"))
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

            Destroy(collision.gameObject);

            ScoreIndicator GetScore = FindFirstObjectByType<ScoreIndicator>();
            GetScore.UpdateCountGUI();
        }
    }
}
