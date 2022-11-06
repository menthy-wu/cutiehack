using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEngine.Events;

public class restartButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button restartBtn;
    void Start()
    {
        Button btn = restartBtn.GetComponent<Button>();
		btn.onClick.AddListener(Restart);
        
    }

    // Update is called once per frame
    void Restart()
    {
        //reset the scene, 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //re initialize the variables. 
        
    }
}
