using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraYChangeScene : MonoBehaviour
{
    private Animator animator => GetComponent<Animator>(); 

    [SerializeField] private GameObject menuGO;
    [SerializeField] private GameObject creditosGO;

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
