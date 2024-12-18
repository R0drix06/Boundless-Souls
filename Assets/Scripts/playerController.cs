using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86;

public class playerController : MonoBehaviour
{
    //======================================================
    //                     Variables
    //======================================================

    [SerializeField] audioManager am;

    [SerializeField] Image barra;
    public float porcentajeBarra = 100;
    public float porcentajeActual = 100;
    [SerializeField] private float discharge;

    BoxCollider2D playerCollider;
    Rigidbody2D rb2d;
    [SerializeField] private float velocidad = 13f;

    private float posicionArriba = 6.3f;
    private float posicionAbajo = -6.3f;
    private float impulso = 1.15f;
    private float slideTime = 1f;
    private float currentSlidetime;
    private float aceleracion = 0.125f;
    private float gravedadMax = 15f;
    private float gravedadMin = -15f;
    private float porcentajeOrbe = 20f;
    public bool isTop = false;
    public bool isBot = false;
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
        discharge = globals.Instance.dischargeRate;
        porcentajeActual -= discharge * Time.deltaTime;

        if (porcentajeActual > 100)
        {
            porcentajeActual = 100;
        }

        if (barra.fillAmount <= 0)
        {
            //Destroy(gameObject);
            //gameManager.instance.gameOver();
            //SceneManager.LoadScene("MainMenu");

            globals.Instance.perder = true;
        }



        if(isSliding)
        {

            anim.SetBool("isSliding", true);
            //anim.SetBool("isjumping", false);
            anim.SetBool("isRunning", false);

        }
        else
        {

            anim.SetBool("isSliding", false);


        }

        //Deslice
        if (isSliding)
        {
            rb2d.velocity = Vector2.down * velocidad; //Deslice
            playerCollider.size = new Vector2(2.5f, 2);
            playerCollider.offset = new Vector2(0, -2);

            currentSlidetime += Time.deltaTime;

            if (currentSlidetime > slideTime)
            {
                isSliding = false;

            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                rb2d.velocity = Vector2.up * velocidad;
                isSliding = false;
            }
        }
        else
        {
            playerCollider.size = new Vector2(2.5f, 6);
            playerCollider.offset = new Vector2(0, 0);
            currentSlidetime = 0;
        }


        //Movimiento
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isBot && currentJumps > 0)
            {
                rb2d.velocity = Vector2.up * velocidad * impulso; //Salto Hacia Arriba
                currentJumps--;
                isSliding = false;


                anim.SetBool("isjumping", true);
                anim.SetBool("isRunning", false);

            }
            else if (isTop)
            {

                currentJumps = 1;
                transform.Translate(0, posicionAbajo, 0); //TP Hacia Abajo
                rb2d.gravityScale *= -1;
                velocidad += 2;
                sprite.flipY = false;

                am.SFX_Teleport();

            }
            else if (rb2d.gravityScale > 0 && currentJumps == 0)
            {
                isSliding = true;
                
                rb2d.velocity = Vector2.up * velocidad;
            }
        }

        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
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
                transform.Translate(0, posicionArriba, 0); //TP Hacia Arriba
                rb2d.gravityScale *= -1;
                velocidad -= 2;
                sprite.flipY = true;

                am.SFX_Teleport();

            }
        }

        //Aceleración
        if (rb2d.gravityScale <= gravedadMax && rb2d.gravityScale >= gravedadMin)
        {
            velocidad += aceleracion * Time.deltaTime;

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
            isBot = false;
            currentJumps = 2;
            anim.SetBool("isjumping", false);

        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isBot = true;
            isTop = false;
            currentJumps = 1;
            anim.SetBool("isjumping", false);

        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            //gameManager.instance.gameOver();
            //SceneManager.LoadScene("MainMenu");
            globals.Instance.perder = true;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orb"))
        {
            porcentajeActual += porcentajeOrbe;
            Destroy(collision.gameObject);

            am.SFX_Orbe();
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
                                     7<..&
 

    */

}

