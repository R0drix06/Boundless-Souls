using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
 //======================================================
 //                     Variables
 //======================================================

    Rigidbody2D rb2d;
    private int velocidad = 15;
    private bool isTop = false;
    private bool isBot = false;
    private int currentJumps = 2;

 //======================================================
 //                     Funciones
 //======================================================

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 5;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if ((rb2d.gravityScale > 0) && (currentJumps > 0))
            {
                rb2d.velocity = Vector2.up * velocidad;
                currentJumps--;
            }
            else if (rb2d.gravityScale < 0 && (currentJumps > 1))
            {
                transform.Translate(0, -6, 0);
                rb2d.gravityScale *= -1;
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if ((rb2d.gravityScale < 0) && (currentJumps > 0))
            {
                rb2d.velocity = Vector2.down * velocidad;
                currentJumps--;
            }
            else if ((rb2d.gravityScale > 0) && (isTop == true || isBot == true))
            {
                transform.Translate(0, 6, 0);
                rb2d.gravityScale *= -1;
            }
        }
    }

 //======================================================
 //                     Colisiones
 //======================================================

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ceeling"))
        {
            isTop = true;
            currentJumps = 2;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isBot = true;
            currentJumps = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ceeling"))
        {
            isTop = false;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isBot = false;
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
 
    Volve aca cuando se rompa algo.

    */
}
