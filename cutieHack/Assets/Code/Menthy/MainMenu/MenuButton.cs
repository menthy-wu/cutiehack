using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    Animator animator;
    MainMenuManager menuManager;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        menuManager = GameObject.Find("MenuBackground").GetComponent<MainMenuManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && animator.GetInteger("state") == 2)
        {
            animator.SetInteger("state", 0);
        }
    }
   public void QuitGame()
    {
        Application.Quit();
    }
    public void StartButton()
    {
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void back()
    {
        menuManager.back();
    }
    public void credit()
    {
        menuManager.Creidts();
    }
}
