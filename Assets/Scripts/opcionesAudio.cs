using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opcionesAudio : MonoBehaviour
{
    [SerializeField] AudioSource musica;
    [SerializeField] AudioSource sfx;

    public AudioClip musicaFondo;
    public AudioClip seleccion;

    void Start()
    {
        musica.clip = musicaFondo;

        musica.Play();


    }

    // Update is called once per frame
    void Update()
    {


        if (PlayerPrefs.GetInt("musicaPlay") == 1)
        {

            musica.Pause();

        }
        else
        {
            musica.UnPause();
        }
    }
}
