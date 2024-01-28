using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraYChangeScene : MonoBehaviour
{
    private Animator animator => GetComponent<Animator>(); 

    [SerializeField] private GameObject menuGO;
    [SerializeField] private GameObject creditosGO;
    [SerializeField] private float timerPlay=2f;
    [SerializeField] private GameObject instruccionesGO;
    [SerializeField] private GameObject BotonPlay;
    private void Start()
    {
        Time.timeScale = 1f;
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

    public void GoPlay()
    {
        menuGO.SetActive(false);
        animator.SetBool("GoPlay", true);
    }

    private void Instrucciones()
    {
        instruccionesGO.SetActive(true);
        StartCoroutine(Wait5SeconsPlay());
    }

    IEnumerator Wait5SeconsPlay()
    {
        yield return new WaitForSeconds(timerPlay);
        BotonPlay.SetActive(true);

    }
}
