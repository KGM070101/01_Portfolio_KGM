using Unity.VisualScripting;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;

    private Vector2 RandomXforce = new Vector2(2.0f,5.0f);
    private Vector2 RandomYforce = new Vector2(15.0f, 20.0f);
    private Vector2 RandomRotation = new Vector2(-120.0f, 120.0f);

    private Test test;

    private int startCount = 0;

    private float randomR;
    
    private void Start()
    {
        test = FindFirstObjectByType<Test>(FindObjectsInactive.Include);
        rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        Vector2 facingDirection =transform.right.normalized;
        
        if (test.Landed == true)
        {
            startCount++;
        }

        if(startCount==1)
        {
            float randomX = Random.Range(RandomXforce.x, RandomXforce.y);
            float randomY = Random.Range(RandomYforce.x, RandomYforce.y);
            randomR = Random.Range(RandomRotation.x, RandomRotation.y);

            Vector2 LaunchVelocity = facingDirection * randomX + Vector2.up * randomY;

            rigidbody2D.linearVelocity = LaunchVelocity;

            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Ground"),
                                           LayerMask.NameToLayer("Fregments"),true);
        }
        transform.Rotate(0f, 0f, randomR * Time.deltaTime); 
    }


}
