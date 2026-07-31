using UnityEngine;

public class ShieldItem : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Shield Activated");            
            gameObject.SetActive(false);
        }
    }

    
}
