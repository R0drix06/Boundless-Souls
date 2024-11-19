using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuAudio : MonoBehaviour
{
    [SerializeField] AudioSource musica;
    [SerializeField] AudioSource sfx;

    public AudioClip musicaFondo;
    public AudioClip seleccion;

    void Start()
    {
        musica.clip = musicaFondo;


       
     
    }

    void Update()
    {
    if (PlayerPrefs.GetInt("musicaPlay") == 0)
        {

            musica.Play();

        }

        if (PlayerPrefs.GetInt("musicaPlay") == 1)
        {

            musica.Stop();

        }
    }

    public void SFX_Muerte()
    {
        sfx.clip = seleccion;
        sfx.Play();
    }
}