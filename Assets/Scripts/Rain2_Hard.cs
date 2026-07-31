using System.Collections;
using UnityEngine;

public class Rain2_Hard : MonoBehaviour
{
    [SerializeField] GameObject Rain2_Hard_Splitted1;
    [SerializeField] GameObject Rain2_Hard_Splitted2;

    [SerializeField] public float randomXForce = 2f;

    public bool isAlive = true;

    public Rigidbody2D rb;
    
    private Player player;

    float OriginalGravityScale;

    private Color HitColor = new Color(0.97f, 0.64f, 0.63f);

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        rb = GetComponent<Rigidbody2D>();
        float randomX = Random.Range(-randomXForce, randomXForce);
        rb.linearVelocity = new Vector2(randomX, rb.linearVelocity.y);
        OriginalGravityScale = rb.gravityScale;
        StartCoroutine(TracePlayer());
    }

    private IEnumerator TracePlayer()
    {
        //Vector2 initPos = transform.position;
        //float timer = 0;
        while (Vector2.Distance(player.transform.position, transform.position) > 0f)
        {
            //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 1.5f * Time.deltaTime);

            //timer += Time.deltaTime;
            //transform.position = Vector2.Lerp(initPos, player.transform.position, 1.5f * timer);

            transform.position = Vector2.Lerp(transform.position, player.transform.position, 1.5f * Time.deltaTime);
            yield return null;
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.PlayerHP>1)
            {
                //if (player.isInSamuraiState == false)
                //{
                //    player.spriteRenderer.color = HitColor;
                //    Invoke("Hit", 0.1f);
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
                lifeindicator.Damage();
            }

            if (player.isInSamuraiState == true)
            {
                transform.DetachChildren();
                Rain2_Hard_Splitted1.SetActive(true);
                Rain2_Hard_Splitted2.SetActive(true);
                gameObject.SetActive(false);
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





        }
    }

    private void Hit()
    {
        player.spriteRenderer.color = Color.white;
    }

}

