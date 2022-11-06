using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobMovement : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Rigidbody2D rb;
    private int damage;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //Debug.Log("Testing???");
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(1,0);
        //Debug.Log("mob move");
    }
}
