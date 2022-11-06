using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
IEnumerator waiter()
{
    yield return new WaitForSeconds(1.5f);

    //Rotate 40 deg
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
}
}
