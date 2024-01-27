using System;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI), typeof(AudioSource))]
public class UIJokesManager : MonoBehaviour
{
    public static UIJokesManager instance;

    private TextMeshProUGUI textMesh => GetComponent<TextMeshProUGUI>();
    private AudioSource audioSource => GetComponent<AudioSource>();

    [SerializeField] private GameObject globoDeTexto;

    Animator animator;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        animator = globoDeTexto.GetComponent<Animator>();
    }
    public void WriteJoke(string text, WaitForSeconds wait)
    {
        animator.SetTrigger("TellJoke");
        textMesh.text = "";
        StartCoroutine(WriteKeyByKey(text, wait));
    }

    private IEnumerator WriteKeyByKey(string text, WaitForSeconds wait)
    {
        yield return new WaitForSeconds(0.3f);
        foreach (var item in text)
        {
            textMesh.text += item;
            audioSource.Play();
            yield return wait;
        }
        yield return new WaitForSeconds(2f);
        DeleteJoke();
    }

    private void DeleteJoke()
    {
        textMesh.text = "";
        animator.SetTrigger("Delete");
        JokesCooldown.instance.RestartTimer();
    }
}

