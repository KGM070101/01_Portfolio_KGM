using UnityEngine;

public class Rain3_SplittedbySamurai_2 : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;

    private Vector2 RandomXforce = new Vector2(5f, 7f);
    private Vector2 RandomYforce = new Vector2(8.0f, 12.0f);
    private Vector2 RandomRotation = new Vector2(-120.0f, 120.0f);

    private float randomR;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        Vector2 facingDirection = transform.right.normalized;

        float randomX = Random.Range(RandomXforce.x, RandomXforce.y);
        float randomY = Random.Range(RandomYforce.x, RandomYforce.y);
        randomR = Random.Range(RandomRotation.x, RandomRotation.y);

        Vector2 LaunchVelocity = facingDirection * randomX + Vector2.up * randomY;

        rigidbody2D.linearVelocity = LaunchVelocity;
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, randomR * Time.deltaTime);
    }
}
