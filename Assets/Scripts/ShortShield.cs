using Unity.VisualScripting;
using UnityEngine;

public class ShortShield : MonoBehaviour
{
    private Player player;

    public bool isInInvincible = false;

    private void Start()
    {
        player = FindFirstObjectByType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Rain")||
            collision.gameObject.CompareTag("Rain_Hard")||
            collision.gameObject.CompareTag("Rain2_Hard"))
        {
            Destroy(collision.gameObject);
            isInInvincible = true;
            Invoke("End_Invincible", player.shortshieldRange);
        }

        if(collision.gameObject.CompareTag("Rain3")||
            collision.gameObject.CompareTag("Rain3_Hard"))
        {
            isInInvincible = true;
            Invoke("End_Invincible", player.shortshieldRange);
        }
    }

    private void End_Invincible()
    {
        isInInvincible = false;
    }
}
