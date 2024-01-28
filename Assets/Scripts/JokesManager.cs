using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(JokesCooldown))]
public class JokesManager : MonoBehaviour
{
    [SerializeField] private Joke[] jokesList;

    private Joke previousJoke;

    private JokesCooldown jokesCooldown => GetComponent<JokesCooldown>();
    private AudioSource audioSource => GetComponent<AudioSource>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // print(collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Player") && jokesCooldown.canTellAJoke)
        {
           // Debug.Log("CONTAME UN CHISTE");
            jokesCooldown.PauseTimer();
            TellJoke();
        }
    }
   

    private void TellJoke()
    {
        Joke joke = previousJoke;

        // Asegurarse de que haya al menos dos chistes para evitar bucle infinito
        if (jokesList.Length > 1)
        {
            // Intentar obtener un chiste diferente al anterior
            while (joke == previousJoke)
            {
                joke = jokesList[Random.Range(0, jokesList.Length)];
            }
        }
        else
        {
            // Si solo hay un chiste, simplemente úsalo
            joke = jokesList[0];
        }

        previousJoke = joke; // Actualizar el chiste anterior
        UIJokesManager.instance.WriteJoke(joke.text, joke.wait);
        PlayAudio(joke.clip);
    }

    private void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}

[System.Serializable]
public class Joke
{
    public float seconds = 0.025f;
    public WaitForSeconds wait => new WaitForSeconds(seconds);
    public AudioClip clip;
    [TextArea] public string text;
}
