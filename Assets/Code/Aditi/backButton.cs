using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class backButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button backBtn;
    void Start()
    {
        Button btn = backBtn.GetComponent<Button>();
		btn.onClick.AddListener(Back);
    }
    //this will bring us back to the menu
    // Update is called once per frame
    void Back()
    {
        SceneManager.LoadScene(0);
    }
}
