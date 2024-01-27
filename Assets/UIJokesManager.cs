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


    private void Awake()
    {
        instance = this;
    }
    public void WriteJoke(string text, WaitForSeconds wait)
    {
        textMesh.text = "";
        StartCoroutine(WriteKeyByKey(text, wait));
    }

    private IEnumerator WriteKeyByKey(string text, WaitForSeconds wait)
    {
        foreach (var item in text)
        {
            textMesh.text += item;
            audioSource.Play();
            yield return wait;
        }
        JokesCooldown.instance.RestartTimer();
    }
}

