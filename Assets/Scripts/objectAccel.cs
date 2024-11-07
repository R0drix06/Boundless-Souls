using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectAccel : MonoBehaviour
{
    [SerializeField] private float gameSpeed;


    private void Start()
    {
        gameSpeed = globals.Instance.everythingSpeed;
    }


    void Update()
    {
        
        Rigidbody2D obstacleRB = this.gameObject.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * gameSpeed;
    }
}
