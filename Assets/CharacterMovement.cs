using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    // Start is called before the first frame update'

    float horizontalMove = 0f;
    public float runSpeed  = 40f;
    bool jump = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Fire", false);
        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if(Input.GetKeyDown(KeyCode.W)){
            jump = true;
            animator.SetBool("jump", true);
        
        }
        if(Input.GetButtonDown("Fire1")){
            animator.SetBool("Fire", true);
        }

        Debug.Log(transform.rotation.y);
        //get input
    }

    public void OnLanding (){
        animator.SetBool("jump", false);
    }


    void FixedUpdate ()
    {
        //move character
        controller.Move(horizontalMove* Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
