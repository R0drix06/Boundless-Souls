using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class managerScript : MonoBehaviour
{
    public float gameSpeed = 7.5f;
    private bool isPaused = false;

    [SerializeField] GameObject player;
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject barra;
    [SerializeField] GameObject botones;
    [SerializeField] GameObject textoBot;
    [SerializeField] GameObject textoTop;

    private void Awake()
    {
        botones.SetActive(false);
        barra.SetActive(true);
        pauseScreen.SetActive(false);
        loseScreen.SetActive(false);
        Time.timeScale = 1;



    }
    private void Update()
    {       


        if (gameSpeed <= 12f)
        {
            gameSpeed += 0.175f * Time.deltaTime;
        }


        if(globals.Instance.perder == true)
        {
            Destroy(player);
            Destroy(barra);

            Time.timeScale = 0;

            loseScreen.SetActive(true);
            botones.SetActive(true);



            //SceneManager.LoadScene("MainMenu");
        }

        if((Input.GetKeyDown(KeyCode.Escape) || Input.GetKey(KeyCode.P)) && globals.Instance.perder == false)
        {
            if ( isPaused == false) {

                isPaused = true;
                pauseScreen.SetActive(true);
                Time.timeScale = 0;
                barra.SetActive(false);
                botones.SetActive(true);


            }

            else if (isPaused == true)
            {
                isPaused = false;
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
                barra.SetActive(true);
                botones.SetActive(false);
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