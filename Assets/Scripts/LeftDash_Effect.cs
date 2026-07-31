using UnityEngine;

public class LeftDash_Effect : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriterenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {

    }
    public void Start_LeftDash_Effect()
    {
        //Debug.Log("A");
        animator.SetTrigger("Dash_Effect");
        Invoke("End_LeftDash_Effect", 0.2f);
    }

    public void Start_Samurai_LeftDash_Effect()
    {
        animator.SetTrigger("Dash_Effect");
        spriterenderer.color = Color.cyan;
        Invoke("End_Samurai_LeftDash_Effect", 0.2f);
    }

    private void End_LeftDash_Effect()
    {
        gameObject.SetActive(false);
    }

    private void End_Samurai_LeftDash_Effect()
    {
        spriterenderer.color = Color.white;
        gameObject.SetActive(false);
    }
}
