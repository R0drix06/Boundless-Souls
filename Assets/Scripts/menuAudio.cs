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
        musica.Play();
    }

    void Update()
    {

    }

    public void SFX_Muerte()
    {
        sfx.clip = seleccion;
        sfx.Play();
    }
}