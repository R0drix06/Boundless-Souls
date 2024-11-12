using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startingFloorMovement : MonoBehaviour
{
    private float speed = 7.5f;
    [SerializeField] private float gameSpeed;
    // Start is called before the first frame update
    void Start()
    {
        gameSpeed = globals.Instance.everythingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D obstacleRB = this.gameObject.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.left * gameSpeed;
    }
}
