using UnityEngine;

public class Rain : MonoBehaviour
{
    [SerializeField] public float randomXForce = 2f;

    [SerializeField] GameObject Splitted1;
    [SerializeField] GameObject Splitted2;

    public bool isAlive = true;

    public Rigidbody2D rb;

    private Player player;

    float OriginalGravityScale;

    private Color HitColor = new Color(0.97f, 0.64f, 0.63f);

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<Player>();
        float randomX = Random.Range(-randomXForce, randomXForce);
        rb.linearVelocity = new Vector2(randomX, rb.linearVelocity.y);
        OriginalGravityScale = rb.gravityScale;
        
    }
   
    private void Update()
    {               
        if (player.PlayerHP>0)
        {
            isAlive = true;
        }
        else
        {
            isAlive = false;
        }

        if (player.isInLiskState == true)
        {
            rb.gravityScale = OriginalGravityScale * 2.5f;
        }
        else if (player.isInLiskState == false)
        {
            rb.gravityScale = OriginalGravityScale;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if (player.PlayerHP>1)
            {
                //if(player.isInSamuraiState==false)
                //{
                //    player.spriteRenderer.color = HitColor;
                //    Invoke("Hit", 0.1f);
                //}
                                
            }
            if(isAlive==false)
            {
                //Player HitAnimation = collision.gameObject.GetComponent<Player>();
                //HitAnimation.ANIP.SetTrigger("Death");
            }
           

            LifeIndicator lifeindicator = collision.gameObject.GetComponent<LifeIndicator>();
            if (player.isInSamuraiState == false)
            {
                lifeindicator.Damage();
            }
            
            //if(lifeindicator!=null)
            //{
            //    Debug.Log("LifeIndicator");               
            //}
            //else
            //{
            //    Debug.Log("LifeIndicator=null");
            //}

            if(player.isInSamuraiState==false)
            {
                //player.PlayerHP--;
                player.Damage(1);
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
            
            if(player.isInSamuraiState==true)
            {
                transform.DetachChildren();
                Splitted1.SetActive(true);
                Splitted2.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

    private void Hit()
    {
        player.spriteRenderer.color = Color.white;
    }

}
