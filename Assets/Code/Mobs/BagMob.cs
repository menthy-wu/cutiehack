using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagMob : MonoBehaviour
{
    private Transform sprite;
    private Transform player;
    private Rigidbody2D rb;
    [SerializeField] private float speed = 2;
    [SerializeField] private float range = 2;

    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(changeDirection());
        sprite = transform.Find("sprite");
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if(playerInRange())
        {
            rb.velocity = (player.position-transform.position).normalized;
        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
        }
        
    }
    IEnumerator changeDirection()
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);
            speed*=-1;
        }
    }
    private bool playerInRange()
    {
        return Vector3.Distance(player.position, transform.position)<range;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }
}
