using UnityEngine;

public class Rain3_Splitted_1 : MonoBehaviour
{
    private Rain3 rain3;

    private Player player;

    private ShortShield shortShield;

    private new Rigidbody2D rigidbody2D;

    private Vector2 RandomXforce = new Vector2(5f, 7f);
    private Vector2 RandomYforce = new Vector2(8.0f, 12.0f);
    private Vector2 RandomRotation = new Vector2(-120.0f, 120.0f);   

    //private Test test;

    private int startCount = 0;

    private float randomR;

    private void Start()
    {
        rain3 = FindFirstObjectByType<Rain3>(FindObjectsInactive.Include);
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<Player>();
        shortShield = FindFirstObjectByType<ShortShield>(FindObjectsInactive.Include);
    }

    private void Update()
    {
        Vector2 facingDirection = -transform.right.normalized;

        if (rain3.BounceCount==2)
        {
            startCount++;
        }

        if (startCount <3)
        {
            float randomX = Random.Range(RandomXforce.x, RandomXforce.y);
            float randomY = Random.Range(RandomYforce.x, RandomYforce.y);
            randomR = Random.Range(RandomRotation.x, RandomRotation.y);

            Vector2 LaunchVelocity = facingDirection * randomX + Vector2.up * randomY;

            rigidbody2D.linearVelocity = LaunchVelocity;

            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Ground"),
                                           LayerMask.NameToLayer("Rain3_Splitted"), true);
        }
        transform.Rotate(0f, 0f, randomR * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            LifeIndicator lifeIndicator = collision.gameObject.GetComponent<LifeIndicator>();

            if(player.isInSamuraiState==false)
            {
                if(shortShield.isInInvincible==false)
                {
                    lifeIndicator.Damage2();
                    //player.PlayerHP -= 2;
                    player.Damage(2);
                }
            }

            Player colPlayer = collision.gameObject.GetComponent<Player>();


            GameOverStartManager GOSM = FindFirstObjectByType<GameOverStartManager>();


            if (colPlayer.PlayerHP <= 0)
            {
                BestScoreIndicator BSI = FindFirstObjectByType<BestScoreIndicator>();
                BSI.UpdateBestScoreGUI();


                TotalScoreIndicator TSI = FindFirstObjectByType<TotalScoreIndicator>();
                TSI.UpdateTotalSocreGUI();

                GOSM.GameOver();
                colPlayer.isDead = true;

                //Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();
                //player.linearVelocity = new Vector2(0, 5.0f);
            }
        }
    }
}
