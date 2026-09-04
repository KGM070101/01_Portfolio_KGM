using UnityEngine;

public class Rain4_Hard_PlayerDectecterCollider : MonoBehaviour
{
    private Player player;

    private Rain3_Hard Rain3_hard;
    private Rain3_Hard_Splitted1 rain3Hard_Splitted1;
    private Rain3_Hard_Splitted2 rain3Hard_Splitted2;
    private Rain3_SplittedbySamurai_1 rain3_SplittedBySamurai1;
    private Rain3_SplittedbySamurai_2 rain3_SplittedBySamurai2;    

    private GameOverStartManager GOSM;

    private LifeIndicator lifeIndicator;

    private BestScoreIndicator BSI;

    private TotalScoreIndicator TSI;

    private RainManager rainManager;

    //public bool inWasabi = false;

    public bool Rain3_inWasabi = false;

    private Color inWasabi_Color = new Color(0.5f, 1.0f, 0f);

    private int ColorCount = 0;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        Rain3_hard = 
            FindFirstObjectByType<Rain3_Hard>(FindObjectsInactive.Include);
        rain3Hard_Splitted1 =
            FindFirstObjectByType<Rain3_Hard_Splitted1>(FindObjectsInactive.Include);
        rain3Hard_Splitted2 =
            FindFirstObjectByType<Rain3_Hard_Splitted2>(FindObjectsInactive.Include);
        rain3_SplittedBySamurai1 =
            FindFirstObjectByType<Rain3_SplittedbySamurai_1>(FindObjectsInactive.Include);
        rain3_SplittedBySamurai2 =
            FindFirstObjectByType<Rain3_SplittedbySamurai_2>(FindObjectsInactive.Include);
        lifeIndicator = FindFirstObjectByType<LifeIndicator>();
        GOSM = FindFirstObjectByType<GameOverStartManager>();
        BSI = FindFirstObjectByType<BestScoreIndicator>();
        TSI = FindFirstObjectByType<TotalScoreIndicator>();
        rainManager = FindFirstObjectByType<RainManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.inWasabi = true;
            player.spriteRenderer.color = inWasabi_Color;
            InvokeRepeating("DamagetoPlayer", 0f, 1.0f);

            
        }
        if (collision.gameObject.CompareTag("Rain3_Hard"))
        {
            Rain3_inWasabi = true;
            //Rain3_hard.spriteRenderer.color = inWasabi_Color;
            if(rainManager.Rain3_DoubleBounce==true)
            {
                //rain3Hard_Splitted1.spriteRenderer.color = inWasabi_Color;
                //rain3Hard_Splitted2.spriteRenderer.color = inWasabi_Color;
                //rain3_SplittedBySamurai1.spriteRenderer.color = inWasabi_Color;
                //rain3_SplittedBySamurai2.spriteRenderer.color = inWasabi_Color;
            }            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.inWasabi = false;
            player.spriteRenderer.color = Color.white;
            CancelInvoke("DamagetoPlayer");
        }
    }

    private void Update()
    {
        if (player.inWasabi == true)
        {
            player.spriteRenderer.color = inWasabi_Color;
        }
        //else
        //{
        //    ColorCount++;
        //    if(ColorCount==1)
        //    {

        //    }
        //}

        if (player.PlayerHP <= 0)
        {
            BSI.UpdateBestScoreGUI();
            TSI.UpdateTotalSocreGUI();
            GOSM.GameOver();
            player.isDead = true;
            //Debug.Log("dead");
        }
    }

    private void DamagetoPlayer()
    {
        //player.PlayerHP--;
        player.Damage(1);
        lifeIndicator = player.GetComponent<LifeIndicator>();
        if(player.isInSamuraiState==false)
        {
            lifeIndicator.Damage();
        }

    }
}
