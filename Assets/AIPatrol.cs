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

    void Start()
    {
        mustPatrol = true;
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
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
            //returns true if circle contains ground
        }
    }

    void Patrol(){
        if(mustTurn || bodyCollider.IsTouchingLayers(groundLayer)){
           Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip(){
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
