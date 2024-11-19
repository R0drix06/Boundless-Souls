using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingFloorMovement : MonoBehaviour
{
    [SerializeField] private float gameSpeed;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        gameSpeed = globals.Instance.everythingSpeed;
        Rigidbody2D obstacleRB = this.gameObject.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * gameSpeed;
    }
}
