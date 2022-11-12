using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private bool dash;
    private bool facingRight = true;
    // private bool onLadder = false;
    private Rigidbody2D rb;
    private Transform graoundCheck;
    private Animator animator;
    [SerializeField]private float speed = 5f;
    [SerializeField]private float dashspeed = 8f;
    [SerializeField]private float jumpPower = 8f;
    [SerializeField]private LayerMask groundLayer;
    [SerializeField]private Transform shootinPoints;
    [SerializeField]private GameObject bullet;
    [SerializeField]private GameObject gameoverPage;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();  
        graoundCheck = transform.Find("groundCheck");
    }
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput= Input.GetAxisRaw("Vertical");
        animator.SetFloat("xspeed", abs(horizontalInput));
        Move();
        if(Input.GetButtonDown("Fire1")){
            
            animator.SetBool("jump", false);
            animator.SetBool("throw", true);
            shoot();
        }
        else if((Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.W)) && isGrounded() && !animator.GetBool("throw"))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y+jumpPower);
            animator.SetBool("jump", true);
            
        }
        
        if(Input.GetKeyDown(KeyCode.LeftShift)){
            dash = true;
        }
        else{
            dash = false;
        }
    }
    void Move()
    {
        if(dash)
        {
            rb.velocity = new Vector2(horizontalInput*dashspeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(horizontalInput*speed, rb.velocity.y);
        }
        if(horizontalInput != 0)
        {
            if(horizontalInput>0)
            {
                facingRight = true;
            }
            else
            {
                facingRight = false;
            }
        }
         if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >1)
        {
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("jumping"))
            {
                animator.SetBool("jump", false);
            }
            else if(animator.GetCurrentAnimatorStateInfo(0).IsName("throw"))
            {
                animator.SetBool("throw", false);
            }
        }
        if(facingRight)
        {
            transform.localScale = new Vector3(abs(transform.localScale.x),transform.localScale.y,transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(-abs(transform.localScale.x),transform.localScale.y,transform.localScale.z);
        }
    }
    private float abs(float num) 
    {
        {
            if(num>=0)
            {
                return num;
            }
            else{
                return -num;
            }
        }
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(graoundCheck.position, 0.02f, groundLayer);
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
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "enemy")
        {
            die();
        }
    }
    private void die() 
    {
		gameoverPage.SetActive(true);
	}
}
