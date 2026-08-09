using UnityEngine;

public class Rain3 : MonoBehaviour
{
    [SerializeField] GameObject Splitted1;
    [SerializeField] GameObject Splitted2;
    [SerializeField] GameObject SplittedbySamurai1;
    [SerializeField] GameObject SplittedbySamurai2;

    [Range(10.0f,15.0f)] public float randomXForce = 10.0f;

    public bool isAlive = true;

    public Rigidbody2D rb;

    private Player player;

    float OriginalGravityScale;

    private CircleCollider2D circleCollider2D;

    private Animator animator;

    private ShortShield shortShield;

    private RainManager rainManager;

    private CameraShaking cameraShaking;

    private SFX_Manager SFX;

    private GameOverStartManager gosm;

    private Color HitColor = new Color(0.97f, 0.64f, 0.63f);

    public int BounceCount = 0;
    private void Start()
    {
        animator = GetComponent<Animator>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<Player>();
        float randomX = Random.Range(-randomXForce, randomXForce);
        rb.linearVelocity = new Vector2(randomX, rb.linearVelocity.y);
        OriginalGravityScale = rb.gravityScale;
        shortShield = FindFirstObjectByType<ShortShield>(FindObjectsInactive.Include);
        rainManager = FindFirstObjectByType<RainManager>();
        cameraShaking = FindFirstObjectByType<CameraShaking>();
        SFX = FindFirstObjectByType<SFX_Manager>();
        gosm = FindFirstObjectByType<GameOverStartManager>();
    }

    private void Update()
    {
        Player colPlayer = FindFirstObjectByType<Player>();
        int NextHp = colPlayer.PlayerHP - 1;
        if (NextHp > 0)
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
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {            
            if(rainManager.Rain3_DoubleBounce==false)
            {
                Physics2D.IgnoreLayerCollision(
                LayerMask.NameToLayer("Rain3"),
                LayerMask.NameToLayer("Ground"),
                true);

                animator.SetTrigger("Crack");
                SFX.Rain3_Landing();
            }
            if (rainManager.Rain3_DoubleBounce == true)
            {
                BounceCount++;
                if(BounceCount==1)
                {
                    animator.SetTrigger("Crack");
                    SFX.Rain3_Landing();
                }
                if(BounceCount==2)
                {
                    transform.DetachChildren();                    
                    Splitted1.SetActive(true);
                    Splitted2.SetActive(true);
                    gameObject.SetActive(false);
                    Physics2D.IgnoreLayerCollision(
                LayerMask.NameToLayer("Rain3"),
                LayerMask.NameToLayer("Ground"),
                true);
                    SFX.Rain3_Landing();
                }
            }
            if(player.isDead==false)
            {
                if(gosm.IsPausing==false)
                {
                    cameraShaking.ShakeCamera(0.1f, 0.1f);
                    //Debug.Log("카메라 흔들림");
                }                
            }            
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.isDead == false)
            {
                if(gosm.IsPausing==false)
                {
                    cameraShaking.ShakeCamera(0.1f, 0.1f);
                }                    
            }

            if (player.PlayerHP>2)
            {
                //if (player.isInSamuraiState == false)
                //{
                //    if(shortShield.isInInvincible==false)
                //    {
                //        player.spriteRenderer.color = HitColor;
                //        Invoke("Hit", 0.1f);
                //    }
                    
                //}
            }
            if (isAlive == false)
            {
                //Player HitAnimation = collision.gameObject.GetComponent<Player>();
                //HitAnimation.ANIP.SetTrigger("Death");
            }
            LifeIndicator lifeindicator = collision.gameObject.GetComponent<LifeIndicator>();
            
            if(player.isInSamuraiState==false)
            {
                if(shortShield.isInInvincible==false)
                {
                    lifeindicator.Damage2();
                }
                
            }
            
            //if (lifeindicator != null)
            //{
            //    Debug.Log("LifeIndicator");
            //}
            //else
            //{
            //    Debug.Log("LifeIndicator=null");
            //}

            if (player.isInSamuraiState == false)
            {
                if(shortShield.isInInvincible==false)
                {
                    // player.PlayerHP -= 2;
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
            
            if(player.isInSamuraiState==true)
            {
                transform.DetachChildren();
                SplittedbySamurai1.SetActive(true);
                SplittedbySamurai2.SetActive(true);
                gameObject.SetActive(false);                
            }
        }

        if (collision.gameObject.CompareTag("Shield"))
        {
            if (player.isDead == false)
            {
                if(gosm.IsPausing==false)
                {
                    cameraShaking.ShakeCamera(0.1f, 0.1f);
                }                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isAlive == true)
            {
                Player HitAnimation = collision.gameObject.GetComponent<Player>();
                HitAnimation.ANIP.SetTrigger("Hit");
            }
            if (isAlive == false)
            {
                Player HitAnimation = collision.gameObject.GetComponent<Player>();
                HitAnimation.ANIP.SetTrigger("Death");
            }
            LifeIndicator lifeindicator = collision.gameObject.GetComponent<LifeIndicator>();
            if(player.isInSamuraiState==false)
            {
                lifeindicator.Damage2();
            }
            

            //if (lifeindicator != null)
            //{
            //    Debug.Log("LifeIndicator");
            //}
            //else
            //{
            //    Debug.Log("LifeIndicator=null");
            //}

            if (player.isInSamuraiState == false)
            {
                //player.PlayerHP-=2;
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

    private void Hit()
    {
        player.spriteRenderer.color = Color.white;
    }

}
