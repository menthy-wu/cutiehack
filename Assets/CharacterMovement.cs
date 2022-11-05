using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2D controller;
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
        horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        if(Input.GetKeyDown(KeyCode.W)){
            jump = true;
        
        }
        //get input
    }
    void FixedUpdate ()
    {
        //move character
        controller.Move(horizontalMove* Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
