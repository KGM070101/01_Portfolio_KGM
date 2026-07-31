using UnityEngine;

public class RightDash_Effect : MonoBehaviour
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
    public void Start_RightDash_Effect()
    {
        //Debug.Log("A");
        animator.SetTrigger("Dash_Effect");
        Invoke("End_RightDash_Effect", 0.2f);        
    }

    public void Start_Samurai_RightDash_Effect()
    {
        animator.SetTrigger("Dash_Effect");
        spriterenderer.color = Color.cyan;
        Invoke("End_Samurai_RightDash_Effect", 0.2f);
    }

    private void End_RightDash_Effect()
    {
        gameObject.SetActive(false);
    }

    private void End_Samurai_RightDash_Effect()
    {
        spriterenderer.color = Color.white;
        gameObject.SetActive(false);
    }
}
