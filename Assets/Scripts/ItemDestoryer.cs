using UnityEngine;

public class ItemDestoryer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Item")||
            collision.gameObject.CompareTag("ShieldItem")||
            collision.gameObject.CompareTag("SpeedItem")||
            collision.gameObject.CompareTag("DoubleScoreItem")||
            collision.gameObject.CompareTag("SmallItem")||
            collision.gameObject.CompareTag("LiskItem")||
            collision.gameObject.CompareTag("SamuraiItem"))
        {
            Destroy(collision.gameObject);
        }
    }
}
