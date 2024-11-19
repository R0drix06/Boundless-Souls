using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] public AudioSource musica;
    [SerializeField] AudioSource sfx;
    public static audioManager Instance;

    public AudioClip musicaFondo;
    public AudioClip muerte;
    public AudioClip orbe;
    public AudioClip salto;
    public AudioClip deslizamiento;

    #region Singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);
    }

    #endregion

    void Start()
    {
        musica.clip = musicaFondo;
        PlayBackgroundMusic(true);
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

    public void PlayBackgroundMusic(bool toggleBackgroundMusic)
    {
        if (toggleBackgroundMusic)
        {
            musica.Play();
        }
        else
        {
            musica.Stop();
        }
    }
}
