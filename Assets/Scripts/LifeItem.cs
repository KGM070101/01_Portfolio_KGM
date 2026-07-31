using UnityEngine;

public class LifeItem : MonoBehaviour
{

    private Player player;
    private LifeIndicator lifeindicator;

    private void Awake()
    {
        player = FindFirstObjectByType<Player>();
        lifeindicator = FindFirstObjectByType<LifeIndicator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //player.PlayerHP += 1;
            lifeindicator.life += 1;

            if(player.PlayerHP<5)
            {
                player.Heal(1);
            }
            else
            {
                player.BonusLife(1);
            }

               
                        
            lifeindicator.UpdateLifeGUI();
            gameObject.SetActive(false);
        }        
    }
}
