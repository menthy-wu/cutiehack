using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenthyPlayer : MonoBehaviour
{
    private float x;
    private float speed = 5f;
    private float jumpPower = 8f;
    private bool facingRight = true;


    private Rigidbody2D rb;
    public Transform graoundCheck;
    public Animator anmi;
    public LayerMask groundLayer;
    public Transform shootinPoints;
    public GameObject bullet;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        x = Input.GetAxisRaw("Horizontal");
        if(x!=0)
        {
            
            anmi.SetBool("walking", true);
        }
        else{
            anmi.SetBool("walking", false);

        }
        rb.velocity = new Vector2(x*speed, rb.velocity.y);
        if((Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.Space)) && rb.velocity.y >= 0 && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y+jumpPower);
        }
        Flip();
    }
    private void Flip()
    {
        if((facingRight && x <0) || (!facingRight && x>0f))
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x*=-1;
            transform.localScale = localScale;
        }
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(graoundCheck.position, 1f, groundLayer);
    }
    public void shoot()
    {
        GameObject projectilePrefab = Instantiate(bullet);
        projectilePrefab.transform.position = transform.position;
        if(transform.localScale.x < 0)
        projectilePrefab.GetComponent<bulletM>().right = false;
        else{
            projectilePrefab.GetComponent<bulletM>().right = true;
        }
    }
}
