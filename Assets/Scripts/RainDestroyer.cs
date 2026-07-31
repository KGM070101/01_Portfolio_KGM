using UnityEngine;

public class RainDestroyer : MonoBehaviour
{
    private Player player;

    public bool isInDoubleScoreState = false;
    public int ScoreCount = 0;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Rain")||
            collision.gameObject.CompareTag("Rain_Hard")||
            collision.gameObject.CompareTag("Rain2_Hard"))
        {
            if(player.isDead==false)
            {
                if (isInDoubleScoreState == false && 
                    player.isInLiskState == false &&
                    player.isInSamuraiState==false)
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
        
        if (collision.gameObject.CompareTag("Rain3")||
            collision.gameObject.CompareTag("Rain3_Hard"))
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
            Physics2D.IgnoreLayerCollision(
                LayerMask.NameToLayer("Rain3_Hard"),
                LayerMask.NameToLayer("Ground"),
                false);
            //Debug.Log("col");


            Destroy(collision.gameObject);
            //Debug.Log(ScoreCount);


            ScoreIndicator GetScore = FindFirstObjectByType<ScoreIndicator>();
            GetScore.UpdateCountGUI();

        }

    }



    
}
