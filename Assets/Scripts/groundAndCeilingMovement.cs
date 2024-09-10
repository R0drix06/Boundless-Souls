using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Este script hace que el piso y techo del principio se muevan, el movimiento de el resto de los tiles se da en el codigo de groundSpawner
public class groundAndCeilingMovement : MonoBehaviour
{
    public float groundSpeed = 7.25f;
    [SerializeField] Rigidbody2D groundRB;
    // Start is called before the first frame update
    void Start()
    {
        groundRB = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        groundRB.velocity = Vector2.left * groundSpeed;
    }
}
