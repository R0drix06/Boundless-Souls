using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectAccel : MonoBehaviour
{
    [SerializeField] private float gameSpeed;


    private void Start()
    {
        
    }


    void Update()
    {
        gameSpeed = globals.Instance.everythingSpeed;
        Rigidbody2D obstacleRB = this.gameObject.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * gameSpeed;
    }
}
