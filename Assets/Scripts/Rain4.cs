using UnityEngine;

public class Rain4 : MonoBehaviour
{
    [SerializeField]
    private GameObject Rain4_Background;

    [SerializeField]
    private GameObject PlayerDectecterCollider;
    
    private Animator animator;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;
    private RainDestroyer rainDestroyer;
    private Player player;
    private SFX_Manager sfxManager;

    private new Rigidbody2D rigidbody2D;

    private Color Disappear;

    private Vector2 SpreadSize = new Vector2(3f, 0.2f);
    private Vector2 SpreadOffset = new Vector2(0f, -0.70f);

    private float originalGravityScale;

    private bool WasabiTimer = false;
    public bool bLanded = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        rainDestroyer = FindFirstObjectByType<RainDestroyer>();
        player = FindFirstObjectByType<Player>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        sfxManager = FindFirstObjectByType<SFX_Manager>();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),
                                       LayerMask.NameToLayer("Rain4"),true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Rain3"),
                                       LayerMask.NameToLayer("Rain4"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Rain3_Hard"),
                                       LayerMask.NameToLayer("Rain4"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Rain4"),
                                       LayerMask.NameToLayer("Rain4"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Rain3_Splitted"),
                                       LayerMask.NameToLayer("Rain4"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Rain3_Hard"),
                                       LayerMask.NameToLayer("Rain4_Hard"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Rain3_Splitted"),
                                       LayerMask.NameToLayer("Rain4_Hard"), true);
        spriteRenderer = GetComponent<SpriteRenderer>();

        originalGravityScale = rigidbody2D.gravityScale;
        Disappear = spriteRenderer.color;
        Disappear.a = 1.0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Rain4_Background.SetActive(false);
            PlayerDectecterCollider.SetActive(true);
            animator.SetTrigger("Landed");
            boxCollider2D.size = SpreadSize;
            boxCollider2D.offset = SpreadOffset;
            Invoke("End_Wasabi", 8.0f);
            sfxManager.Rain4_Landing();
            bLanded = true;
        }
            //if(bLanded==false)
            //{
            //    if(collision.gameObject.CompareTag("Player"))
            //    {
            //        rainDestroyer.ScoreCount += 10;
            //        Destroy(gameObject);
            //        player.animator.SetTrigger("Samurai_Slash");
            //        player.Slash_Effect.SetActive(true);
            //        player.Invoke("End_SlashEffect", 0.34f);
            //    }
            //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player_SecondCollider"))
        {
            if(player.isInSamuraiState==true)
            {
                if(bLanded==false)
                {
                    Destroy(gameObject);
                    //Debug.Log("Destroy");
                }                
            }
        }
    }

    private void Update()
    {
        if(WasabiTimer==true)
        {
            Disappear.a -= 0.4f*Time.deltaTime;
            spriteRenderer.color = Disappear;

            if(Disappear.a<=0)
            {
                Destroy(gameObject);
                
            }
        }

        if(player.isInLiskState==true)
        {
            rigidbody2D.gravityScale = originalGravityScale * 2.5f;
        }
        else
        {
            rigidbody2D.gravityScale = originalGravityScale;
        }
    }

    private void End_Wasabi()
    {
        WasabiTimer = true;
    }
        
}
