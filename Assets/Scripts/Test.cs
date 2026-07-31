using NUnit.Framework.Internal;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject Fregnent1;
    [SerializeField] GameObject Fregnent2;

    private float rotateSpeed = 180;
    private void Start()
    {
        
    }

    public bool Landed = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            transform.DetachChildren();
            Fregnent1.SetActive(true);
            Fregnent2.SetActive(true);
            gameObject.SetActive(false);
            Landed = true;
        }
        
        
    }

    private void Update()
    {
        //Debug.Log("Landed :" + Landed);
        //  transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
    }
    
}
