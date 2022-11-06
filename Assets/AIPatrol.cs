using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    // Start is called before the first frame update

    public float walkSpeed;
    [HideInInspector]
    public bool mustPatrol;
    private bool mustTurn;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    //private int damage;

    void Start()
    {
        mustPatrol = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mustPatrol){
            Patrol();
        }

    }

    private void FixedUpdate(){
        if(mustPatrol){
            //2d physics overlap circle
            // RaycastHit2D groundInfo = Physics2D.Raycast(groundCheckPos.position, Vector2.down,2f);
            // if(groundInfo.collider == false){
            //     mustTurn = true;
            //     Debug.Log("groundcheckpos triggered");
            // }
            mustTurn = false;
            
            //!Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
            //returns true if circle contains ground
        }
    }

    void Patrol(){
        //down drop or touch wall- make sure not to put mob touching floor
        if(mustTurn || bodyCollider.IsTouchingLayers(groundLayer)){
           Flip();
           Debug.Log("flip triggered");
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
        //Debug.Log("mob move");
    }

    void Flip(){
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
