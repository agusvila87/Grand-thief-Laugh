using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraYChangeScene : MonoBehaviour
{
    Animator animator;
    public GameObject menuGO;
    public GameObject creditosGO;
    void Start()
    {
        animator = GetComponent<Animator>();   
    }
    void Update()
    {
        
    }

    public void GoCreditos()
    {
        animator.SetBool("Creditos", true);
        menuGO.SetActive(false);
    }
    public void GoMenu()
    {
        animator.SetBool("Creditos", false);
        creditosGO.SetActive(false);
    }
    void CreditosON()
    {
        creditosGO.SetActive(true);
    }
    void MenuON()
    {
        menuGO.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
