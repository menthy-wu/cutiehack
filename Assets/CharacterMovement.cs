using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public GameObject GAMEOVER;
    // Start is called before the first frame update'

    float horizontalMove = 0f;
    public float runSpeed  = 40f;
    bool jump = false;
    public GameObject bullet;

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
            shoot();
        }

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
    }	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "enemy")
		{
			die();
		}
		
	}
	private void die() {
		{
            GAMEOVER.SetActive(true);
            Destroy(gameObject);
		}
	}
}
