using UnityEngine;

public class Rain3_SplittedbySamurai_2 : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;

    public SpriteRenderer spriteRenderer;

    private Vector2 RandomXforce = new Vector2(5f, 7f);
    private Vector2 RandomYforce = new Vector2(8.0f, 12.0f);
    private Vector2 RandomRotation = new Vector2(-120.0f, 120.0f);

    private Color inWasabi_Color = new Color(0.5f, 1.0f, 0f);

    private float randomR;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Rain4_Hard_Collider"))
        {
            spriteRenderer.color = inWasabi_Color;
        }
    }
}
