using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectAccel : MonoBehaviour
{
    private float gameSpeed = 7.5f;


    void Update()
    {
        if (gameSpeed <= 12f)
        {
            gameSpeed += 0.175f * Time.deltaTime;
        }

        Rigidbody2D obstacleRB = this.gameObject.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * gameSpeed;
    }
}
