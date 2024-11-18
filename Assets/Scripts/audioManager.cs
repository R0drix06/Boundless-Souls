using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] AudioSource musica;
    [SerializeField] AudioSource sfx;

    public AudioClip musicaFondo;
    public AudioClip muerte;
    public AudioClip orbe;
    public AudioClip salto;
    public AudioClip deslizamiento;

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
        sfx.clip = muerte;
        sfx.Play();
    }

    public void SFX_Orbe()
    {
        sfx.clip = orbe;
        sfx.Play();
    }

    public void SFX_Salto()
    {
        sfx.clip = salto;
        sfx.Play();
    }

    public void SFX_Deslizamiento()
    {
        sfx.clip = deslizamiento;
        sfx.Play();
    }

}
