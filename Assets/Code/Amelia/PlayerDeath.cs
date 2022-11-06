using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if(obj.tag == "enemy")
        {
            Debug.Log("dead");
            animator.SetBool("dead", true);
        }
    }
}
