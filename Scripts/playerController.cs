using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86;

public class playerController : MonoBehaviour
{
    //======================================================
    //                     Variables
    //======================================================

    [SerializeField] Image barra;
    private float porcentajeBarra = 100;
    private float porcentajeActual = 100;

    BoxCollider2D playerCollider;
    Rigidbody2D rb2d;
    [SerializeField] private float velocidad = 13f;
    private float slideTime = 1.5f;
    private float currentSlidetime;
    private bool isTop = false;
    private bool isBot = false;
    private bool isSliding = false;
    private int currentJumps = 2;
    private Animator anim;
    private SpriteRenderer sprite;

    //======================================================
    //                     Funciones
    //======================================================

    void Start()
    {
        playerCollider = GetComponent<BoxCollider2D>();
        playerCollider.size = new Vector2 (1, 1);

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 4.5f;

        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();    
    }

    void Update()
    {
        barra.fillAmount = porcentajeActual / porcentajeBarra;

        porcentajeActual -= 10 * Time.deltaTime;

        if (barra.fillAmount <= 0)
        {
            Destroy(gameObject);
            //gameManager.instance.gameOver();
            SceneManager.LoadScene("MainMenu");
        }

        //Deslice
        if (isSliding)
        {
            rb2d.velocity = Vector2.down * velocidad; //Deslice
            playerCollider.size = new Vector2(1, 0.5f);
            playerCollider.offset = new Vector2(0, -0.25f);

            currentSlidetime += Time.deltaTime;

            if (currentSlidetime > slideTime)
            {
                isSliding = false;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                rb2d.velocity = Vector2.up * velocidad;
                isSliding = false;
            }
        }
        else
        {
            playerCollider.size = new Vector2(1, 1);
            playerCollider.offset = new Vector2(0, 0);
            currentSlidetime = 0;
        }


        //Movimiento
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isBot && currentJumps > 0)
            {
                rb2d.velocity = Vector2.up * velocidad; //Salto Hacia Arriba
                currentJumps--;
                isSliding = false;


                anim.SetBool("isjumping", true);
                anim.SetBool("isRunning", false);

            }
            else if (isTop)
            {

                currentJumps = 1;
                transform.Translate(0, -6, 0); //TP Hacia Abajo
                rb2d.gravityScale *= -1;
                velocidad += 2;
                sprite.flipY = false;

            }
            else if (rb2d.gravityScale > 0 && currentJumps == 0)
            {
                isSliding = true;
                rb2d.velocity = Vector2.up * velocidad;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (rb2d.gravityScale < 0 && currentJumps > 0)
            {
                rb2d.velocity = Vector2.down * velocidad; //Salta Hacia Abajo
                currentJumps--;


                anim.SetBool("isjumping", true);
                anim.SetBool("isRunning", false);
            }
            else if (isBot)
            {
                transform.Translate(0, 6, 0); //TP Hacia Arriba
                rb2d.gravityScale *= -1;
                velocidad -= 2;
                sprite.flipY = true;

            }
        }

        //Aceleraci�n
        if (rb2d.gravityScale <= 15 && rb2d.gravityScale >= -15)
        {
            velocidad += 0.125f * Time.deltaTime;

            if (rb2d.gravityScale > 0)
            {
                rb2d.gravityScale += 0.1f * Time.deltaTime;
                anim.SetBool("isRunning", true);

            }
            else if (rb2d.gravityScale < 0)
            {
                rb2d.gravityScale -= 0.1f * Time.deltaTime;
                anim.SetBool("isRunning", true);

            }
        }


        //======================================================
        //                     Animaciones
        //======================================================

        if (isBot && rb2d.gravityScale > 0)
        {
            anim.SetBool("isDemon", true);
            anim.SetBool("isAngel", false);
      

        }

        if (isTop && rb2d.gravityScale < 0)
        {

            anim.SetBool("isDemon", false);
            anim.SetBool("isAngel", true);
            

        }


    }


    //======================================================
    //                     Colisiones
    //======================================================

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ceiling"))
        {
            isTop = true;
            currentJumps = 2;
            anim.SetBool("isjumping", false);

        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isBot = true;
            currentJumps = 1;
            anim.SetBool("isjumping", false);

        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            GameManager.instance.gameOver();
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (currentJumps == 1 || currentJumps == 0 && rb2d.gravityScale <= 0)
        {
            if (collision.gameObject.CompareTag("Ceiling"))
            {
                isTop = false;
            }                        
        }

        if ((currentJumps == 0 && rb2d.gravityScale > 0) || (rb2d.gravityScale < 0))
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isBot = false;
            }
        }
    }






    /*
                             ...,?77??!~~~~!???77?<~.... 
                        ..?7`                           `7!.. 
                    .,=`          ..~7^`   I                  ?1. 
       ........  ..^            ?`  ..?7!1 .               ...??7 
      .        .7`        .,777.. .I.    . .!          .,7! 
      ..     .?         .^      .l   ?i. . .`       .,^ 
       b    .!        .= .?7???7~.     .>r .      .= 
       .,.?4         , .^         1        `     4... 
        J   ^         ,            5       `         ?<. 
       .%.7;         .`     .,     .;                   .=. 
       .+^ .,       .%      MML     F       .,             ?, 
        P   ,,      J      .MMN     F        6               4. 
        l    d,    ,       .MMM!   .t        ..               ,, 
        ,    JMa..`         MMM`   .         .!                .; 
         r   .M#            .M#   .%  .      .~                 ., 
       dMMMNJ..!                 .P7!  .>    .         .         ,, 
       .WMMMMMm  ?^..       ..,?! ..    ..   ,  Z7`        `?^..  ,, 
          ?THB3       ?77?!        .Yr  .   .!   ?,              ?^C 
            ?,                   .,^.` .%  .^      5. 
              7,          .....?7     .^  ,`        ?. 
                `<.                 .= .`'           1 
                ....dn... ... ...,7..J=!7,           ., 
             ..=     G.,7  ..,o..  .?    J.           F 
           .J.  .^ ,,,t  ,^        ?^.  .^  `?~.      F 
          r %J. $    5r J             ,r.1      .=.  .% 
          r .77=?4.    ``,     l ., 1  .. <.       4., 
          .$..    .X..   .n..  ., J. r .`  J.       `' 
        .?`  .5        `` .%   .% .' L.'    t 
        ,. ..1JL          .,   J .$.?`      . 
                1.          .=` ` .J7??7<.. .; 
                 JS..    ..^      L        7.: 
                   `> ..       J.  4. 
                    +   r `t   r ~=..G. 
                    =   $  ,.  J 
                    2   r   t  .; 
              .,7!  r   t`7~..  j.. 
              j   7~L...$=.?7r   r ;?1. 
               8.      .=    j ..,^   .. 
              r        G              . 
            .,7,        j,           .>=. 
         .J??,  `T....... %             .. 
      ..^     <.  ~.    ,.             .D 
    .?`        1   L     .7.........?Ti..l 
   ,`           L  .    .%    .`!       `j, 
.^             .  ..   .`   .^  .?7!?7+. 1 
.`              .  .`..`7.  .^  ,`      .i.; 
.7<..........~<<3?7!`    4. r  `          G% 
                          J.` .!           % 
                            JiJ           .` 
                              .1.         J 
                                 ?1.     .'         
                                     7<..%
 
    Usa al sonic para volver cuando se rompa algo

    */

}
