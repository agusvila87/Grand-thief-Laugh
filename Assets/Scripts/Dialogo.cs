using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogo : MonoBehaviour
{
    public bool noAlInicio,cortaronOtro;
    public float velocidadTexto;
    public float tiempoEntreTextos;

    public List<AudioClip> audios;
    public AudioClip tone;
    public AudioClip corte;
    public AudioClip disparoCabeza;

    public string dialogos;
    public string dialogoTutorial;
    private TextMeshProUGUI dialogo;
    private AudioSource _aS;
    private GameManager _gm;
    public bool exit;
    public bool TextoEspecial;
    public TextMeshProUGUI dialogoEspecial;
    UiManager _uiManager;
    private void Awake()
    {
        _uiManager = FindObjectOfType<UiManager>();
    }
    private void Start()//seteo variables y inicio el dialogo
    {
        if (!_uiManager.TutorialCompletado)
        {
            dialogos = dialogoTutorial;
        }

        if (TextoEspecial)
        {
            dialogo = dialogoEspecial;
        }
        else
        {
            dialogo = GameObject.FindGameObjectWithTag("TextoHub").GetComponent<TextMeshProUGUI>();
        }
        _aS = GetComponent<AudioSource>();
        if (!noAlInicio)
        {
            StartCoroutine(Sonidos());
        }
        dialogo.text = "";
    }

    public void DisparoHead()
    {
        _aS.clip = disparoCabeza;
        _aS.Play();
    }
    public void InicioManual()
    {
            exit = false;
            StartCoroutine(Sonidos());
    }

    public void IniciarTexto()//inicio el texto del dialogo
    {
            StartCoroutine(Textos());
    }

    public void PararSonidos()
    {
        _aS.Stop();
    }
    public void CortarLLamada()
    {
        _aS.clip = corte;
        _aS.Play();
        //iniciadoAudio = false;
    }
    public void Clean()
    {
        //dialogo.fontStyle = FontStyles.Strikethrough;
        dialogo.text = "";
    }
    public void TextoSiguiente()
    {
        exit = false;
        StartCoroutine(TextoContinuo());
    }

    public void TextoFinal()
    {
        exit = false;
        StartCoroutine(TextoTerminado());
    }
    IEnumerator Textos()
    {
        //IniciadoText = true;
        foreach (var item in dialogos)//recorro todos los textos escritos
        {
            dialogo.text += item;//voy agregadon dichas letras
            yield return new WaitForSeconds(velocidadTexto);
            //yield return new WaitForSeconds(tiempoEntreTextos);
            //dialogo.text = "";//limpio el texto para el siguiente
        }
        exit = true;//seteo un bool para la corroutina de sonidos
    }

    IEnumerator Sonidos()
    {
        //iniciadoAudio = true;
        //dialogo.text = "";//limpio el texto por si inicia otro texto antes de terminar este
        if (cortaronOtro)
        {
            CortarLLamada();
            yield return new WaitForSeconds(_aS.clip.length + 1);
        }
        _aS.clip = tone;//seteo tono
        _aS.Play();
        yield return new WaitForSeconds(tone.length);//espera hasta que termine el tono
        IniciarTexto();//ejecuto el texto // LLAMO ACA NO A TEXTO
        while (!exit)
        {
            _aS.clip = audios[0];
            _aS.Play();
            yield return new WaitForSeconds(_aS.clip.length);
        }
        CortarLLamada();
    }

    IEnumerator TextoContinuo()
    {
        IniciarTexto();//ejecuto el texto // LLAMO ACA NO A TEXTO
        while (!exit)
        {
            _aS.clip = audios[0];
            _aS.Play();
            yield return new WaitForSeconds(_aS.clip.length);
        }
        //CortarLLamada();
    }

    IEnumerator TextoTerminado()
    {
        IniciarTexto();//ejecuto el texto // LLAMO ACA NO A TEXTO
        while (!exit)
        {
            _aS.clip = audios[0];
            _aS.Play();
            yield return new WaitForSeconds(_aS.clip.length);
        }
        CortarLLamada();
        //Clean();
    }

}
