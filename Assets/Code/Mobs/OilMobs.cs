using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilMobs : MonoBehaviour
{
    private Transform BonceCheckR;
    private Transform BonceCheckL;
    private Transform graoundCheckR;
    private Transform graoundCheckL;
    private Transform sprite;
    private Rigidbody2D rb;
    private float currentSpeed;
    [SerializeField] private float speed = 2f;
    [SerializeField]private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        currentSpeed = speed;
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
        graoundCheckR = transform.Find("GroundCheckPositionRight");
        graoundCheckL = transform.Find("GroundCheckPositionLeft");
        BonceCheckR = transform.Find("BonceCheckR");
        BonceCheckL = transform.Find("BonceCheckL");
        sprite = transform.Find("sprite");
    }

    // Update is called once per frame
    void Update()
    {
        if(checkLeft())
        {
            sprite.localScale = new Vector3(1,1,1);
            currentSpeed = speed;
        }
        else if(checkRight())
        {
            sprite.localScale = new Vector3(-1,1,1);
            currentSpeed = -speed;
        }
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
    }
    private bool checkLeft()
    {
        return !(Physics2D.OverlapCircle(graoundCheckL.position, 0.02f, groundLayer)) || Physics2D.OverlapCircle(BonceCheckL.position, 0.02f, groundLayer);
    }
    private bool checkRight()
    {
        return Physics2D.OverlapCircle(BonceCheckR.position, 0.02f, groundLayer) || !(Physics2D.OverlapCircle(graoundCheckR.position, 0.02f, groundLayer));
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "bullet")
        {
            Destroy(gameObject);
        }
    }
}
