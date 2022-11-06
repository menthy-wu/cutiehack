using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject Bullet;
    //public GameObject Bullet1;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetButtonDown("Fire1"))
        {    var temp = Instantiate(Bullet, transform.position, transform.rotation);
            Destroy(temp, 10f);}

            // var temp1 = Instantiate(Bullet1, transform.position, transform.rotation);
            // Destroy(temp1, 10f);
        
    }
}
