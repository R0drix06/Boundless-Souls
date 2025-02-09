using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managerScript : MonoBehaviour
{
    public float gameSpeed = 7.5f;
    private float speedLimit = 12f;
    private float aceleracion = 0.175f;
    //private bool isPausedPrivate = globals.Instance.isPaused;

    [SerializeField] GameObject player;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject barra;
    [SerializeField] GameObject botonesPausa;
    [SerializeField] GameObject textoBot;
    [SerializeField] GameObject textoTop;
    [SerializeField] GameObject botonesPerder;
    [SerializeField] GameObject puntuacion;

    private void Awake()
    {
        botonesPausa.SetActive(false);
        botonesPerder.SetActive(false);
        barra.SetActive(true);
        pauseScreen.SetActive(false);
        loseScreen.SetActive(false);
        Time.timeScale = 1;



    }
    private void Update()
    {       


        if (gameSpeed <= speedLimit)
        {
            gameSpeed += aceleracion * Time.deltaTime;
        }


        if(globals.Instance.perder == true)
        {
            Destroy(player);
            Destroy(barra);
            Destroy(puntuacion); 

            Time.timeScale = 0;

            loseScreen.SetActive(true);
            botonesPerder.SetActive(true);

            //SceneManager.LoadScene("MainMenu");
        }

        if((Input.GetKeyDown(KeyCode.Escape) || Input.GetKey(KeyCode.P)) && globals.Instance.perder == false)
        {
            if (globals.Instance.isPaused == false) {

                globals.Instance.isPaused = true;
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
                barra.SetActive(false);
                puntuacion.SetActive(false);
                botonesPausa.SetActive(true);


            }

            else if (globals.Instance.isPaused == true)
            {
                globals.Instance.isPaused = false;
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
                barra.SetActive(true);
                puntuacion.SetActive(true);
                botonesPausa.SetActive(false);
            }


        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
}