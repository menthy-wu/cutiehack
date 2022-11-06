using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletM : MonoBehaviour
{
    float speed= 10;
    private Rigidbody2D rb;
    public bool right = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(SelfDestruct());
        
    }

    // Update is called once per frame
    void Update()
    {
        if(right)
        {rb.velocity = new Vector2(speed, rb.velocity.y);}
        else{rb.velocity = new Vector2(-speed, rb.velocity.y);}
    }
     IEnumerator SelfDestruct()
 {
     yield return new WaitForSeconds(5f);
     Destroy(gameObject);
 }

 private void OnTriggerEnter(Collider other) {
    if(other.gameObject.tag == "ground")
    {
     Destroy(gameObject);
    }
    
 }
}
