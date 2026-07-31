using System;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField] private GameOverStartManager GOSM;
    [SerializeField] private GameObject Shield;
    //[SerializeField] private GameObject Shield_Animation;
    [SerializeField] private GameObject shortshield;
    [SerializeField] private GameObject ItemDurationInterface;
    [SerializeField] private GameObject RightDash_Effect;
    [SerializeField] private GameObject LeftDash_Effect;
    [SerializeField] public GameObject Slash_Effect;
    //[SerializeField] private Rain4_PlayerDetecterCollider rain4_PDC;

    [Range(0.5f, 3.0f)] public float shortshieldRange;
    //private Vector2 StartPosition;

    public new Rigidbody2D rigidbody;
    private BoxCollider2D col;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    private ItemDurationBar itemdurationbar;
    private Rain IA;
    private RightDash_Effect rightDash_Effect;
    private LeftDash_Effect leftDash_Effect;
    private CameraShaking cameraShaking;
    private ShortShield shortShield;
    private Rain4_PlayerDetecterCollider Rain4_PDC;
    private Rain4 rain4;
    private SFX_Manager SFX;
    private Shield shield;
    private Shield_Animation Shield_animation;
    private hpUI_IndexManager HP_Index;
   
    public int PlayerHP = 5;
    public float movespeed;   
    public float fastermovespeed = 10.0f;
    private int AfterDeathCount = 0;
    private int AfterDeathCount2 = 0;
    private int JumpCount=0;
    private int maxHp = 5;
    
    private Vector2 originalScale;
    private Vector3 PlayerScale;
    public Vector2 position;
    private Vector2 OriginalOffset;

    private bool isInSmallState = false;
    public bool isInSpeedState = false;
    public bool isInLiskState = false;
    public bool isInSamuraiState = false;
    public bool bLanded = true;
    public bool isDead = false;
    public bool CollideToRain = false;
    private bool isContactingRightWall = false;
    private bool isContactingLeftWall = false;
    public bool inWasabi = false;

    private Color HitColor = new Color(0.97f, 0.64f, 0.63f);
    private Color ShieldInvisible = new Color(0, 0, 0, 0);

    public Animator ANIP = new Animator();
    private RainDestroyer raindestroyer;
    private void Start()
    {       
        itemdurationbar=FindFirstObjectByType<ItemDurationBar>(FindObjectsInactive.Include);
        IA = FindFirstObjectByType<Rain>(FindObjectsInactive.Include);
        animator = GetComponent<Animator>();
        PlayerScale = transform.localScale;
        col = GetComponent<BoxCollider2D>();
        raindestroyer = FindFirstObjectByType<RainDestroyer>();
        originalScale = col.size;
        OriginalOffset = col.offset;
        IA.isAlive = true;        
        rightDash_Effect = FindFirstObjectByType<RightDash_Effect>(FindObjectsInactive.Include);
        leftDash_Effect= FindFirstObjectByType<LeftDash_Effect>(FindObjectsInactive.Include);
        animator.SetFloat("Player_Walk_Speed", 1.0f);
        animator.SetFloat("Player_Run_Speed", 1.2f);
        rigidbody = GetComponent<Rigidbody2D>();
        cameraShaking = FindFirstObjectByType<CameraShaking>();
        shortShield = FindFirstObjectByType<ShortShield>(FindObjectsInactive.Include);
        Rain4_PDC = FindFirstObjectByType<Rain4_PlayerDetecterCollider>(FindObjectsInactive.Include);
        rain4 = FindFirstObjectByType<Rain4>(FindObjectsInactive.Include);
        SFX = FindFirstObjectByType<SFX_Manager>();
        shield = FindFirstObjectByType<Shield>(FindObjectsInactive.Include);
        Shield_animation = FindFirstObjectByType<Shield_Animation>();
        HP_Index = FindFirstObjectByType<hpUI_IndexManager>();

        Shield_animation.spriteRenderer.color = ShieldInvisible;
        //StartPosition = rigidbody.position; //(Ground)땅에 닿으면 원 위치

        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"),
                                       LayerMask.NameToLayer("Shield"), true);
        HP_Index.UpdateHPUI(PlayerHP, maxHp);        
    }
    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ANIP = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    private bool isDashing = false;
    private float dashVelocity = 0;
    private float dashTimer = 0;
    private float dashDuration = 0.1f;
    private float dashCoolDown = 0.5f;
    private float dashFinished = 0;   
    private void Update()
    {
        if(isContactingLeftWall==true||isContactingRightWall==true)
        {
            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, -4.0f);
        }

        if (PlayerHP<=0)
        {
            AfterDeathCount2++;
            if(AfterDeathCount2==1)
            {
                animator.SetTrigger("Player_Death");
            }
        }
        //Debug.Log(CollideToRain);
        //Debug.Log("isAlive :"+IA.isAlive);
        //Debug.Log("AfterDeathCount : " + AfterDeathCount);
        //Debug.Log("PlayerHP : "+PlayerHP);
        //Debug.Log(bLanded);
        position = transform.position;

        if(PlayerHP>0)
        {
            IA.isAlive = true;
        }
        else
        {
            IA.isAlive = false;
        }

            bool canDash = Time.time - dashFinished >= dashCoolDown;

        if (isDead==false)
        {
            if (isInSamuraiState == false)
            {
                if(bLanded==true)
                {
                    if(inWasabi==false)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, 12.0f);
                            SFX.Player_Jump();
                        }
                    }
                    else if(inWasabi==true)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, (12.0f/4.0f));
                            SFX.Player_Jump();
                        }
                    }
                }                
            }
        }
        
        if (isDead == false)
        {                       
                if (isInSamuraiState == true)
                {
                    if(JumpCount<1)
                    {
                        if (Input.GetKeyDown(KeyCode.Space))
                        {
                            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, 12.0f);
                            JumpCount++;
                        }
                    }                    
                }            
        }

        if (bLanded == true)
        {
            JumpCount = 0;
        }


        if (Input.GetKey(KeyCode.E)) //공중부양 기능
        {
            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, 3.0f);
        }

        if (canDash == true)
        {
            if(isInSamuraiState==false)
            {
                if(isDead==false)
                {
                    if (isInSpeedState == false)
                    {
                        if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.A))
                        {
                            dashTimer = dashDuration;
                            isDashing = true;
                            dashVelocity = -25.0f;
                            dashFinished = Time.time;
                            animator.SetTrigger("Dash");
                            RightDash_Effect.SetActive(true);
                            rightDash_Effect.Start_RightDash_Effect();
                            SFX.Player_Dash();
                        }

                        if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.D))
                        {
                            dashTimer = dashDuration;
                            isDashing = true;
                            dashVelocity = 25.0f;
                            dashFinished = Time.time;
                            animator.SetTrigger("Dash");
                            LeftDash_Effect.SetActive(true);
                            leftDash_Effect.Start_LeftDash_Effect();
                            SFX.Player_Dash();
                        }
                    }
                    if (isInSpeedState == true)
                    {
                        if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.A))
                        {
                            dashTimer = dashDuration;
                            isDashing = true;
                            dashVelocity = -25.0f;
                            dashFinished = Time.time;
                            animator.SetTrigger("Speed_Dash");
                            RightDash_Effect.SetActive(true);
                            rightDash_Effect.Start_RightDash_Effect();
                            SFX.Player_Dash();
                        }

                        if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.D))
                        {
                            dashTimer = dashDuration;
                            isDashing = true;
                            dashVelocity = 25.0f;
                            dashFinished = Time.time;
                            animator.SetTrigger("Speed_Dash");
                            LeftDash_Effect.SetActive(true);
                            leftDash_Effect.Start_LeftDash_Effect();
                            SFX.Player_Dash();
                        }
                    }
                }                
            }
            if (isInSamuraiState == true)
            {
                if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.A))
                {
                    dashTimer = dashDuration;
                    isDashing = true;
                    dashVelocity = -25.0f;
                    dashFinished = Time.time;
                    animator.SetTrigger("Samurai_Dash");
                    RightDash_Effect.SetActive(true);
                    rightDash_Effect.Start_Samurai_RightDash_Effect();
                    SFX.Player_Dash();
                }

                if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.D))
                {
                    dashTimer = dashDuration;
                    isDashing = true;
                    dashVelocity = 25.0f;
                    dashFinished = Time.time;
                    animator.SetTrigger("Samurai_Dash");
                    LeftDash_Effect.SetActive(true);
                    leftDash_Effect.Start_Samurai_LeftDash_Effect();
                    SFX.Player_Dash();
                }
            }


        }        
    }
    public void Damage(int damage)
    {
        if (isDead)
            return;

        PlayerHP -= damage;

        SFX.PlayerHit();

        if(PlayerHP<0)
        {
            PlayerHP = 0;
        }

        HP_Index.UpdateHPUI(PlayerHP, maxHp);

        if (PlayerHP<=0)
        {
            Die();
        }
    }

    public void Heal(int HealAmount)
    {
        if (isDead)
            return;

        PlayerHP += HealAmount;

        SFX.Player_Heal();

        if(PlayerHP>maxHp)
        {
            PlayerHP = maxHp;
        }

        HP_Index.UpdateHPUI(PlayerHP, maxHp);
    }

    public void BonusLife(int HealAmount)
    {
        maxHp += HealAmount;

        SFX.Player_Heal();

        if (maxHp>10)
        {
            maxHp = 10;
        }

        PlayerHP += HealAmount;

        if(PlayerHP>maxHp)
        {
            PlayerHP = maxHp;
        }

        HP_Index.UpdateHPUI(PlayerHP, maxHp);
    }
    private void Die()
    {
        //GameOverStartManager REPLAY = FindFirstObjectByType<GameOverStartManager>();
        //REPLAY.ReplayGame();

        if (isDead)
            return;

        isDead = true;
        int deadCount = 0;
        if(isDead==true)
        {
            deadCount++;
            if(deadCount==1)
            {
                SFX.Player_Dead();
                SFX.Stop_GameBGM();
                GOSM.GameOver();
            }
        }
        //GOSM.GameOver();        
    }

    private void FixedUpdate()
    {             
            movespeed = 0;
        
        if(isDashing==true)
        {
            if(isDead==false)
            {
                if(inWasabi==false)
                {
                    movespeed = dashVelocity;
                    dashTimer -= Time.fixedDeltaTime;

                    if (dashTimer <= 0)
                        isDashing = false;
                }
                else if(inWasabi==true)
                {
                    movespeed = (dashVelocity/4.0f);
                    dashTimer -= Time.fixedDeltaTime;

                    if (dashTimer <= 0)
                        isDashing = false;
                }
            }
                    
        }

        else
        {        
            if(isDead==false)
            {
                if(isInSamuraiState==false)
                {
                    if (isInSpeedState == false)
                    {
                        if(CollideToRain==false)  //하드모드 Rain 충돌 false
                        {
                            if(inWasabi==false)  //기본 이동
                            {                                
                                if (Input.GetKey(KeyCode.D))
                                {
                                    movespeed = 5.0f;
                                    spriteRenderer.flipX = true;
                                    animator.SetBool("bWalk", true);
                                    animator.SetFloat("Player_Walk_Speed", 1.0f);
                                    Shield_animation.animator.SetBool("bLeft", false);
                                }                               
                                else if (Input.GetKey(KeyCode.A))
                                {
                                    movespeed = -5.0f;
                                    spriteRenderer.flipX = false;
                                    animator.SetBool("bWalk", true);
                                    animator.SetFloat("Player_Walk_Speed", 1.0f);
                                    Shield_animation.animator.SetBool("bLeft", true);
                                }                                                          
                                else
                                {
                                    animator.SetBool("bWalk", false);
                                }
                            }
                            else if (inWasabi == true)  //와사비 빠졌을 때
                            {                                
                                if (Input.GetKey(KeyCode.D))
                                {
                                    movespeed = (5.0f/4.0f);
                                    spriteRenderer.flipX = true;
                                    animator.SetBool("bWalk", true);
                                    animator.SetFloat("Player_Walk_Speed", 0.25f);
                                    Shield_animation.animator.SetBool("bLeft", false);
                                }                               
                                else if (Input.GetKey(KeyCode.A))
                                {
                                    movespeed = (-5.0f/4.0f);
                                    spriteRenderer.flipX = false;
                                    animator.SetBool("bWalk", true);
                                    animator.SetFloat("Player_Walk_Speed", 0.25f);
                                    Shield_animation.animator.SetBool("bLeft", true);
                                }                                                          
                                else
                                {
                                    animator.SetBool("bWalk", false);
                                }
                            }

                        }

                        if (CollideToRain == true)  //하드모드 Rain 충돌 true
                        {
                            if (inWasabi == false)  //기본 이동
                            {                               
                                if (Input.GetKey(KeyCode.D))
                                {
                                    movespeed = 2.5f;
                                    spriteRenderer.flipX = true;
                                    animator.SetBool("bWalk", true);
                                    animator.SetFloat("Player_Walk_Speed", 0.5f);
                                    Shield_animation.animator.SetBool("bLeft", false);
                                }                                
                                else if (Input.GetKey(KeyCode.A))
                                {
                                    movespeed = -2.5f;
                                    spriteRenderer.flipX = false;
                                    animator.SetBool("bWalk", true);
                                    animator.SetFloat("Player_Walk_Speed", 0.5f);
                                    Shield_animation.animator.SetBool("bLeft", true);
                                }                                                         
                                else
                                {
                                    animator.SetBool("bWalk", false);
                                }
                            }
                            else if (inWasabi == true)  //와사비 빠졌을 때
                            {
                                if (Input.GetKey(KeyCode.D))
                                {
                                    movespeed = (2.5f/4.0f);
                                    spriteRenderer.flipX = true;
                                    animator.SetBool("bWalk", true);
                                    animator.SetFloat("Player_Walk_Speed", 0.125f);
                                    Shield_animation.animator.SetBool("bLeft", false);
                                }                                
                                else if (Input.GetKey(KeyCode.A))
                                {
                                    movespeed = (-2.5f/4.0f);
                                    spriteRenderer.flipX = false;
                                    animator.SetBool("bWalk", true);
                                    animator.SetFloat("Player_Walk_Speed", 0.125f);
                                    Shield_animation.animator.SetBool("bLeft", true);
                                }                                                       
                                else
                                {
                                    animator.SetBool("bWalk", false);
                                }
                            }
                        }
                    }                   

                }               
            }
            if (isDead == false)
            {
                if (isInSamuraiState == true)
                {
                    if(inWasabi==false)
                    {                        
                        if (Input.GetKey(KeyCode.D))
                        {
                            movespeed = 7.0f;
                            spriteRenderer.flipX = true;
                            animator.SetBool("bSamurai_Walk", true);
                            Shield_animation.animator.SetBool("bLeft", false);
                        }                       
                        else if (Input.GetKey(KeyCode.A))
                        {
                            movespeed = -7.0f;
                            spriteRenderer.flipX = false;
                            animator.SetBool("bSamurai_Walk", true);
                            Shield_animation.animator.SetBool("bLeft", true);
                        }                                         
                        else
                        {
                            animator.SetBool("bSamurai_Walk", false);
                        }
                    }
                   else if(inWasabi==true)
                    {
                        if (Input.GetKey(KeyCode.D))
                        {
                            movespeed = (7.0f/4.0f);
                            spriteRenderer.flipX = true;
                            animator.SetBool("bSamurai_Walk", true);
                            Shield_animation.animator.SetBool("bLeft", false);
                        }                       
                        else if (Input.GetKey(KeyCode.A))
                        {
                            movespeed = (-7.0f/4.0f);
                            spriteRenderer.flipX = false;
                            animator.SetBool("bSamurai_Walk", true);
                            Shield_animation.animator.SetBool("bLeft", true);
                        }                                           
                        else
                        {
                            animator.SetBool("bSamurai_Walk", false);
                        }
                    }
                }
            }


            if (isDead==false)
            {
                if (isInSpeedState == true)
                {
                    if(CollideToRain==false)
                    {
                        if(inWasabi==false)
                        {                            
                            if (Input.GetKey(KeyCode.D))
                            {
                                movespeed = fastermovespeed;
                                spriteRenderer.flipX = true;
                                animator.SetBool("bWalk", false);
                                animator.SetBool("bRun", true);
                                animator.SetFloat("Player_Run_Speed", 1.2f);
                                Shield_animation.animator.SetBool("bLeft", false);
                            }                           
                            else if (Input.GetKey(KeyCode.A))
                            {
                                movespeed = -fastermovespeed;
                                spriteRenderer.flipX = false; ;
                                animator.SetBool("bWalk", false);
                                animator.SetBool("bRun", true);
                                animator.SetFloat("Player_Run_Speed", 1.2f);
                                Shield_animation.animator.SetBool("bLeft", true);
                            }                                                 
                            else
                            {
                                animator.SetBool("bWalk", false);
                                animator.SetBool("bRun", false);
                            }
                        }
                        else if(inWasabi==true)
                        {
                            if (Input.GetKey(KeyCode.D))
                            {
                                movespeed = (fastermovespeed/4.0f);
                                spriteRenderer.flipX = true;
                                animator.SetBool("bWalk", false);
                                animator.SetBool("bRun", true);
                                animator.SetFloat("Player_Run_Speed", 0.3f);
                                Shield_animation.animator.SetBool("bLeft", false);
                            }                           
                            else if (Input.GetKey(KeyCode.A))
                            {
                                movespeed = (-fastermovespeed/4.0f);
                                spriteRenderer.flipX = false; ;
                                animator.SetBool("bWalk", false);
                                animator.SetBool("bRun", true);
                                animator.SetFloat("Player_Run_Speed", 0.3f);
                                Shield_animation.animator.SetBool("bLeft", true);
                            }                                                
                            else
                            {
                                animator.SetBool("bWalk", false);
                                animator.SetBool("bRun", false);
                            }
                        }
                    }
                    if (CollideToRain == true)
                    {
                        if(inWasabi==false)
                        {                           
                            if (Input.GetKey(KeyCode.D))
                            {
                                movespeed = fastermovespeed * 0.5f;
                                spriteRenderer.flipX = true;
                                animator.SetBool("bWalk", false);
                                animator.SetBool("bRun", true);
                                animator.SetFloat("Player_Run_Speed", 0.6f);
                                Shield_animation.animator.SetBool("bLeft", false);
                            }                           
                            else if (Input.GetKey(KeyCode.A))
                            {
                                movespeed = -fastermovespeed * 0.5f;
                                spriteRenderer.flipX = false; ;
                                animator.SetBool("bWalk", false);
                                animator.SetBool("bRun", true);
                                animator.SetFloat("Player_Run_Speed", 0.6f);
                                Shield_animation.animator.SetBool("bLeft", true);
                            }                                                  
                            else
                            {
                                animator.SetBool("bWalk", false);
                                animator.SetBool("bRun", false);
                            }
                        }
                        else if(inWasabi==true)
                        {
                            if (Input.GetKey(KeyCode.D))
                            {
                                movespeed = ((fastermovespeed * 0.5f)/4.0f);
                                spriteRenderer.flipX = true;
                                animator.SetBool("bWalk", false);
                                animator.SetBool("bRun", true);
                                animator.SetFloat("Player_Run_Speed", 0.15f);
                                Shield_animation.animator.SetBool("bLeft", false);
                            }                            
                            else if (Input.GetKey(KeyCode.A))
                            {
                                movespeed = ((-fastermovespeed * 0.5f)/4.0f);
                                spriteRenderer.flipX = false; ;
                                animator.SetBool("bWalk", false);
                                animator.SetBool("bRun", true);
                                animator.SetFloat("Player_Run_Speed", 0.15f);
                                Shield_animation.animator.SetBool("bLeft", true);
                            }                                                   
                            else
                            {
                                animator.SetBool("bWalk", false);
                                animator.SetBool("bRun", false);
                            }
                        }
                    }


                }                
            }
            
        }
        rigidbody.linearVelocity = new Vector2(movespeed, rigidbody.linearVelocity.y);        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isInSamuraiState==false)
        {
            if (PlayerHP > 0)
            {
                if(shortShield.isInInvincible==false)
                {
                    if (collision.gameObject.CompareTag("Rain3") ||
                    collision.gameObject.CompareTag("Rain3_Hard"))
                    {
                        Invoke("ShortShieldActivate", 0.1f);
                        Invoke("End_ShortShield", shortshieldRange);
                    }
                }
                
            }           
        }
        //if (collision.gameObject.CompareTag("Ground")) 
        if (collision.gameObject.CompareTag("Ground"))
        {
            bLanded = true;
            //Debug.Log("Enter");
        }   

        if (isInSamuraiState == true)
        {
            if (collision.gameObject.CompareTag("Rain")||
                collision.gameObject.CompareTag("Rain_Hard")||
                collision.gameObject.CompareTag("Rain2_Hard"))
            {
                raindestroyer.ScoreCount += 5;
                //Invoke("End_Red", 0.1f);
                Destroy(collision.gameObject);                
            }
            if(collision.gameObject.CompareTag("Rain3"))
            {
                raindestroyer.ScoreCount += 10;
                //Invoke("End_Red", 0.1f);
                Destroy(collision.gameObject);                
                Physics2D.IgnoreLayerCollision(
                LayerMask.NameToLayer("Rain3"),
                LayerMask.NameToLayer("Ground"),
                false);
                animator.SetTrigger("Samurai_Slash");
                Slash_Effect.SetActive(true);
                //animator.SetTrigger("Slash");
                Invoke("End_SlashEffect", 0.34f);
                Destroy(collision.gameObject);
                SFX.Player_Slash();
            }           
            if(collision.gameObject.CompareTag("Rain3_Hard"))
            {
                raindestroyer.ScoreCount += 10;
                Destroy(collision.gameObject);
                Physics2D.IgnoreLayerCollision(
                LayerMask.NameToLayer("Rain3_Hard"),
                LayerMask.NameToLayer("Ground"),
                false);
                animator.SetTrigger("Samurai_Slash");
                Slash_Effect.SetActive(true);
                //animator.SetTrigger("Slash");
                Invoke("End_SlashEffect", 0.34f);
                Destroy(collision.gameObject);
                SFX.Player_Slash();
            }
            //if(rain4.bLanded==false)
            //{
            //    if(collision.gameObject.CompareTag("Rain4"))
            //    {
            //        raindestroyer.ScoreCount += 10;
            //        Destroy(collision.gameObject);
            //        animator.SetTrigger("Samurai_Slash");
            //        Slash_Effect.SetActive(true);
            //        Invoke("End_SlashEffect", 0.34f);
            //    }
            //}
            
        }
        else
        {
            if (collision.gameObject.CompareTag("Ground"))
            {                
                if(isInSamuraiState==false)
                {
                    animator.SetBool("bLanded", true);
                }
                   
                //Debug.Log("Enter");
            }            
        }
              
        if (PlayerHP<=0)
        {
            if (collision.gameObject.CompareTag("Rain3"))
            {                
                AfterDeathCount++;
                if (AfterDeathCount == 1)
                {
                    //rigidbody.linearVelocity = new Vector2(0, 5);
                    //Debug.Log("죽음");
                }
            }            
        }

        if (collision.gameObject.CompareTag("RightWall"))
        {
            isContactingRightWall = true;
        }
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            isContactingLeftWall = true;
        }

        if (isInSamuraiState == false)
        {
            if(shortShield.isInInvincible==false)
            {
                if(PlayerHP>0)
                {
                    if (collision.gameObject.CompareTag("Rain3") ||
                        collision.gameObject.CompareTag("Rain3_Hard"))
                    {
                        spriteRenderer.color = HitColor;
                        Invoke("Hit", 0.1f);
                    }
                }                
            }            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            bLanded = false;
            if(isInSamuraiState==false)
            {
                animator.SetBool("bLanded",false);                
            }
            //Debug.Log("Exit");
        }        
        

        if (collision.gameObject.CompareTag("RightWall"))
        {
            isContactingRightWall = false;
        }
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            isContactingLeftWall = false;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {                        
        if (collision.gameObject.CompareTag("ShieldItem"))
        {
            Shield_animation.spriteRenderer.color = Color.white;
            ItemDurationInterface.SetActive(true);
            itemdurationbar.StartDurationBar(8.0f);
            Shield.SetActive(true);
            SFX.Item_Get();
            Invoke("End_Shield", 8.0f);
        }

        if(isInSamuraiState==false)
        {
            if (PlayerHP>0)
            {
                if (collision.gameObject.CompareTag("Rain"))
                {
                    shortshield.SetActive(true);
                    Invoke("End_ShortShield", shortshieldRange);
                }
                
                if (collision.gameObject.CompareTag("Rain_Hard"))
                {
                    CollideToRain = true;
                    Invoke("End_CollideToRain", 2.0f);
                }

            }            
        }
        
        if(IA.isAlive==false)
        {
            if(collision.gameObject.CompareTag("Rain")||
                collision.gameObject.CompareTag("Rain_Hard")||
                collision.gameObject.CompareTag("Rain2_Hard"))
            {
                AfterDeathCount++;
                if(AfterDeathCount==1)
                {
                    //rigidbody.linearVelocity = new Vector2(0, 5);
                    Debug.Log("죽음");
                }
            }
            return;
        }

        if(collision.gameObject.CompareTag("SpeedItem"))
        {
            ItemDurationInterface.SetActive(true);
            itemdurationbar.StartDurationBar(8.0f);
            isInSpeedState = true;
            animator.SetTrigger("Run");            
            Invoke("End_SpeedItem", 8.0f);
            SFX.Item_Get();
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("DoubleScoreItem"))
        {
            ItemDurationInterface.SetActive(true);
            itemdurationbar.StartDurationBar(8.0f);
            raindestroyer.isInDoubleScoreState = true;
            Invoke("End_DoubleScoreItem", 8.0f);
            SFX.Item_Get();
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("SmallItem"))
        {
            //Debug.Log("col");
            ItemDurationInterface.SetActive(true);
            itemdurationbar.StartDurationBar(8.0f);
            isInSmallState = true;
            SFX.Item_Get();
            if (isInSmallState==true)
            {
                col.size=originalScale * 0.5f;
                col.offset = new Vector2(0, -0.2f);
                //transform.localScale=PlayerScale * 0.5f;

                transform.DOScale(PlayerScale * 0.5f, 0.1f).SetEase(Ease.OutCubic);
            }
            Invoke("End_SmallItem", 8.0f);
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("LiskItem"))
        {
            ItemDurationInterface.SetActive(true);
            itemdurationbar.StartDurationBar(5.0f);
            isInLiskState = true;
            Invoke("End_LiskItem", 5.0f);
            SFX.Item_Get();
            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("SamuraiItem"))
        {
            ItemDurationInterface.SetActive(true);
            itemdurationbar.StartDurationBar(10.0f);
            isInSamuraiState = true;
            Invoke("End_SamuraiItem", 10.0f);
            animator.SetTrigger("Samurai_Idle");
            SFX.Item_Get();
            collision.gameObject.SetActive(false);
        }

        if(isInSamuraiState==true)
        {
            if(collision.gameObject.CompareTag("Rain")||
                collision.gameObject.CompareTag("Rain_Hard")||
                collision.gameObject.CompareTag("Rain2_Hard"))
            {
                cameraShaking.ShakeCamera(0.1f, 0.05f);
                raindestroyer.ScoreCount += 5;
                animator.SetTrigger("Samurai_Slash");
                Slash_Effect.SetActive(true);
                //animator.SetTrigger("Slash");
                Invoke("End_SlashEffect", 0.34f);
                Destroy(collision.gameObject);
                SFX.Player_Slash();
            }
            //if(collision.gameObject.CompareTag("Rain3")||
            //    collision.gameObject.CompareTag("Rain3_Hard"))
            //{                
            //    raindestroyer.ScoreCount += 10;
            //    animator.SetTrigger("Samurai_Slash");
            //    Slash_Effect.SetActive(true);
            //    //animator.SetTrigger("Slash");
            //    Invoke("End_SlashEffect", 0.34f);
            //    Destroy(collision.gameObject);
            //}
        }
        if(isInSamuraiState==false)
        {
            if(shortShield.isInInvincible==false)
            {
                if (PlayerHP > 0)
                {
                    if (collision.gameObject.CompareTag("Rain") ||
                        collision.gameObject.CompareTag("Rain_Hard") ||
                        collision.gameObject.CompareTag("Rain2_Hard"))
                    {
                        spriteRenderer.color = HitColor;
                        Invoke("Hit", 0.1f);
                    }
                }
            }           
        }
        
    }

    private void End_Shield()
    {
        Shield.SetActive(false);
        Shield_animation.spriteRenderer.color = ShieldInvisible;
    }

    private void ShortShieldActivate()
    {
        shortshield.SetActive(true);
    }
    private void End_ShortShield()
    {
        shortshield.SetActive(false);
    }

    private void End_SpeedItem()
    {        
        isInSpeedState = false;                
        animator.SetTrigger("bIdle");
    }

    private void End_DoubleScoreItem()
    {
        raindestroyer.isInDoubleScoreState = false;
    }
    private void End_SmallItem()
    {
        isInSmallState = false;
        col.size = originalScale;
        //transform.localScale = PlayerScale;
        transform.DOScale(PlayerScale, 0.5f).SetEase(Ease.OutCubic);
        col.offset = OriginalOffset;
    }
    private void End_LiskItem()
    {
        isInLiskState = false;
    }

    private void End_SamuraiItem()
    {
        isInSamuraiState = false;
        animator.SetTrigger("bIdle");
        animator.SetBool("bLanded", true);
    }

    private void End_CollideToRain()
    {
        CollideToRain = false;
        animator.SetFloat("Player_Walk_Speed", 1.0f);
        animator.SetFloat("Player_Run_Speed", 1.2f);
    }

    private void End_SlashEffect()
    {
        Slash_Effect.SetActive(false);
    }

    private void Hit()
    {
        spriteRenderer.color = Color.white;
    }

    //private void End_Red()
    //{
    //    spriteRenderer.color = Color.white;
    //}














}


//using UnityEngine;

//public class Player : MonoBehaviour
//{
//    [SerializeField] private GameOverStartManager GOSM;
//    [SerializeField] private GameObject Shield;
//    [SerializeField] private GameObject shortshield;
//    [SerializeField] private GameObject ItemDurationInterface;

//    [Range(0.5f, 3.0f)] public float shortshieldRange;
//    //private Vector2 StartPosition;

//    private new Rigidbody2D rigidbody;
//    private BoxCollider2D col;
//    private SpriteRenderer spriteRenderer;
//    private Animator animator;
//    private ItemDurationBar itemdurationbar;
//    private Rain IA;

//    public int PlayerHP = 3;
//    public float movespeed;
//    public float fastermovespeed = 10.0f;
//    private int AfterDeathCount = 0;
//    private int JumpCount = 0;

//    private Vector2 originalScale;
//    private Vector3 PlayerScale;

//    private bool isInSmallState = false;
//    public bool isInSpeedState = false;
//    public bool isInLiskState = false;
//    public bool isInSamuraiState = false;
//    private bool bLanded = true;
//    public bool isDead = false;

//    public Animator ANIP = new Animator();
//    private RainDestroyer raindestroyer;
//    private void Start()
//    {
//        itemdurationbar = FindFirstObjectByType<ItemDurationBar>(FindObjectsInactive.Include);
//        IA = FindFirstObjectByType<Rain>(FindObjectsInactive.Include);
//        animator = GetComponent<Animator>();
//        PlayerScale = transform.localScale;
//        col = GetComponent<BoxCollider2D>();
//        raindestroyer = FindFirstObjectByType<RainDestroyer>();
//        originalScale = col.size;
//        IA.isAlive = true;
//        //StartPosition = rigidbody.position; //(Ground)땅에 닿으면 원 위치
//    }
//    public void Awake()
//    {
//        spriteRenderer = GetComponent<SpriteRenderer>();
//        ANIP = GetComponent<Animator>();
//        rigidbody = GetComponent<Rigidbody2D>();
//    }

//    private bool isDashing = false;
//    private float dashVelocity = 0;
//    private float dashTimer = 0;
//    private float dashDuration = 0.1f;
//    private float dashCoolDown = 0.5f;
//    private float dashFinished = 0;
//    private void Update()
//    {
//        //Debug.Log("isAlive :"+IA.isAlive);
//        //Debug.Log("AfterDeathCount : " + AfterDeathCount);
//        //Debug.Log("PlayerHP : "+PlayerHP);
//        //Debug.Log(bLanded);

//        if (PlayerHP > 0)
//        {
//            IA.isAlive = true;
//        }
//        else
//        {
//            IA.isAlive = false;
//        }

//        bool canDash = Time.time - dashFinished >= dashCoolDown;

//        if (isDead == false)
//        {
//            if (isInSamuraiState == false)
//            {
//                if (bLanded == true)
//                {
//                    if (Input.GetKeyDown(KeyCode.Space))
//                    {
//                        rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, 12.0f);
//                    }
//                }
//            }
//        }

//        if (isDead == false)
//        {
//            if (isInSamuraiState == true)
//            {
//                if (JumpCount < 1)
//                {
//                    if (Input.GetKeyDown(KeyCode.Space))
//                    {
//                        rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, 12.0f);
//                        JumpCount++;
//                    }
//                }
//            }
//        }

//        if (bLanded == true)
//        {
//            JumpCount = 0;
//        }


//        if (Input.GetKey(KeyCode.E)) //공중부양 기능
//        {
//            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, 3.0f);
//        }

//        if (canDash == true)
//        {
//            if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.A))
//            {
//                dashTimer = dashDuration;
//                isDashing = true;
//                dashVelocity = -35.0f;
//                dashFinished = Time.time;
//            }

//            if (Input.GetKeyDown(KeyCode.C) && Input.GetKey(KeyCode.D))
//            {
//                dashTimer = dashDuration;
//                isDashing = true;
//                dashVelocity = 35.0f;
//                dashFinished = Time.time;
//            }
//        }
//    }
//    public void Damage(int damage)
//    {
//        if (isDead)
//            return;

//        PlayerHP -= damage;

//        if (PlayerHP < 0)
//        {
//            PlayerHP = 0;
//        }

//        if (PlayerHP <= 0)
//        {
//            Die();
//        }
//    }
//    private void Die()
//    {
//        GameOverStartManager REPLAY = FindFirstObjectByType<GameOverStartManager>();
//        REPLAY.ReplayGame();

//        if (isDead)
//            return;

//        isDead = true;
//        GOSM.GameOver();
//    }

//    private void FixedUpdate()
//    {
//        movespeed = 0;

//        if (isDashing == true)
//        {
//            movespeed = dashVelocity;
//            dashTimer -= Time.fixedDeltaTime;

//            if (dashTimer <= 0)
//                isDashing = false;
//        }

//        else
//        {
//            if (isDead == false)
//            {
//                if (isInSamuraiState == false)
//                {
//                    if (isInSpeedState == false)
//                    {
//                        if (Input.GetKey(KeyCode.D))
//                        {
//                            movespeed = 5.0f;
//                            spriteRenderer.flipX = true;
//                            animator.SetBool("bWalk", true);
//                        }
//                        else if (Input.GetKey(KeyCode.A))
//                        {
//                            movespeed = -5.0f;
//                            spriteRenderer.flipX = false;
//                            animator.SetBool("bWalk", true);
//                        }
//                        else
//                        {
//                            animator.SetBool("bWalk", false);
//                        }
//                    }

//                }
//            }
//            if (isDead == false)
//            {
//                if (isInSamuraiState == true)
//                {
//                    if (Input.GetKey(KeyCode.D))
//                    {
//                        movespeed = 7.0f;
//                        spriteRenderer.flipX = true;
//                        animator.SetBool("bSamurai_Walk", true);
//                    }
//                    else if (Input.GetKey(KeyCode.A))
//                    {
//                        movespeed = -7.0f;
//                        spriteRenderer.flipX = false;
//                        animator.SetBool("bSamurai_Walk", true);
//                    }
//                    else
//                    {
//                        animator.SetBool("bSamurai_Walk", false);
//                    }
//                }
//            }


//            if (isDead == false)
//            {
//                if (isInSpeedState == true)
//                {
//                    if (Input.GetKey(KeyCode.D))
//                    {
//                        movespeed = fastermovespeed;
//                        spriteRenderer.flipX = true;
//                        animator.SetBool("bRun", true);
//                    }
//                    else if (Input.GetKey(KeyCode.A))
//                    {
//                        movespeed = -fastermovespeed;
//                        spriteRenderer.flipX = false; ;
//                        animator.SetBool("bRun", true);
//                    }
//                    else
//                    {
//                        animator.SetBool("bRun", false);
//                    }

//                }
//            }

//        }
//        rigidbody.linearVelocity = new Vector2(movespeed, rigidbody.linearVelocity.y);
//    }

//    private void OnCollisionEnter2D(Collision2D collision)
//    {
//        //if (collision.gameObject.CompareTag("Ground")) 

//        if (isInSamuraiState == true)
//        {
//            if (collision.gameObject.CompareTag("Rain") || collision.gameObject.CompareTag("Rain3"))
//            {
//                raindestroyer.ScoreCount += 5;
//                Destroy(collision.gameObject);
//            }

//            if (collision.gameObject.CompareTag("Ground"))
//            {
//                bLanded = true;
//                //Debug.Log("Enter");
//            }
//        }
//        else
//        {
//            if (collision.gameObject.CompareTag("Ground"))
//            {
//                bLanded = true;
//                //Debug.Log("Enter");
//            }
//        }

//        if (PlayerHP <= 0)
//        {
//            if (collision.gameObject.CompareTag("Rain3"))
//            {
//                AfterDeathCount++;
//                if (AfterDeathCount == 1)
//                {
//                    //rigidbody.linearVelocity = new Vector2(0, 5);
//                    Debug.Log("죽음");
//                }
//            }
//        }


//    }

//    private void OnCollisionExit2D(Collision2D collision)
//    {
//        if (collision.gameObject.CompareTag("Ground"))
//        {
//            bLanded = false;
//            //Debug.Log("Exit");
//        }
//        if (collision.gameObject.CompareTag("Rain3"))
//        {
//            Invoke("ShortShieldActivate", 0.1f);
//            Invoke("End_ShortShield", shortshieldRange);
//        }
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.CompareTag("ShieldItem"))
//        {
//            ItemDurationInterface.SetActive(true);
//            itemdurationbar.StartDurationBar(5.0f);
//            Shield.SetActive(true);
//            Invoke("End_Shield", 5.0f);
//        }

//        if (isInSamuraiState == false)
//        {
//            if (IA.isAlive == true)
//            {
//                if (collision.gameObject.CompareTag("Rain") || collision.gameObject.CompareTag("Rain3"))
//                {
//                    Invoke("ShortShieldActivate", 0.1f);
//                    Invoke("End_ShortShield", shortshieldRange);
//                }
//            }
//        }

//        if (IA.isAlive == false)
//        {
//            if (collision.gameObject.CompareTag("Rain"))
//            {
//                AfterDeathCount++;
//                if (AfterDeathCount == 1)
//                {
//                    //rigidbody.linearVelocity = new Vector2(0, 5);
//                    Debug.Log("죽음");
//                }
//            }
//            return;
//        }

//        if (collision.gameObject.CompareTag("SpeedItem"))
//        {
//            ItemDurationInterface.SetActive(true);
//            itemdurationbar.StartDurationBar(8.0f);
//            isInSpeedState = true;
//            animator.SetTrigger("Run");
//            Invoke("End_SpeedItem", 8.0f);
//            collision.gameObject.SetActive(false);
//        }

//        if (collision.gameObject.CompareTag("DoubleScoreItem"))
//        {
//            ItemDurationInterface.SetActive(true);
//            itemdurationbar.StartDurationBar(5.0f);
//            raindestroyer.isInDoubleScoreState = true;
//            Invoke("End_DoubleScoreItem", 5.0f);
//            collision.gameObject.SetActive(false);
//        }

//        if (collision.gameObject.CompareTag("SmallItem"))
//        {
//            //Debug.Log("col");
//            ItemDurationInterface.SetActive(true);
//            itemdurationbar.StartDurationBar(8.0f);
//            isInSmallState = true;
//            if (isInSmallState == true)
//            {
//                col.size = originalScale * 0.5f;
//                transform.localScale = PlayerScale * 0.5f;
//            }
//            Invoke("End_SmallItem", 8.0f);
//            collision.gameObject.SetActive(false);
//        }

//        if (collision.gameObject.CompareTag("LiskItem"))
//        {
//            ItemDurationInterface.SetActive(true);
//            itemdurationbar.StartDurationBar(5.0f);
//            isInLiskState = true;
//            Invoke("End_LiskItem", 5.0f);
//            collision.gameObject.SetActive(false);
//        }

//        if (collision.gameObject.CompareTag("SamuraiItem"))
//        {
//            ItemDurationInterface.SetActive(true);
//            itemdurationbar.StartDurationBar(10.0f);
//            isInSamuraiState = true;
//            Invoke("End_SamuraiItem", 10.0f);
//            animator.SetTrigger("Samurai_Idle");
//            collision.gameObject.SetActive(false);
//        }

//        if (isInSamuraiState == true)
//        {
//            if (collision.gameObject.CompareTag("Rain"))
//            {
//                raindestroyer.ScoreCount += 5;
//                animator.SetTrigger("Samurai_Slash");
//                Destroy(collision.gameObject);
//            }
//            else if (collision.gameObject.CompareTag("Rain3"))
//            {
//                raindestroyer.ScoreCount += 10;
//                animator.SetTrigger("Samurai_Slash");
//                Destroy(collision.gameObject);
//            }
//        }
//        else
//        {
//            return;
//        }

//    }

//    private void End_Shield()
//    {
//        Shield.SetActive(false);
//    }

//    private void ShortShieldActivate()
//    {
//        shortshield.SetActive(true);
//    }
//    private void End_ShortShield()
//    {
//        shortshield.SetActive(false);
//    }

//    private void End_SpeedItem()
//    {
//        isInSpeedState = false;
//        animator.SetTrigger("bIdle");
//    }

//    private void End_DoubleScoreItem()
//    {
//        raindestroyer.isInDoubleScoreState = false;
//    }
//    private void End_SmallItem()
//    {
//        isInSmallState = false;
//        col.size = originalScale;
//        transform.localScale = PlayerScale;
//    }
//    private void End_LiskItem()
//    {
//        isInLiskState = false;
//    }

//    private void End_SamuraiItem()
//    {
//        isInSamuraiState = false;
//        animator.SetTrigger("bIdle");
//    }












//}


