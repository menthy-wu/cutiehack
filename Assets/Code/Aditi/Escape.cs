using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    // Start is called before the first frame update
    //assign menuCanvas in inspector
    public GameObject menuCanvas;
    private bool isShowing;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isShowing)
            isShowing = true;
            //menuCanvas.SetActive(isShowing);

        }
        
    }
}
