using UnityEngine;

public class Rain4_PlayerDetecterCollider : MonoBehaviour
{
    private Player player;

    private Rain3_Hard Rain3_hard;

    //public bool inWasabi = false;

    //public bool Rain3_inWasabi = false;

    private Color inWasabi_Color=new Color(0.5f,1.0f,0f);

    private int ColorCount = 0;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
        Rain3_hard = FindFirstObjectByType<Rain3_Hard>(FindObjectsInactive.Include);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.inWasabi = true;
            player.spriteRenderer.color = inWasabi_Color;
        }
        //if(collision.gameObject.CompareTag("Rain3_Hard"))
        //{
        //    Rain3_inWasabi = true;
        //    Rain3_hard.spriteRenderer.color = inWasabi_Color;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.inWasabi = false;
            player.spriteRenderer.color = Color.white;
        }
    }

    private void Update()
    {
        if(player.inWasabi==true)
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
    }
}
