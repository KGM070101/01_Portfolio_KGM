using UnityEngine;

public class Rain4_Hard_PlayerDectecterCollider : MonoBehaviour
{
    private Player player;

    private Rain3_Hard Rain3_hard;

    private GameOverStartManager GOSM;

    private LifeIndicator lifeIndicator;

    private BestScoreIndicator BSI;

    private TotalScoreIndicator TSI;

    //public bool inWasabi = false;

    public bool Rain3_inWasabi = false;

    private Color inWasabi_Color = new Color(0.5f, 1.0f, 0f);

    private int ColorCount = 0;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        Rain3_hard = FindFirstObjectByType<Rain3_Hard>(FindObjectsInactive.Include);
        lifeIndicator = FindFirstObjectByType<LifeIndicator>();
        GOSM = FindFirstObjectByType<GameOverStartManager>();
        BSI = FindFirstObjectByType<BestScoreIndicator>();
        TSI = FindFirstObjectByType<TotalScoreIndicator>();
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
            Rain3_hard.spriteRenderer.color = inWasabi_Color;
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
